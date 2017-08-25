using System;
using System.Collections.Generic;
using System.Text;
using TA.Corel;

namespace TA.Competitions
{
    public class OlympicDE : Olympic
    {
        public OlympicDE() : base()
        {
            Info.CompetitionType = CompetitionType.OlympicDE;
        }
        public override void InitializeMatches()
        {
            foreach (MatchInfo match in Matches.Values)
            {
                if (!match.Loosers_MatchLabel.IsEmpty)
                    match.Looser_Match = Matches.GetMatchByLabel(match.Loosers_MatchLabel);
                if (!match.Winners_MatchLabel.IsEmpty)
                    match.Winner_Match = Matches.GetMatchByLabel(match.Winners_MatchLabel);
            }
            foreach (MatchInfo match in Matches.Values)
            {
                match.UpdateNextMatches();
            }
        }
    }
}
