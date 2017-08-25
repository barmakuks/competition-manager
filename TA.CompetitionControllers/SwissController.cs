using System;
using System.Collections.Generic;
using System.Collections;

using System.Linq;
using System.Text;
using TA.Corel;
using TA.Competitions;
using TA.Competitions.Forms;

namespace TA.CompetitionControllers
{
    public class SwissController : CompetitionController
    {        
        private Swiss FCompetition = null;        
        public virtual Competition Competition
        {
            get { return FCompetition; }
            set
            {
                if (value is Swiss)
                    FCompetition = value as Swiss;
            }
        }

        /// <summary>
        /// возвращает список ироков для рассеивания
        /// </summary>
        /// <returns>List<CompetitionPlayerInfo> - список игроков для рассеивания</returns>        
        protected virtual List<CompetitionPlayerInfo> GetPlayersToSeed() 
        {
            List<CompetitionPlayerInfo> players = null;

            if (Competition.Matches.Count == 0)
            {   //Если еще не было матчей, то получаем список игроков по жеребъевке                
                List<CompetitionPlayerInfo> players_by_seedno = Competition.Players.GetSortedList(CompetitionPlayerList.SortByField.SeedNo);
                // Получаем порядок формирования пар
                int[] sort_order = GetDrawOrder(players_by_seedno.Count);
                // Создаем пустой список, куда будут добавлены игроки для формирования пар по порядку жребия
                CompetitionPlayerInfo[] players_pairs = new CompetitionPlayerInfo[sort_order.Length];
                for (int i = 0; i < players_pairs.Length; i++)
                    players_pairs[i] = CompetitionPlayerInfo.Dummy;
                foreach (CompetitionPlayerInfo player in players_by_seedno)
                {
                    for (int i = 0; i < sort_order.Length; i++)
                    {
                        if (sort_order[i] == player.SeedNo)
                            players_pairs[i] = player;
                    }
                }
                players = new List<CompetitionPlayerInfo>();
                players.AddRange(players_pairs);
                /*
                for (int i = 0; i < players_by_seedno.Count; i++)
                {
                    players.Add(players_by_seedno[sort_order[i] - 1]);
                }*/
            }
            else
            {   // если матчи уже были, то получаем список игроков по результатам
                players = Competition.PlayersResults;
            }

            // тут добавим бая
            if (players.Count % 2 != 0)
                players.Add(CompetitionPlayerInfo.Dummy);
            return players;
        }

        /// <summary>
        /// создает матч и инициализирует параметры игроков
        /// </summary>
        /// <param name="players_pair">пара ID игроков</param>
        /// <returns>Созданный матч</returns> 
        protected virtual MatchInfo CreateMatch(SeedPair players_pair) 
        {
            MatchInfo match = new MatchInfo();
            match.PlayerA.Id = players_pair.playerIdA;
            if (match.PlayerA.Id == 0)
                match.PlayerA.Name = "-";
            else
            {
                match.PlayerA.Name = Competition.Players[players_pair.playerIdA].NickName;
                match.PlayerA.Guid = Competition.Players[players_pair.playerIdA].Identifier;
            }
            match.PlayerB.Id = players_pair.playerIdB;
            if (match.PlayerB.Id == 0)
                match.PlayerB.Name = "-";
            else
            {
                match.PlayerB.Name = Competition.Players[players_pair.playerIdB].NickName;
                match.PlayerB.Guid = Competition.Players[players_pair.playerIdB].Identifier;
            }
            return match;
        }

