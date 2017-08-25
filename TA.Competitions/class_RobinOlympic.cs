using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Corel;

namespace TA.Competitions
{
    public class RobinOlympic : Competition
    {
        public RobinOlympic() : base() 
        {
            Info.CompetitionType = CompetitionType.RobinOlympic;
        }
        public int GroupCount
        {
            get{return Info.Properties.GetInt32Value("GroupCount",2);}
            set { Info.Properties["GroupCount"] = value.ToString();}
        }
        public int KOPlayerCount 
        {
            get { return Info.Properties.GetInt32Value("KOPlayerCount", 4); }
            set { Info.Properties["KOPlayerCount"] = value.ToString(); }
        }
        public bool PlayThirdPlaceMatch 
        {
            get { return Info.Properties.GetBooleanValue("ThirdPlaceMatch", false); }
            set { Info.Properties["ThirdPlaceMatch"] = value.ToString(); }
        }

        public Dictionary<int, GroupRobin> Groups = new Dictionary<int, GroupRobin>();
        public override void InitializeMatches()
        {            
            GroupRobin group = null; 
            Groups.Clear();
            foreach (MatchInfo match in Matches.Values)
            {
                if(match.Label.Division > GroupCount)
                {
                    // Формируем сетку для плей-офф
                    if (!match.Loosers_MatchLabel.IsEmpty)
                        match.Looser_Match = Matches.GetMatchByLabel(match.Loosers_MatchLabel);
                    else
                        match.Looser_Match = null;
                    if (!match.Winners_MatchLabel.IsEmpty)
                        match.Winner_Match = Matches.GetMatchByLabel(match.Winners_MatchLabel);
                    else
                        match.Winner_Match = null;
                }
                if (group == null || group.GroupNo != match.Label.Division) 
                {
                    if (match.Label.Division <= GroupCount)
                        group = new GroupRobin(match.Label.Division);
                    else
                        group = new GroupOlympic(match.Label.Division);
                    Groups.Add(group.GroupNo, group);
                }
                group.Matches.Add(match.Id, match);
                group.AddPlayer(match.PlayerA);
                group.AddPlayer(match.PlayerB);
            }
            foreach (MatchInfo match in Matches.Values)
            {
                match.UpdateNextMatches();
            }
        }

        public override bool CanFinishRegistration
        {
            get
            {
                bool is_registration = Info.Status == CompetitionInfo.CompetitionState.RegistrationAndSeeding;
                return is_registration && Players.Count >= 4;
            }
        }

        public override int[] GetSeedOrder()
        {
            //return Sortition.SortitionByRating.GetOlympicSortitionOrder(Players.Count);
            throw new NotImplementedException();
        }

        public override bool CheckCompetitionParams(ref string error)
        {
            if(Players.Count < KOPlayerCount)
            {
                error = Localizator.Dictionary.GetString("TOO_FEW_PLAYERS");
                return false;
            }
            return base.CheckCompetitionParams(ref error);
            
        }
        public override bool NeedsPlayersDrawing
        {
            get
            {
                return true;
            }
        }
    }

    public class GroupRobin 
    {
        private MatchList FMatches = new MatchList();
        private Dictionary<int,MatchPlayer> FPlayers = new Dictionary<int,MatchPlayer>();
        
        public int GroupNo;
        public GroupRobin(int groupNo)
        {
            GroupNo = groupNo;
        }
        
        public MatchList Matches {get { return FMatches; }}
        public Dictionary<int,MatchPlayer> Players { get { return FPlayers; } }
        public bool AllMatchesOver 
        {
            get {
                foreach (MatchInfo match in Matches.Values) 
                {
                    if (!match.IsOver)
                        return false;
                }
                return true;
            }
        }
        public void AddPlayer(MatchPlayer player) 
        {
            if (player.Id > 0) 
            {
                if (!Players.ContainsKey(player.Id)) 
                {
                    Players.Add(player.Id, player);
                }
            }
        }
    }
    public class GroupOlympic : GroupRobin 
    {
        public GroupOlympic(int roundNo) : base(roundNo) { }
    }
}
