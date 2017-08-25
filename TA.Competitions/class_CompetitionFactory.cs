using System;
using System.Collections.Generic;
using System.Text;
using TA.Corel;

namespace TA.Competitions
{
    public class CompetitionFactory
    {
        public static Competition CreateCompetition(CompetitionType competitionType) 
        {
            if (competitionType.Equals(CompetitionType.OlympicDE)) 
                    return new OlympicDE();
            if (competitionType.Equals(CompetitionType.Olympic)) 
                    return new Olympic();
            if (competitionType.Equals(CompetitionType.Swiss)) 
                    return new Swiss();
            if (competitionType.Equals(CompetitionType.FppSwiss)) 
                    return new FppSwiss();
            if (competitionType.Equals(CompetitionType.Robin))
                return new Robin();
            if (competitionType.Equals(CompetitionType.OlympicConsolation))
                return new OlympicConsolation();
            if (competitionType.Equals(CompetitionType.RobinOlympic))
                return new RobinOlympic();
            if (competitionType.Equals(CompetitionType.Swing))
                return new Swing();
            return null;
        }
        public static Competition CreateCompetition(CompetitionInfo info)
        {
            Competition Comp = CreateCompetition(info.CompetitionType);
            Comp.Info.Copy(info);
            return Comp;
        }
        public static Competition FromXmlString(string xmlString) 
        {
            throw new NotImplementedException();
        }
    }
}