        /// <summary>
        /// Рассеивает игроков по швейцарской системе
        /// </summary>
        /// <returns></returns>
        public virtual bool SeedPlayers()
        { 
            // Список игрков для матчей
            List<CompetitionPlayerInfo> players = GetPlayersToSeed();
                        
            int round = 0;
            
            int[] plrs = new int[players.Count];  // Список игроков для рассеивания 
            SeedPair[] mtchs = new SeedPair[Competition.Matches.Values.Count]; // Список сыгранных матчей
            SeedPair[] new_mtchs = new SeedPair[players.Count / 2]; // Список новых матчей
            Dictionary<int, int> current_points = new Dictionary<int, int>(); // Текущее количество набранных игроками очков
            int index = 0;
            foreach (CompetitionPlayerInfo player in players) 
            {
                plrs[index++] = player.Id;
                current_points.Add(player.Id, player.AvailablePoints);
            }
            index = 0;
            foreach (MatchInfo match in Competition.Matches.Values) 
            {
                mtchs[index++] = new SeedPair(match.PlayerA.Id, match.PlayerB.Id);
                if (match.Label.Round > round)
                    round = match.Label.Round;
            }
            round++;
            // формируем пары для следующего раунда
            if (!SwissSeeder.Seed(plrs, mtchs, new_mtchs, 0)) 
            {
                throw new Exception(Localizator.Dictionary.GetString("IMPOSSIBLE_TO_DRAW"));
            }
            
            if (round > 1) { // Даем возможность изметить рассадку после автоматической жеребьевки начиная со второго тура
                SeedingArgs args = SeedingArgs.Empty;
                args.PlayersToSeed = Competition.Players;
                args.SeedOrder = GetDrawOrder(args.PlayersToSeed.Count);
                args.SeedType = Seeding.SeedType.Matches;
                args.AllowAuto = false; args.AllowManual = false; args.AllowRating = false; args.AllowReset = false;
                
                for (int i = 0; i < new_mtchs.Length; i++ )
                {
                    int seed_no = args.SeedOrder[i * 2];
                    if(new_mtchs[i].playerIdA > 0)
                        args.PlayersToSeed[new_mtchs[i].playerIdA].SeedNo = seed_no;
                    seed_no = args.SeedOrder[i * 2 + 1];
                    if(new_mtchs[i].playerIdB > 0)
                        args.PlayersToSeed[new_mtchs[i].playerIdB].SeedNo = seed_no;
                }
                
                if (fGraphicalSeeding.Seed(args)) {
                    // обнуляем результат автоматической жеребьевки
                    for (int i = 0; i < new_mtchs.Length; i++) {
                        new_mtchs[i].playerIdA = 0;
                        new_mtchs[i].playerIdB = 0;
                    }
                    // Формируем матчи по ручной жеребьевке

                    foreach (CompetitionPlayerInfo player in Competition.Players.Values) {
                        int seed_no = player.SeedNo;
                        for (int i = 0; i < args.SeedOrder.Length; i++) {
                            if (args.SeedOrder[i] == seed_no) {
                                if (i % 2 == 0)
                                    new_mtchs[i / 2].playerIdA = player.Id;
                                else
                                    new_mtchs[i / 2].playerIdB = player.Id;
                            }
                        }
                    }
                }
            }
            
            // Создаем матчи и добавляем их в список матчей
            int match_no = 1;
            foreach (SeedPair pair in new_mtchs)
            {
                MatchInfo match = CreateMatch(pair);
                
                // Устанавливаем максимальное количество очков в партии
                if (match.PlayerA.Id > 0 && match.PlayerB.Id > 0) 
                {
                    match.PlayerA.Tag = current_points[match.PlayerA.Id];
                    match.PlayerB.Tag = current_points[match.PlayerB.Id];
                }

                match.Label.Division = 1;
                match.Label.Round = round;
                match.Label.MatchNo = match_no;
                TA.DB.Manager.DatabaseManager.CurrentDb.CreateMatch(Competition.Info.Id, match);
                Competition.Matches.Add(match.Id, match);
                match_no++;
            }
            return true;
        }

        /// <summary>
        /// Возвращает компонент управления для данного типа соревнований
        /// </summary>
        /// <returns></returns>
        public virtual CompetitionPanel GetControl()
        {
            SwissPanel panel = new SwissPanel();
            panel.OpenCompetition(Competition);
            return panel;
        }

        internal SwissController() : base()
        {
        }

        /// <summary>
        /// Возвращает Компонент для редактирования дополнительных параметров
        /// </summary>
        /// <returns></returns>
        public virtual CompetitionParamsPanel GetParametersPanel()
        {
            return null;
        }

        public int[] GetDrawOrder(int playerCount) 
        {
            int[] mas = new int[playerCount + playerCount % 2];
            int index = 1;
            for (int i = 0; i < mas.Length; i += 2)
            {
                mas[i] = index;
                mas[i + 1] = index + mas.Length / 2;
                index++;
            }
            return mas;
        }
    }
}
