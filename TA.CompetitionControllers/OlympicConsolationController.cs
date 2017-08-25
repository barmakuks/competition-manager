using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Corel;
using TA.DB.Manager;
using Sortition;
using TA.Competitions.Forms;
using TA.Competitions;

namespace TA.CompetitionControllers
{
    public class OlympicConsolationController : CompetitionController
    {
        private OlympicConsolation FCompetition = null;
        public virtual Competition Competition
        {
            get { return FCompetition; }
            set
            {
                if (value is OlympicConsolation)
                    FCompetition = value as OlympicConsolation;
            }
        }
        internal OlympicConsolationController()
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
            if (FCompetition is OlympicConsolation)
                return new OlympicConsolationParamsPanel(FCompetition);
            else return new CompetitionParamsPanel(FCompetition);
        }

        private void DeleteLoosersMatch(MatchList match_list, MatchLabel match_label)
        {
            MatchInfo match = match_list.GetMatchByLabel(match_label);
            if (match == null)
                return;
            // 1 - найти того, кто сюда посылает победителей из предыдущго тура
            MatchInfo prev = match_list.GetMatchByLabel(match_label.Division, match_label.Round - 1, match_label.MatchNo);            
            // 2 - переправить победителей дальше в следующий матч
            prev.Winners_MatchLabel = new MatchLabel(match.Winners_MatchLabel);
            prev.Winners_MatchLabel.Letter = match.Winners_MatchLabel.Letter;
            // 3 - удалить матч
            DatabaseManager.CurrentDb.DeleteMatch(match);
            // 4 - сохранить матч предыдущего тура
            DatabaseManager.CurrentDb.WriteMatch(prev);
        }
        public bool SeedPlayers()
        {
            if (Competition == null)
                throw new Exception("Competition is not initialized");
            if (Competition.Info.Status != CompetitionInfo.CompetitionState.RegistrationAndSeeding)
                throw new Exception(Localizator.Dictionary.GetString("CANNOT_CREATE_MATCHES"));

            if (DatabaseManager.CurrentDb.CreateMatches(Competition, 1)) // Формируем сетку как для Double Elimination
            {
                #region Рассеиваем игроков по верхней сетке
                DatabaseManager.CurrentDb.ReadCompetitionMatchesList(Competition);
                // получаем список игроков в порядке посева
                List<CompetitionPlayerInfo> players = Competition.Players.GetSortedList(CompetitionPlayerList.SortByField.SeedNo);
                if (players.Count > EditionManager.MaxPlayers)
                {
                    throw new Exception(Localizator.Dictionary.GetString("PLAYERS_LIMIT_OVER"));
                }
                // получаем сетку посева
                int[] sortition_grid = SortitionByRating.GetOlympicSortitionOrder(players.Count);
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
                int player_count = players.Count;

                int index_A = 0;
                int round_1_count = 0;
                int round_2_count = 0;
                foreach (MatchInfo match in Competition.Matches.Values)
                {
                    if (match.Label.Division == 1 && match.Label.Round > round_1_count)
                        round_1_count = match.Label.Round;
                    if (match.Label.Division == 2 && match.Label.Round > round_2_count)
                        round_2_count = match.Label.Round;

                    if (match.Label.Division == 1 && match.Label.Round == 1)
                    {
                        match.PlayerA.Id = Convert.ToInt32(sortition_order[index_A]);
                        match.PlayerB.Id = Convert.ToInt32(sortition_order[index_A + 1]);//players.Count - index_A - 1]);
                        index_A += 2;
                        match.UpdateNextMatches();
                        DatabaseManager.CurrentDb.WriteMatch(match);
                    }
                }
                #endregion

                #region Вносим изменения в сетку, для того, что бы сделать Consolation

                #region Удаление финального матча главного турнира
                
                MatchInfo last = Competition.Matches.GetMatchByLabel(1, round_1_count, 1);
                MatchInfo penult = Competition.Matches.GetMatchByLabel(1, round_1_count - 1, 1);

                DeleteLoosersMatch(Competition.Matches, penult.Loosers_MatchLabel);
                penult.Loosers_MatchLabel = new MatchLabel(last.Loosers_MatchLabel);
                penult.Winners_MatchLabel = new MatchLabel(last.Winners_MatchLabel);
                penult.Title = Localizator.Dictionary.GetString("FINAL");

                MatchInfo cons_winner = Competition.Matches.GetMatchByLabel(2, round_2_count - 1, 1);
                cons_winner.Title = Localizator.Dictionary.GetString("CONSOLATION_FINAL");
                cons_winner.Winners_MatchLabel = new MatchLabel(Localizator.Dictionary.GetString("CONSOLATION"," 01"));
                cons_winner.Loosers_MatchLabel = new MatchLabel(Localizator.Dictionary.GetString("CONSOLATION", " 02"));
                DatabaseManager.CurrentDb.DeleteMatch(last.Id);
                DatabaseManager.CurrentDb.WriteMatch(penult);
                DatabaseManager.CurrentDb.WriteMatch(cons_winner);
                round_1_count--; round_2_count--;// Уменьшаем количество рауднов
                #endregion

                #region Изменения вылета из верхней сетки для призеров

                int mainPrize = Competition.Info.Properties.GetInt32Value("MainPrizePlaces", 4) / 2;
                int round = round_1_count;
                int match_count = 2;
                while (mainPrize > 1) 
                {
                    round--;
                    for (int i = 1; i <= match_count; i++) 
                    {
                        MatchInfo match = Competition.Matches.GetMatchByLabel(1, round, i);
                        if (match != null)
                        {
                            DeleteLoosersMatch(Competition.Matches, match.Loosers_MatchLabel);
                            string place = String.Format("{0:D2}-{1:D2}", match_count + 1, match_count * 2);
                            match.Loosers_MatchLabel = new MatchLabel(place);
                            match.Title = String.Format("{0} {1}", TA.Utils.Utils.GetRoundLabelText(round_1_count - round + 1), i);
                            DatabaseManager.CurrentDb.WriteMatch(match);
                        }                         
                    }
                    mainPrize /= 2;
                    match_count *= 2;
                }
                #endregion

                #region Изменение вылета призеров утешительного турнира

                int consPrize = Competition.Info.Properties.GetInt32Value("ConsolationPrizePlaces", 2);
                if (consPrize > 2) 
                {
                    MatchInfo semifinalA = Competition.Matches.GetMatchByLabel(2, round_2_count - 2, 1);
                    if (semifinalA != null)
                    {
                        semifinalA.Title = Localizator.Dictionary.GetString("CONSOLATION_SEMI_A");
                        semifinalA.Loosers_MatchLabel = new MatchLabel(Localizator.Dictionary.GetString("CONSOLATION"," 03-04"));
                        DatabaseManager.CurrentDb.WriteMatch(semifinalA);
                    }
                    MatchInfo semifinalB = Competition.Matches.GetMatchByLabel(2, round_2_count - 2, 2);
                    if (semifinalB != null)
                    {
                        semifinalB.Title = Localizator.Dictionary.GetString("CONSOLATION_SEMI_B");
                        semifinalB.Loosers_MatchLabel = new MatchLabel(Localizator.Dictionary.GetString("CONSOLATION", " 03-04"));
                        DatabaseManager.CurrentDb.WriteMatch(semifinalB);
                    }

                }
                #endregion

                #endregion

                #region Добавляем матч за 3-е место
                if (Competition.Info.Properties.GetBooleanValue("ThirdPlaceMatch", false))
                {
                    // Изменяем место вылета для полуфиналистов
                    MatchInfo semifinalA = Competition.Matches.GetMatchByLabel(1, round_1_count - 1, 1);
                    MatchInfo semifinalB = Competition.Matches.GetMatchByLabel(1, round_1_count - 1, 2);
                    MatchInfo final = Competition.Matches.GetMatchByLabel(1, round_1_count, 1);
                    final.Title = Localizator.Dictionary.GetString("FINAL_MATCH");
                    DatabaseManager.CurrentDb.WriteMatch(final);
                    // Сформировать матч за 3-е место
                    MatchInfo thirdPlaceMatch = new MatchInfo();
                    thirdPlaceMatch.Title = Localizator.Dictionary.GetString("3_PLACE_MATCH");
                    thirdPlaceMatch.Label = new MatchLabel(1, round_1_count, 2);
                    thirdPlaceMatch.Loosers_MatchLabel.Place = "04";
                    thirdPlaceMatch.Winners_MatchLabel.Place = "03";
                    
                    if (semifinalA != null) 
                    {
                        DeleteLoosersMatch(Competition.Matches, semifinalA.Loosers_MatchLabel);
                        semifinalA.Loosers_MatchLabel = new MatchLabel(thirdPlaceMatch.Label);
                        semifinalA.Loosers_MatchLabel.Letter = MatchLabel.PlayerLetters.A;
                        DatabaseManager.CurrentDb.WriteMatch(semifinalA);
                    }
                    if (semifinalB != null) 
                    {
                        DeleteLoosersMatch(Competition.Matches, semifinalB.Loosers_MatchLabel);
                        semifinalB.Loosers_MatchLabel = new MatchLabel(thirdPlaceMatch.Label);
                        semifinalB.Loosers_MatchLabel.Letter = MatchLabel.PlayerLetters.B;
                        DatabaseManager.CurrentDb.WriteMatch(semifinalB);
                    }
                    DatabaseManager.CurrentDb.CreateMatch(Competition.Info.Id, thirdPlaceMatch);
                }
                #endregion
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
