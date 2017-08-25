using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Corel;
using TA.DB.Manager;
using Sortition;
using TA.Competitions.Forms;
using TA.Competitions;
using System.Windows.Forms;

namespace TA.CompetitionControllers
{
    public class OlympicController : CompetitionController
    {
        private Olympic FCompetition = null;
        public virtual Competition Competition
        {
            get { return FCompetition; }
            set
            {
                if (value is Olympic)
                    FCompetition = value as Olympic;
            }
        }
        internal OlympicController()
            : base()
        {
        }

        public CompetitionPanel GetControl()
        {
            OlympicPanel panel = new OlympicPanel();
            panel.OpenCompetition(Competition);
            return panel;
        }
        public CompetitionParamsPanel GetParametersPanel() 
        {
            if (FCompetition is Olympic)
                return new OlympicParamsPanel(FCompetition);
            else return new CompetitionParamsPanel(FCompetition);                
        }

        public bool SeedPlayers()
        {
            if (Competition == null)
                throw new Exception("Competition is not initialized");
            if (Competition.Info.Status != CompetitionInfo.CompetitionState.RegistrationAndSeeding)
                throw new Exception(Localizator.Dictionary.GetString("CANNOT_CREATE_MATCHES"));

            if (DatabaseManager.CurrentDb.CreateMatches(Competition, Competition.Info.CompetitionType.Id))
            {
                DatabaseManager.CurrentDb.ReadCompetitionMatchesList(Competition);
                // получаем список игроков в порядке посева
                List<CompetitionPlayerInfo> players = Competition.Players.GetSortedList(CompetitionPlayerList.SortByField.SeedNo);
                if (players.Count > EditionManager.MaxPlayers)
                {
                    throw new Exception(Localizator.Dictionary.GetString("PLAYERS_LIMIT_OVER"));
                }
                // получаем сетку посева
                int[] sortition_grid = GetDrawOrder(players.Count);
                int[] sortition_order = new int[sortition_grid.Length];
                sortition_order.Initialize();
                // В сетке посева заменяем номер посева на соответствующий ему Id игрока, 
                // если игроков меньше, чем мест в посеве, то оставшиеся места занимают баи (Id = 0)
                foreach (CompetitionPlayerInfo player in players) 
                {
                    int seed_no = player.SeedNo;
                    for (int i = 0; i < sortition_grid.Length; i++) 
                    {
                        if (sortition_grid[i] == seed_no)
                            sortition_order[i] = player.Id;
                    }
                }
                /*for (int i = 0; i < sortition_order.Length; i++)
                {
                    if (sortition_order[i] <= players.Count)
                        sortition_order[i] = (players[sortition_order[i] - 1] as CompetitionPlayerInfo).Id;
                    else
                        sortition_order[i] = 0;
                }*/

                int player_count = players.Count;

                int index_A = 0;
                int round_count = 0;
                foreach (MatchInfo match in Competition.Matches.Values)
                {
                    if(match.Label.Round > round_count)
                        round_count = match.Label.Round;
                    if (match.Label.Division == 1 && match.Label.Round == 1)
                    {
                        match.PlayerA.Id = Convert.ToInt32(sortition_order[index_A]);
                        match.PlayerB.Id = Convert.ToInt32(sortition_order[index_A + 1]);//players.Count - index_A - 1]);
                        index_A += 2;
                        match.UpdateNextMatches();
                        DatabaseManager.CurrentDb.WriteMatch(match);
                    }
                }

                if ((Competition as Olympic).PlayThirdPlaceMatch) 
                {
                    // Изменяем место вылета для полуфиналистов
                    MatchInfo semifinalA = Competition.Matches.GetMatchByLabel(1, round_count - 1, 1);
                    MatchInfo semifinalB = Competition.Matches.GetMatchByLabel(1, round_count - 1, 2);
                    MatchInfo final = Competition.Matches.GetMatchByLabel(1, round_count, 1);
                    final.Title = Localizator.Dictionary.GetString("FINAL_MATCH");
                    DatabaseManager.CurrentDb.WriteMatch(final);
                    // Сформировать матч за 3-е место
                    MatchInfo thirdPlaceMatch = new MatchInfo();
                    thirdPlaceMatch.Title = Localizator.Dictionary.GetString("3_PLACE_MATCH");
                    thirdPlaceMatch.Label = new MatchLabel(1, round_count, 2);
                    thirdPlaceMatch.Loosers_MatchLabel.Place = "04";
                    thirdPlaceMatch.Winners_MatchLabel.Place = "03";

                    semifinalA.Loosers_MatchLabel = new MatchLabel(thirdPlaceMatch.Label);
                    semifinalA.Loosers_MatchLabel.Letter = MatchLabel.PlayerLetters.A;
                    semifinalB.Loosers_MatchLabel = new MatchLabel(thirdPlaceMatch.Label); 
                    semifinalB.Loosers_MatchLabel.Letter = MatchLabel.PlayerLetters.B;

                    DatabaseManager.CurrentDb.WriteMatch(semifinalA);
                    DatabaseManager.CurrentDb.WriteMatch(semifinalB);
                    TA.DB.Manager.DatabaseManager.CurrentDb.CreateMatch(Competition.Info.Id, thirdPlaceMatch);
                }
                DatabaseManager.CurrentDb.ReadCompetitionMatchesList(Competition);
                return true;
            }
            return false;
        }

        public int[] GetDrawOrder(int playerCount)
        {
            return SortitionByRating.GetOlympicSortitionOrder(playerCount);
        }
    }
}
