using System;
using System.Collections.Generic;
using System.Text;

namespace TA.Corel
{
    /// <summary>
    /// Представление информации о соревновании в БД
    /// </summary>
    public class CompetitionInfo
    {
        private PropertiesList FProperties = new PropertiesList();
        public PropertiesList Properties
        {
            get
            {
                return FProperties;
            }
        }
        public enum CompetitionState { RegistrationAndSeeding, Playing, Finished };
        public int Id { get; set; }
        public int TournamentId { get; set; }
        /// <summary>
        /// Вид спорта
        /// </summary>
        public TypeOfSport SportType { get; set; }
        public bool ChangesRating { get; set; }
        public DateTime Date { get; set; }
        public int PlayerCount { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Тип сетки проведения матчей
        /// </summary>
        public CompetitionType CompetitionType { get; set; }
        public string CompetitionTypeName
        {
            get
            {
                return CompetitionType.Name;
            }
        }
        public CompetitionState Status { get; set; }
        public CompetitionInfo()
        {
            Id = -1;
            TournamentId = -1;
            ChangesRating = true;
            CompetitionType = CompetitionType.Empty;
            Name = "";
            PlayerCount = 0;
            Status = CompetitionState.RegistrationAndSeeding;
            SportType = new TypeOfSport();
        }
        public CompetitionInfo(CompetitionInfo copy)
        {
            Id = copy.Id;
            TournamentId = copy.TournamentId;
            SportType = copy.SportType;
            ChangesRating = copy.ChangesRating;
            Date = copy.Date;
            Name = copy.Name;
            CompetitionType = copy.CompetitionType;
            PlayerCount = copy.PlayerCount;
            Status = copy.Status;
        }
        public string StatusString
        {
            get
            {
                switch (Status)
                {
                    case CompetitionState.RegistrationAndSeeding:
                        return Localizator.Dictionary.GetString("REGISTRATION_AND_DRAW");
                    case CompetitionState.Playing:
                        return Localizator.Dictionary.GetString("IN_PROGRESS");
                    case CompetitionState.Finished:
                        return  Localizator.Dictionary.GetString("COMPLETED");
                    default:
                        return "";
                }
            }
        }
        public void Copy(CompetitionInfo copy)
        {
            Id = copy.Id;
            TournamentId = copy.TournamentId;
            SportType = copy.SportType;
            ChangesRating = copy.ChangesRating;
            Date = copy.Date;
            Name = copy.Name;
            CompetitionType = copy.CompetitionType;
            PlayerCount = copy.PlayerCount;
            Status = copy.Status;
        }
    }
}
