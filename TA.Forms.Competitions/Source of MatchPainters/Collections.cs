using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Competitions.Forms
{
    internal class MatchPaintersList : Dictionary<int, MatchPainter> 
    {
    }
    internal class BrokenLinesList :  List<BrokenLine>
    {
    }
    internal class RoundLabelsList : List<RoundLabel> 
    {
    }

    internal class OlympicPaintersGroup 
    {
        private MatchPaintersList FMatchPainters = new MatchPaintersList();
        private BrokenLinesList FBrokenLinePainters = new BrokenLinesList();
        private RoundLabelsList FRoundLabels = new RoundLabelsList();

        public MatchPaintersList MatchPainters {get{return FMatchPainters;}}
        public BrokenLinesList BrokenLinePainters { get { return FBrokenLinePainters; } }
        public RoundLabelsList RoundLabels { get { return FRoundLabels; } }
    }

    internal class GroupPaintersList : Dictionary<int, GroupPainter> 
    {
    }
    internal class GroupPaintersGroup : OlympicPaintersGroup
    {
        private GroupPaintersList FGroupPainters = new GroupPaintersList();
        public GroupPaintersList GroupPainters { get { return FGroupPainters; } }
    }
}
