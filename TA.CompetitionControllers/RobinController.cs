using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Corel;
using TA.Competitions.Forms;
using TA.Competitions;

namespace TA.CompetitionControllers
{
    public class RobinController : CompetitionController
    {
        private Robin FCompetition = null;        
        public virtual Competition Competition
        {
            get { return FCompetition; }
            set
            {
                if (value is Robin)
                    FCompetition = value as Robin;
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
                players = new List<CompetitionPlayerInfo>();
                int[] sort_order = GetDrawOrder(players_by_seedno.Count);
                for (int i = 0; i < players_by_seedno.Count; i++)
                {
                    players.Add(players_by_seedno[sort_order[i] - 1]);
                }
            }
            else
            {   
                // если матчи уже были, то ошибка
                throw new Exception(Localizator.Dictionary.GetString("MATCHES_EXISTS"));
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
        public static MatchInfo CreateMatch(Competition competition, SeedPair players_pair) 
        {
            MatchInfo match = new MatchInfo();
            match.PlayerA.Id = players_pair.playerIdA;
            if (match.PlayerA.Id == 0)
                match.PlayerA.Name = "-";
            else
            {
                match.PlayerA.Name = competition.Players[players_pair.playerIdA].NickName;
                match.PlayerA.Guid = competition.Players[players_pair.playerIdA].Identifier;
            }
                
            match.PlayerB.Id = players_pair.playerIdB;
            if (match.PlayerB.Id == 0)
                match.PlayerB.Name = "-";
            else            
            {
                match.PlayerB.Name = competition.Players[players_pair.playerIdB].NickName;
                match.PlayerB.Guid = competition.Players[players_pair.playerIdB].Identifier;
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

            int[] plrs = new int[players.Count];  // Список игроков для рассеивания 
            
            SeedPair[] new_mtchs = new SeedPair[(players.Count - 1) * players.Count / 2]; // Список новых матчей
            int index = 0;
            foreach (CompetitionPlayerInfo player in players) 
            {
                plrs[index++] = player.Id;
            }


            // формируем пары для следующего раунда
            if (!RobinSeeder.Seed(plrs, new_mtchs))
                throw new Exception("Draw Error");
            
            // Создаем матчи и добавляем их в список матчей
            int pc = players.Count;
            for (int round = 0; round < pc - 1; round++) // Кол-во туров равно Кол-во игроков - 1
            {
                for (int match_no = 0; match_no < pc / 2; match_no++) // Кол-во матчей в туре равно Кол-во игрков деленное на два
                {
                    SeedPair pair = new_mtchs[round * pc / 2 + match_no];
                    MatchInfo match = CreateMatch(Competition, pair);
                    match.Label.Division = 1;
                    match.Label.Round = round + 1;
                    match.Label.MatchNo = match_no + 1;
                    TA.DB.Manager.DatabaseManager.CurrentDb.CreateMatch(Competition.Info.Id, match);
                    Competition.Matches.Add(match.Id, match);
                }
            }
            return true;
        }

        /// <summary>
        /// Возвращает компонент управления для данного типа соревнований
        /// </summary>
        /// <returns></returns>
        public virtual CompetitionPanel GetControl()
        {
            RobinPanel panel = new RobinPanel();
            panel.OpenCompetition(Competition);
            return panel;
        }

        internal RobinController() : base()
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
