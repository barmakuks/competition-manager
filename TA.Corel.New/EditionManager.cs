using System;
using System.Collections.Generic;
using System.Text;

namespace TA.Corel
{
    public enum EditionType { Mini, Standard, FedEdition, StandardPlus, FedEditionPlus }
    public class EditionManager
    {
        public const string Version = " 1.1";
        private static bool isTrial = true;
        #region Edition Type
#if LIMITED
        private static EditionType FEdition = EditionType.Limited;
#endif
#if STANDARD_PLUS
        private static EditionType FEdition = EditionType.StandardPlus;
#endif
#if STANDARD
        private static EditionType FEdition = EditionType.Standard;
#endif
#if FEDITION_PLUS
        private static EditionType FEdition = EditionType.FedEditionPlus;
#endif
#if FEDITION
        private static EditionType FEdition = EditionType.FedEdition;
#endif
        #endregion
        public static string EditionString 
        {
            get {
                string beta = "";
#if BETA
                beta = " Beta";
#endif
                switch (FEdition) 
                {
                    case EditionType.Mini:
                        return "Mini Edition" + beta;
                    case EditionType.Standard:
                        return "Standard Edition" + beta;
                    case EditionType.StandardPlus:
                        return "Standard Plus Edition" + beta;
                    case EditionType.FedEdition:
                        return "Fed Edition" + beta;
                    case EditionType.FedEditionPlus:
                        return "Fed Plus Edition" + beta;
                }
                return "Trial version";
            }
        }
        //private static DateTime LicenseExpireDate;
        public static EditionType Edition 
        {
            get {
                return FEdition;
            }
        }
        
        public static int MaxPlayers 
        {
            get {
                if (IsTrial)
                    return 16;
                switch (FEdition) 
                {
                    case EditionType.Mini:
                        return 32;
                    case EditionType.Standard:
                    case EditionType.StandardPlus:
                        return 128;
                    case EditionType.FedEdition:
                    case EditionType.FedEditionPlus:
                        return 512;
                }
                return 16;
            }
        }
        public static int MaxTournamentCount 
        {
            get { 
#if BETA
                return 4;
#else
                if(IsTrial)
                    return 3;
                return Int32.MaxValue;
#endif
            }
        }
        public static int MaxCompetitionCount 
        {
            get
            {
#if BETA
                return 4;
#else
                if(IsTrial)
                    return 3;
                return Int32.MaxValue;
#endif
            }
        }

        public static bool IsTrial 
        {
            get { return isTrial; }
            set { isTrial = value; }
        }
    }
}
