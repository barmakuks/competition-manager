using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Corel;
using TA.Competitions;


namespace TA.CompetitionControllers
{
    public class CompetitionControllers
    {
        public static CompetitionController GetController(TA.Corel.Competition competition) 
        {
            //Нужно следить за порядком сравнения типов, из-за возможного наследования
            // сначала проверяем потомков, а потом остальные
            if (competition.GetType() == typeof(RobinOlympic)) 
            {
                RobinOlympicController ctrl = new RobinOlympicController();
                ctrl.Competition = competition;
                return ctrl;
            }
            if (competition.GetType() == typeof(OlympicConsolation))
            {
                OlympicConsolationController ctrl = new OlympicConsolationController();
                ctrl.Competition = competition;
                return ctrl;
            }
            if (competition.GetType() == typeof(OlympicDE)) 
            {
                CompetitionController ctrl = new OlympicDEController();
                ctrl.Competition = competition;
                return ctrl;
            }
            if (competition.GetType() == typeof(Olympic)) 
            {
                CompetitionController ctrl = new OlympicController();
                ctrl.Competition = competition;
                return ctrl;
            }
            if (competition.GetType() == typeof(FppSwiss))
            {
                FppsSwissController ctrl = new FppsSwissController();
                ctrl.Competition = competition;
                return ctrl;
            }
            if (competition.GetType() == typeof(Swiss) )
            {
                SwissController ctrl = new SwissController();
                ctrl.Competition = competition;
                return ctrl;
            }
            if (competition.GetType() == typeof(Robin))
            {
                RobinController ctrl = new RobinController();
                ctrl.Competition = competition;
                return ctrl;
            }
            if (competition.GetType() == typeof(Swing))
            {
                SwingController ctrl = new SwingController();
                ctrl.Competition = competition;
                return ctrl;
            }
            throw new Exception("Unknown Competition Controller");
        }
    }
}
