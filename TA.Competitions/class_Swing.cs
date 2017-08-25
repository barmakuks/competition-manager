using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TA.Corel;

namespace TA.Competitions
{
    public class Swing : FppSwiss
    {
        
        public Swing()
            : base() 
        {
            Info.CompetitionType = CompetitionType.Swing;
        }
        public override bool NeedsPlayersDrawing
        {
            get
            {
                if (!AutoSetStartPoints)
                    return false;
                return base.NeedsPlayersDrawing;
            }
        }
        
        public override CompetitionResultsBuilder CreateResultBuilder()
        {
            return  new SwingResultsBuilder(Players, Matches);
        }
        public string BetSequence{
            get
            {
                return Info.Properties.GetStringValue("BetSquence", "1,1,2,2,5,5,10,10,50");
            }
            set
            {
                Info.Properties["BetSquence"] = value;
            }
        }
        private int[] Parse(string seq) 
        {
            List<int> mas = new List<int>();
            int num = 0;
            for (int i = 0; i < seq.Length; i++)
            {
                string s = seq.Substring(i,1);
                if (s == ",")
                {
                    mas.Add(num);
                    num = 0;
                }
                else 
                {
                    int sign;
                    if (Int32.TryParse(s, out sign)) 
                    {
                        num = num * 10 + sign;
                    }
                }
            }
            if(num !=0)
                mas.Add(num);
            return mas.ToArray();
        }
        public int GetRoundMaxPoints(int round_no) 
        {
            int[] mas = Parse(BetSequence);
            if (mas.Length > 0 && round_no > 0) 
            {
                if (round_no <= mas.Length)
                    return mas[round_no - 1];
                else
                    return mas[mas.Length - 1];
            }
            return 50;
        }
        public override void UpdatePlayerInfo(CompetitionPlayerInfo player_info, PlayerResults player_results, int place)
        {
            player_info.Points = player_results.Points;
            player_info.Tag = (player_results as PlayerSwingResults).GetMatchCount();
            player_info.Place = place.ToString("D2");
            player_info.CurrentPlace = place;
        }
    }

    /// <summary>
    /// Текущие результаты игрока в Swing-турнире
    /// </summary>
    public class PlayerSwingResults : PlayerResults
    {
        public override string ToString()
        {
            return String.Format("{0} - Pts {1}", PlayerId, Points);
        }

        public override int ComparePlayerResults(PlayerResults other)
        {
            if (PlayerId == other.PlayerId)
                return 0;
            int res = other.AvailablePoints.CompareTo(AvailablePoints);
            if (res == 0)
                return (other as PlayerSwingResults).GetMatchCount().CompareTo(GetMatchCount());
            else 
                return res;
        }
        public int GetMatchCount()
        {
            int count = 0;
            foreach (List<MatchInfo> matches in this.Matches.Values)
            {
                count += matches.Count;
            }
            return count;
        }

    }
    /// <summary>
    /// Система подсчета мест занятых игроками в турнире
    /// </summary>
    public class SwingResultsBuilder : CompetitionResultsBuilder
    {
        public SwingResultsBuilder(CompetitionPlayerList players, MatchList matches)
            : base(players, matches)
        {
        }

        public override PlayerResults CreatePlayerResult()
        {
            return new PlayerSwingResults();
        }
    }


}
