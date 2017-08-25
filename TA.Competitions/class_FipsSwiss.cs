using System;
using System.Collections.Generic;
using System.Text;
using TA.Corel;

namespace TA.Competitions
{
    public class FppSwiss : Swiss
    {
        public FppSwiss() : base() 
        {
            Info.CompetitionType = CompetitionType.FppSwiss;
        }
        public int StartPoints
        {
            get{
                return Info.Properties.GetInt32Value("StartPoints", 100);
            }
            set{
                Info.Properties["StartPoints"] = value.ToString();
            }            
        }
        public bool AutoSetStartPoints
        {
            get
            {
                return Info.Properties.GetBooleanValue("AutoSetStartPoints", false);
            }
            set
            {
                Info.Properties["AutoSetStartPoints"] = value.ToString();
            }
        }
        public int LateStartPoints 
        {
            get
            {
                return Info.Properties.GetInt32Value("LateStartPoints", StartPoints);
            }
            set
            {
                Info.Properties["LateStartPoints"] = value.ToString();
            }
        }
        public bool AllowRebuy 
        {
            get{
                return Info.Properties.GetBooleanValue("AllowRebuy", false);
            }
            set{
                Info.Properties["AllowRebuy"] = value.ToString();
            }            
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
    }
}
