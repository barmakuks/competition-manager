using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Competitions;
using TA.Corel;
using TA.Competitions.Forms;
using TA.DB.Manager;


namespace TA.CompetitionControllers
{
    public class RobinOlympicController : CompetitionController
    {
        private RobinOlympic FCompetition = null;
        public Competition Competition
        {
            get
            {
                return FCompetition;
            }
            set
            {
                if (value is RobinOlympic)
                    FCompetition = value as RobinOlympic;
            }
        }

        private void CreateGroupMatches(int groupNo, CompetitionPlayerList groupPlayers) 
        {
            int[] plrs = new int[groupPlayers.Count];  // Список игроков для рассеивания 

            SeedPair[] new_mtchs = new SeedPair[(groupPlayers.Count - 1) * groupPlayers.Count / 2]; // Список новых матчей
            int index = 0;
            foreach (CompetitionPlayerInfo player in groupPlayers.Values)
            {
                plrs[index++] = player.Id;
            }
            // формируем пары для следующего раунда
            if (!RobinSeeder.Seed(plrs, new_mtchs))
                throw new Exception("Draw error");

            // Создаем матчи и добавляем их в список матчей
            int pc = groupPlayers.Count;
            for (int round = 0; round < pc - 1; round++) // Кол-во туров равно Кол-во игроков - 1
            {
                for (int match_no = 0; match_no < pc / 2; match_no++) // Кол-во матчей в туре равно Кол-во игрков деленное на два
                {
                    SeedPair pair = new_mtchs[round * pc / 2 + match_no];
                    MatchInfo match = RobinController.CreateMatch(Competition, pair);
                    match.Label.Division = groupNo;
                    match.Label.Round = round + 1;
                    match.Label.MatchNo = match_no + 1;
                    TA.DB.Manager.DatabaseManager.CurrentDb.CreateMatch(Competition.Info.Id, match);
                    Competition.Matches.Add(match.Id, match);
                }
            }
        }
        private bool CreateFirstRoundMatches() 
        {
            // Получить список игроков после жеребьевки            
            List<CompetitionPlayerInfo> allPlayers = Competition.Players.GetSortedList(CompetitionPlayerList.SortByField.SeedNo);
            int group_count = FCompetition.GroupCount;
            CompetitionPlayerList groupPlayers = new CompetitionPlayerList();
            int[] draw_order = GetDrawOrder(allPlayers.Count);

            // Рассчитываем количество игроков в группе
            int group_player_count = Competition.Players.Count / FCompetition.GroupCount;
            if(Competition.Players.Count % FCompetition.GroupCount != 0)
                group_player_count ++;

            int player_index = 0;
            for (int i = 0; i < group_count; i++) 
            {
                // Сформировать список игроков для группы
                groupPlayers.Clear();
                for (int j = 0; j < group_player_count; j++) 
                {
                    int pi = draw_order[player_index] - 1;
                    if (pi < allPlayers.Count)
                        groupPlayers.Add(j, allPlayers[pi]);
                    player_index++;
                }
                // Создать матчи группы
                /*while (groupPlayers.Count < group_player_count) 
                {
                    groupPlayers.Add(player_index, CompetitionPlayerInfo.Dummy);
                }*/
                if(groupPlayers.Count % 2 == 1)
                    groupPlayers.Add(player_index, CompetitionPlayerInfo.Dummy);
                CreateGroupMatches(i + 1, groupPlayers);
            }
            return false;
        }
        private bool CreateSecondRoundMatches() 
        {
            int player_count = FCompetition.KOPlayerCount;
            int match_count = player_count / 2;
            int round = 1;
            int division_no = FCompetition.GroupCount + 1;
            while (match_count > 0) 
            {
                int match_no = 1;
                for (int i = 0; i < match_count; i++, match_no++) 
                {
                    MatchInfo match = new MatchInfo();
                    match.Label.Division = division_no;
                    match.Label.Round = round;
                    match.Label.MatchNo = match_no;
                    switch (match_count) 
                    {
                        case 1: // Если это финал
                            match.Winners_MatchLabel = new MatchLabel("01");
                            match.Loosers_MatchLabel = new MatchLabel("02");
                            match.Title = Localizator.Dictionary.GetString("FINAL_MATCH");
                            if (FCompetition.PlayThirdPlaceMatch) // Если нужен матч за 3-е место
                            {
                                MatchInfo match_3rd = new MatchInfo();
                                match_3rd.Label.Division = division_no;
                                match_3rd.Label.Round = round;
                                match_3rd.Label.MatchNo = match_no + 1;
                                match_3rd.Title = Localizator.Dictionary.GetString("3_PLACE_MATCH");
                                match_3rd.Loosers_MatchLabel.Place = "04";
                                match_3rd.Winners_MatchLabel.Place = "03";
                                TA.DB.Manager.DatabaseManager.CurrentDb.CreateMatch(Competition.Info.Id, match_3rd);
                                Competition.Matches.Add(match_3rd.Id, match_3rd);
                            }
                            break;
                        case 2: // Полуфиналы
                            if (FCompetition.PlayThirdPlaceMatch) // Если нужен матч за 3-е место
                            {
                                match.Winners_MatchLabel = new MatchLabel(division_no, round + 1, (match_no - 1) / 2 + 1, match_no % 2 == 0 ? MatchLabel.PlayerLetters.B : MatchLabel.PlayerLetters.A);
                                match.Loosers_MatchLabel = new MatchLabel(division_no, round + 1, (match_no - 1) / 2 + 2, match_no % 2 == 0 ? MatchLabel.PlayerLetters.B : MatchLabel.PlayerLetters.A);
                            }
                            else
                            {
                                match.Winners_MatchLabel = new MatchLabel(division_no, round + 1, (match_no - 1) / 2 + 1, match_no % 2 == 0 ? MatchLabel.PlayerLetters.B : MatchLabel.PlayerLetters.A);
                                match.Loosers_MatchLabel = new MatchLabel(String.Format("{0:d2}-{1:d2}", match_count + 1, match_count * 2));
                            }
                            break;
                        default: // Остальные этапы
                            match.Winners_MatchLabel = new MatchLabel(division_no, round + 1, (match_no - 1) / 2 + 1, match_no % 2 == 0 ? MatchLabel.PlayerLetters.B : MatchLabel.PlayerLetters.A);
                            match.Loosers_MatchLabel = new MatchLabel(String.Format("{0:d2}-{1:d2}", match_count + 1, match_count * 2));
                            break;
                    }
                    TA.DB.Manager.DatabaseManager.CurrentDb.CreateMatch(Competition.Info.Id, match);
                    Competition.Matches.Add(match.Id, match);
                }
                round++;
                match_count = match_count / 2;
            }

            return false;
        }
        public bool SeedPlayers()
        {
            if (Competition == null)
                throw new Exception("Competition is not initialized");
            if (Competition.Info.Status != CompetitionInfo.CompetitionState.RegistrationAndSeeding)
                throw new Exception(Localizator.Dictionary.GetString("CANNOT_CREATE_MATCHES"));
            // Создать матчи для группового раунда
            CreateFirstRoundMatches();
            // Создать матчи для плей-офф
            CreateSecondRoundMatches();
            // Перезагружаем список матчей
            DatabaseManager.CurrentDb.ReadCompetitionMatchesList(Competition);
            return true;
        }

        public CompetitionPanel GetControl()
        {
            RobinOlympicPanel panel = new RobinOlympicPanel();
            panel.OpenCompetition(Competition);
            return panel;
        }

        public CompetitionParamsPanel GetParametersPanel()
        {
           return new RobinOlympicParamsPanel(FCompetition);
        }

        public int[] GetDrawOrder(int playerCount)
        {
            int group_count = FCompetition.GroupCount;
            int player_in_group = playerCount / group_count;
            if (playerCount % group_count != 0)
                player_in_group++;
            int[] order = new int[player_in_group * group_count];
            for (int i = 0; i < group_count; i++) 
            {
                for (int j = 0; j < player_in_group; j++) 
                {
                    order[i * player_in_group + j] = j * group_count + i + 1;
                }
            }
            return order;
        }
    }
}
