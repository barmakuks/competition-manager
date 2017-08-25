using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Corel;
using TA.Competitions;
using TA.Competitions.Forms;

namespace TA.CompetitionControllers
{
    class FppsSwissController : SwissController
    {
        private FppSwiss FCompetition = null;
        public override Competition Competition
        {
            get { return FCompetition; }
            set
            {
                if (value is FppSwiss)
                    FCompetition = value as FppSwiss;
            }
        }
        public override CompetitionPanel GetControl()
        {
            FipsSwissPanel panel = new FipsSwissPanel();
            panel.OpenCompetition(Competition);
            return panel;
        }
        public override CompetitionParamsPanel GetParametersPanel()
        {
            return new FipsSwissParamsPanel(FCompetition);
        }
        
        protected override MatchInfo CreateMatch(SeedPair players_pair)
        {
            MatchInfo match = base.CreateMatch(players_pair);
            return match;
        }

        private FppSwiss getSwissCompetition() 
        {
            return Competition as FppSwiss;
        }
        protected override List<CompetitionPlayerInfo> GetPlayersToSeed()
        {
            List<CompetitionPlayerInfo> players = base.GetPlayersToSeed();
            if (Competition.Matches.Count == 0)
            {
                if (!getSwissCompetition().AutoSetStartPoints)
                    players = Competition.PlayersResults;
            }
            List<CompetitionPlayerInfo> new_players = new List<CompetitionPlayerInfo>();
            foreach (CompetitionPlayerInfo player in players) 
            {
                //перед первым туром добавляем стартовые очки
                if (getSwissCompetition().AutoSetStartPoints && getSwissCompetition().Matches.Count == 0 && player.Id > 0)
                {
                    player.StartPoints = Competition.Info.Properties.GetInt32Value("StartPoints", 100);
                    TA.DB.Manager.DatabaseManager.CurrentDb.CompetitionPlayerInfoSave(player);
                }
                if (player.AvailablePoints > 0)
                    new_players.Add(player);
            }
            if (new_players.Count % 2 != 0)
                new_players.Add(CompetitionPlayerInfo.Dummy);
            return new_players;
        }
    }
}
