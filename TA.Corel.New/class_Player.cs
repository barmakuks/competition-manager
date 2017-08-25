using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using TA.Utils;

namespace TA.Corel
{
    /// <summary>
    /// Представление игрока в БД
    /// </summary>
    public class PlayerInfo
    {
        public int Id { get; set; }
        public Guid Identifier { get; set; }
        public string FirstName { get; set; }
        public string PatronymicName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName + " " + PatronymicName;
            }
        }
        public string ShortName
        {
            get
            {
                if (NickName != "")
                    return NickName;
                string initials = "";
                if (FirstName != "")
                {
                    initials = " " + FirstName.Substring(0, 1) + ".";
                    if (PatronymicName != "")
                        initials = initials + PatronymicName.Substring(0, 1) + ".";
                }
                return LastName + initials;
            }
        }
        public override string ToString()
        {
            return ShortName;
        }

        public string EMail { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public PlayerInfo()
        {
            Id = -1;
            Identifier = Guid.Empty;
            FirstName = PatronymicName = LastName = NickName = EMail = Phone = Country = City = "";
        }
        public PlayerInfo(PlayerInfo copy)
        {
            Id = copy.Id;
            Identifier = copy.Identifier;
            FirstName = copy.FirstName;
            PatronymicName = copy.PatronymicName;
            LastName = copy.LastName;
            NickName = copy.NickName;
            EMail = copy.EMail;
            Phone = copy.Phone;
            Country = copy.Country;
            City = copy.City;
        }
        /// <summary>
        /// Ник игрока-пустышки
        /// </summary>
        public static string DummyName
        {
            get
            {
                return Localizator.Dictionary.GetString("NO_OPPONENT");
            }
        }
        /// <summary>
        /// Id игрока-пустышки
        /// </summary>
        public static int DummyId {
            get {
                return 0;
            }
        }

    }

    /// <summary>
    /// Представление игрока - участника соревнования
    /// </summary>
    public class CompetitionPlayerInfo : PlayerInfo 
    {
        public int CompetitionId { get; set; }
        /// <summary>
        /// Рейтинг перед началом турнира
        /// </summary>
        public int RatingBeforeCompetition { get; set; }
        /// <summary>
        /// Изменение рейтинга
        /// </summary>
        public int RatingDelta { get; set; }
        /// <summary>
        /// Номер посева
        /// </summary>
        public int SeedNo { get; set; }
        /// <summary>
        /// Итоговое занятое место
        /// </summary>
        public StringAlt Place { get; set; }

        /// <summary>
        /// Текущее место (вычисляется при расчете результата, в БД не сохраняется)
        /// </summary>
        public int CurrentPlace { get; set; }

        /// <summary>
        /// Количество стартовых очков
        /// </summary>
        public int StartPoints { get; set; }
        /// <summary>
        /// Количество набранных очков
        /// </summary>
        public int Points { get; set; }
        /// <summary>
        /// Итоговое количество очков (Start + набранные)
        /// </summary>
        public int TotalPoints { get { return StartPoints + Points; } }
        /// <summary>
        /// Количество дополнительно приобретенных очков
        /// </summary>
        public int RebuyPoints { get; set; }
        /// <summary>
        /// Количество всех доступных очков (в том числе RebuyPoints)
        /// </summary>
        public int AvailablePoints { get { return TotalPoints + RebuyPoints; } }
        /// <summary>
        /// Есть ли матчи у данного игрока
        /// </summary>
        public bool HasMatches { get; set; }

        /// <summary>
        /// Дополнительное поле
        /// </summary>
        public int Tag { get; set; }

        public CompetitionPlayerInfo()
            : base()
        {
            CompetitionId = -1;
            RatingBeforeCompetition = 0;
            RatingDelta = 0;
            SeedNo = 0;
            Place = new StringAlt("");
            HasMatches = false;
        }
        public CompetitionPlayerInfo(CompetitionPlayerInfo copy)
            : base(copy)
        {
            CompetitionId = copy.CompetitionId;
            RatingBeforeCompetition = copy.RatingBeforeCompetition;
            RatingDelta = copy.RatingDelta;
            SeedNo = copy.SeedNo;
            Place = copy.Place;
            HasMatches = copy.HasMatches;
        }
        public CompetitionPlayerInfo(PlayerInfo copy)
            : base(copy)
        {
        }

        public string XmlString(bool shortInfo) 
        {
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement("player");

            XmlAttribute attr = doc.CreateAttribute("guid"); attr.Value = Identifier.ToString(); root.Attributes.Append(attr);
            attr = doc.CreateAttribute("id"); attr.Value = Id.ToString(); root.Attributes.Append(attr);
            attr = doc.CreateAttribute("nickname"); attr.Value = NickName; root.Attributes.Append(attr);
            if (!shortInfo) 
            {
                attr = doc.CreateAttribute("firstname"); attr.Value = FirstName; root.Attributes.Append(attr);
                attr = doc.CreateAttribute("patronymicname"); attr.Value = PatronymicName; root.Attributes.Append(attr);
                attr = doc.CreateAttribute("lastname"); attr.Value = LastName; root.Attributes.Append(attr);
                attr = doc.CreateAttribute("country"); attr.Value = Country; root.Attributes.Append(attr);
                attr = doc.CreateAttribute("city"); attr.Value = City; root.Attributes.Append(attr);
                attr = doc.CreateAttribute("phone"); attr.Value = Phone; root.Attributes.Append(attr);
                attr = doc.CreateAttribute("email"); attr.Value = EMail; root.Attributes.Append(attr);
                attr = doc.CreateAttribute("startrating"); attr.Value = RatingBeforeCompetition.ToString(); root.Attributes.Append(attr);
                attr = doc.CreateAttribute("seedno"); attr.Value = SeedNo.ToString(); root.Attributes.Append(attr);
                attr = doc.CreateAttribute("place"); attr.Value = Place; root.Attributes.Append(attr);
            }
            doc.AppendChild(root);
            return doc.OuterXml;
        }

        public string XmlString()
        {
            return XmlString(false);
        }

        /// <summary>
        /// Вымышленный игрок, пустышка, бай
        /// </summary>
        public static CompetitionPlayerInfo Dummy
        {
            get{
                CompetitionPlayerInfo dummy = new CompetitionPlayerInfo();
                dummy.Id = 0; dummy.NickName = PlayerInfo.DummyName;
                return dummy;
            }
        }
    }

    /// <summary>
    /// Представление игрока в матче
    /// </summary>
    public class MatchPlayer
    {
        private int id = -1;
        private string label = "";
        private Guid guid = Guid.Empty;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                if (id == PlayerInfo.DummyId)
                    Name = PlayerInfo.DummyName;
            }
        }
        public string Name = "";
        public Guid Guid 
        {
            get {
                if (Id == PlayerInfo.DummyId)
                    return Guid.Empty;
                return guid;
            }
            set {
                guid = value;
            }
        }
        public string Label
        {
            get
            {
                if (id == PlayerInfo.DummyId)
                    return PlayerInfo.DummyName;
                if (id < 0)
                    return label;
                return Name;
            }
            set
            {
                label = value;
            }
        }

        public int Points = 0;
        public int Tag = 0;        
        public void Copy(MatchPlayer aCopy)
        {
            if (aCopy != null)
            {
                Name = aCopy.Name;
                Id = aCopy.Id;
            }
            else
            {
                Id = -1;
                Name = "";
            }
        }
        public override string ToString()
        {
            return String.Format("{0}:{1}", Id, Name);
        }
    }


    public class ComparePlayerByName : IComparer<CompetitionPlayerInfo>
    {
        bool Ascending = true;
        public ComparePlayerByName(bool asc) : base() 
        {
            Ascending = asc;
        }
        public int Compare(CompetitionPlayerInfo x, CompetitionPlayerInfo y)
        {
            if(Ascending)
                return x.NickName.CompareTo(y.NickName);
            else
                return y.NickName.CompareTo(x.NickName);
        }
    }
    public class ComparePlayerByRating : IComparer<CompetitionPlayerInfo>
    {
        bool Ascending = true;
        public ComparePlayerByRating(bool asc) : base() 
        {
            Ascending = asc;
        }
        public int Compare(CompetitionPlayerInfo x, CompetitionPlayerInfo y)
        {
            if (Ascending)
                return x.RatingBeforeCompetition.CompareTo(y.RatingBeforeCompetition);
            else
                return y.RatingBeforeCompetition.CompareTo(x.RatingBeforeCompetition);
        }
    }
    public class ComparePlayerBySeedNo : IComparer<CompetitionPlayerInfo>
    {
        bool Ascending = true;
        public ComparePlayerBySeedNo(bool asc) : base() 
        {
            Ascending = asc;
        }
        public int Compare(CompetitionPlayerInfo x, CompetitionPlayerInfo y)
        {
            if (Ascending)
                return x.SeedNo.CompareTo(y.SeedNo);
            else
                return y.SeedNo.CompareTo(x.SeedNo);
        }
    }
    public class ComparePlayerByPlace : IComparer<CompetitionPlayerInfo>
    {
        bool Ascending = true;
        public ComparePlayerByPlace(bool asc)
            : base() 
        {
            Ascending = asc;
        }
        public int Compare(CompetitionPlayerInfo x, CompetitionPlayerInfo y)
        {
            if (x.Place == null)
                x.Place = "";
            if (y.Place == null)
                y.Place = "";
            if (x.Place == "" && y.Place != "")
                return 1;
            if (x.Place != "" && y.Place == "")
                return -1;
            if (x.Place == "" && y.Place == "")
                return 0;
            if (Ascending)
                return x.Place.CompareTo(y.Place);
            else
                return y.Place.CompareTo(x.Place);
        }
    }

}
