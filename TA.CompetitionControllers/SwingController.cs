using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Competitions;
using TA.Competitions.Forms;
using TA.Corel;
using TA.Utils;

namespace TA.CompetitionControllers
{
    class SwingController : FppsSwissController
    {
        #region CompetitionController Members
        private Swing FCompetition = null;
        public override TA.Corel.Competition Competition
        {
            get
            {
                return FCompetition;
            }
            set
            {
                if (value is Swing)
                    FCompetition = value as Swing;
            }
        }

        protected virtual bool CanEditMatch(MatchInfo match)
        {
            if (FCompetition.Info.Status == CompetitionInfo.CompetitionState.Finished)
                return false;
            return match.Label.Round == (FCompetition as TA.Competitions.Swing).RoundCount;
        }

        public override bool SeedPlayers()
        {
            SeedingArgs args = SeedingArgs.Empty;
            args.LastPlayerWithBay = 0;
            int round = 0;
            foreach (MatchInfo match in Competition.Matches.Values)
            {
                // Определяем какой игрок в последнием раунде играл с баем
                if (match.PlayerA.Id == 0 && match.Label.Round >= round)
                    args.LastPlayerWithBay = match.PlayerB.Id;
                if (match.PlayerB.Id == 0 && match.Label.Round >= round)
                    args.LastPlayerWithBay = match.PlayerA.Id;

                if (match.Label.Round > round)
                    round = match.Label.Round;

            }
            round++;
            // Список игрков для матчей
            CompetitionPlayerList players = new CompetitionPlayerList();
            foreach(CompetitionPlayerInfo player in GetPlayersToSeed())
            {
                if(round > 1)
                    player.SeedNo = 0;
                players.Add(player.Id, player);
            }
            args.PlayersToSeed = players;
            args.SeedOrder = GetDrawOrder(args.PlayersToSeed.Count);
            args.SeedType = Seeding.SeedType.Matches;
            args.AllowRating = false;

            Dictionary<int, int> current_points = new Dictionary<int, int>(); // Текущее количество набранных игроками очков


            if (round == 1 || fGraphicalSeeding.Seed(args))
            {
                SeedPair[] new_mtchs = new SeedPair[players.Count / 2]; // Список новых матчей
                foreach (CompetitionPlayerInfo player in args.PlayersToSeed.Values) 
                {
                    current_points.Add(player.Id, player.AvailablePoints);
                    int seed_index = player.SeedNo - 1;
                    if (seed_index >= 0) 
                    {
                        int match_index = seed_index % new_mtchs.Length;
                        if (new_mtchs[match_index] == null)
                        {
                            new_mtchs[match_index] = new SeedPair(0, 0);
                        }
                        if (seed_index < new_mtchs.Length)
                            new_mtchs[match_index].playerIdA = player.Id;
                        else
                            new_mtchs[match_index].playerIdB = player.Id;
                    }
                }
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
            }

            /**********************************************************************/
           /* int round = 0;

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
                throw new Exception("Draw error");

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
            }*/
            return true;
        }

        public override TA.Competitions.Forms.CompetitionPanel GetControl()
        {
            SwingPanel panel = new SwingPanel();
            panel.OpenCompetition(Competition);
            return panel;
        }

        public override TA.Competitions.Forms.CompetitionParamsPanel GetParametersPanel()
        {
            return new SwingParamsPanel(FCompetition);
        }


        #endregion
    }
}
