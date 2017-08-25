using System;
using System.Collections.Generic;
using System.Text;

namespace TA.Corel
{
    /// <summary>
    /// Описание типа проведения соревнований
    /// </summary>
    public class CompetitionType
    {
        /// <summary>
        /// Идентификатор типа проведения соревнований
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование типа проведения соревнований
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание типа проведения соревнований
        /// </summary>
        public string Description { get; set; }
        public CompetitionType()
        {
            Id = -1; Name = Description = "";
        }
        public CompetitionType(CompetitionType copy)
        {
            Id = copy.Id;
            Name = copy.Name;
            Description = copy.Description;
        }
        public override string ToString()
        {
            return Name;
        }
        public CompetitionType(int id, string name, string description)
        {
            Id = id; Name = name; Description = description;
        }
        public override bool Equals(object obj)
        {
            if (obj is CompetitionType)
                return Id.Equals((obj as CompetitionType).Id); ;
            return false;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public bool CanChangeRating 
        {
            get {
                if (Id == 4)
                    return false;
                return true;
            }
        }

        public static CompetitionType Empty
        {
            get
            {
                return new CompetitionType();
            }
        }
        public static CompetitionType OlympicDE
        {
            get
            {
                string name = Localizator.Dictionary.GetString("DOUBLE_ELIMINATION");
                string description = Localizator.Dictionary.GetString("DE_DESCRIPTION");
                return new CompetitionType(1, name, description);
            }
        }
        public static CompetitionType Olympic
        {
            get
            {
                string name = Localizator.Dictionary.GetString("KO");
                string description = Localizator.Dictionary.GetString("KO_DESCRIPTION"); 
                return new CompetitionType(2, name, description);
            }
        }
        public static CompetitionType Swiss
        {
            get
            {
                string name = Localizator.Dictionary.GetString("SWISS");
                string description = Localizator.Dictionary.GetString("SWISS_DESCRIPTION"); 
                return new CompetitionType(3, name, description);
            }
        }
        public static CompetitionType FppSwiss
        {
            get
            {
                string name = Localizator.Dictionary.GetString("FPP");
                string description = Localizator.Dictionary.GetString("FPP_DESCRIPTION"); 
                return new CompetitionType(4, name, description);
            }
        }
        public static CompetitionType Robin 
        {
            get {
                string name = Localizator.Dictionary.GetString("ROBIN");
                string description = Localizator.Dictionary.GetString("ROBIN_DESCRIPTION"); 
                return new CompetitionType(5, name, description);
            }
        }
        public static CompetitionType OlympicConsolation 
        {
            get
            {
                string name = Localizator.Dictionary.GetString("KO_CONSOLATION");
                string description = Localizator.Dictionary.GetString("KO_CONSLATION_DESCRIPTION"); 
                return new CompetitionType(6, name, description);
            }
        }
        public static CompetitionType RobinOlympic
        {
            get
            {
                string name = Localizator.Dictionary.GetString("ROBIN_KO");
                string description = Localizator.Dictionary.GetString("ROBIN_KO_DESCRIPTION"); 
                return new CompetitionType(7, name, description);
            }
        }
        public static CompetitionType Swing 
        {
            get {
                string name = Localizator.Dictionary.GetString("SWING");
                string description = Localizator.Dictionary.GetString("SWING_DESCRIPTION");
                return new CompetitionType(8, name, description);
            }
        }

        public static Dictionary<int, CompetitionType> TypeList
        {
            get
            {
                Dictionary<int, CompetitionType> types = new Dictionary<int, CompetitionType>();
                types.Add(Olympic.Id, Olympic);
                types.Add(OlympicDE.Id, OlympicDE);
                types.Add(Swiss.Id, Swiss);
                types.Add(Robin.Id, Robin);
                types.Add(FppSwiss.Id, FppSwiss);
                types.Add(OlympicConsolation.Id, OlympicConsolation);
                types.Add(RobinOlympic.Id, RobinOlympic);
                types.Add(Swing.Id, Swing);
                return types;
            }
        }

    }
}
