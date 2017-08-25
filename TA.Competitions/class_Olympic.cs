using System;
using System.Collections.Generic;
using System.Text;
using TA.Corel;

namespace TA.Competitions
{
    public class Olympic : TA.Corel.Competition
    {
        public Olympic() : base()
        {
            Info.CompetitionType = CompetitionType.Olympic;
        }
        public override void InitializeMatches()
        {
            foreach (MatchInfo match in Matches.Values)
            {
                if (!match.Loosers_MatchLabel.IsEmpty)
                    match.Looser_Match = Matches.GetMatchByLabel(match.Loosers_MatchLabel);
                else
                    match.Looser_Match = null;
                if (!match.Winners_MatchLabel.IsEmpty)
                    match.Winner_Match = Matches.GetMatchByLabel(match.Winners_MatchLabel);
                else
                    match.Winner_Match = null;
            }
            foreach (MatchInfo match in Matches.Values)
            {
                match.UpdateNextMatches();
            }
        }
        public override bool CanFinishRegistration
        {
            get {
                return Info.Status == CompetitionInfo.CompetitionState.RegistrationAndSeeding && Players.Count >= 4;
            }
        }
        public bool PlayThirdPlaceMatch
        {
            get { return Info.Properties.GetBooleanValue("ThirdPlaceMatch", false); }
            set { Info.Properties["ThirdPlaceMatch"] = value.ToString(); }
        }

        public override int[] GetSeedOrder()
        {
            return Sortition.SortitionByRating.GetOlympicSortitionOrder(Players.Count);
        }
        public override List<CompetitionPlayerInfo> PlayersPlaces
        {
            get
            {
                /*List<CompetitionPlayerInfo> results = new List<CompetitionPlayerInfo>();
                foreach(CompetitionPlayerInfo player in base.PlayersResults)
                {
                    if(player.Place.IsNull)
                        results.Add(player);
                }                
                return results;*/
                return base.PlayersResults;
            }
        }
    }
}
