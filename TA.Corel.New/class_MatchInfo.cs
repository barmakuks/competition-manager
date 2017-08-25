using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TA.Corel
{
    /// <summary>
    /// Отклик на изменение параметров матча
    /// </summary>
    public delegate void OnMatchEvent();

    /// <summary>
    /// Метка, идентифицирующая матч в сетке соревнования
    /// </summary>
    public class MatchLabel 
    {
        public int Division = 0;
        public int Round = 0;
        public int MatchNo = 0;
        public enum PlayerLetters { Unknown, A, B, Draw };
        public PlayerLetters Letter = PlayerLetters.Unknown;
        public string Place = "";

        public MatchLabel() { }
        public MatchLabel(string place) 
        {
            Place = place;
        }
        public MatchLabel(int div, int round, int matchNo) 
        {
            Division = div; Round = round; MatchNo = matchNo;
        }
        public MatchLabel(int div, int round, int matchNo, PlayerLetters letter) :
            this(div,round,matchNo)
        {
            Letter = letter;
        }
        public MatchLabel(MatchLabel copy) 
        {
            Division = copy.Division;
            Round = copy.Round;
            MatchNo = copy.MatchNo;
            Place = copy.Place;
        }
        public override string ToString()
        {
            if (IsEmpty)
                return Place;
            switch (Letter)
            {
                case PlayerLetters.A:
                    return String.Format("{0:D1}.{1:D2}.{2:D3}.A", Division, Round, MatchNo);
                case PlayerLetters.B:
                    return String.Format("{0:D1}.{1:D2}.{2:D3}.B", Division, Round, MatchNo);
                default:
                    return String.Format("{0:D1}.{1:D2}.{2:D3}", Division, Round, MatchNo);
            }
        }
        public string Label
        {
            get
            {
                if (IsEmpty && Place != "")
                    return "PLACE " + Place;
                return ToString();
            }
            set
            {
                try
                {
                    if (value.IndexOf("PLACE") != -1)
                    {
                        Division = Round = MatchNo = 0;
                        Place = value.Substring(6);
                    }
                    else
                    {
                        if (value.Trim() != "")
                        {
                            Place = "";
                            int point_pos = value.IndexOf('.', 0);
                            int start_pos = 0;
                            Division = Convert.ToInt32(value.Substring(0, point_pos));
                            start_pos = point_pos + 1; point_pos = value.IndexOf('.', start_pos);
                            Round = Convert.ToInt32(value.Substring(start_pos, point_pos - start_pos));
                            start_pos = point_pos + 1; point_pos = value.IndexOf('.', start_pos);
                            if(point_pos > 0)
                            {
                                MatchNo = Convert.ToInt32(value.Substring(start_pos, point_pos - start_pos));
                                start_pos = point_pos + 1; 
                                Letter = PlayerLetters.Unknown;
                                string pc = value.Substring(start_pos, 1);
                                if (pc == "A")
                                    Letter = PlayerLetters.A;
                                if (pc == "B")
                                    Letter = PlayerLetters.B;
                            }
                            else
                            {
                                MatchNo = Convert.ToInt32(value.Substring(start_pos));
                                Letter = PlayerLetters.Unknown;
                            }
                        }
                        else
                        {
                            Division = Round = MatchNo = 0;
                            Letter = PlayerLetters.Unknown;
                        }
                    }

                }
                catch (Exception)
                {
                    Division = Round = MatchNo = 0;
                    Letter = PlayerLetters.Unknown;
                }
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is MatchLabel) 
            {
                MatchLabel other = obj as MatchLabel;
                return other.Division == Division && other.Round == Round && other.MatchNo == MatchNo;
            }
            return false;
        }
        public override int GetHashCode()
        {
            string label = String.Format("{0:D1}.{1:D3}.{2:D3}", Division, Round, MatchNo);
            return label.GetHashCode();
        }
        public bool IsEmpty 
        {
            get {
                return Division * Round * MatchNo == 0;
            }
        }
    }

    /// <summary>
    /// Представление информации о матче в БД
    /// </summary>
    public class MatchInfo
    {
        private MatchLabel.PlayerLetters FWinner = MatchLabel.PlayerLetters.Unknown;
        public int Id;
        public MatchLabel Label = new MatchLabel();
        public MatchLabel Winners_MatchLabel = new MatchLabel();
        public MatchLabel Loosers_MatchLabel = new MatchLabel();

        public MatchPlayer PlayerA = new MatchPlayer();
        public MatchPlayer PlayerB = new MatchPlayer();
        public MatchPlayer GetPlayerByLetter(MatchLabel.PlayerLetters aLetter)
        {
            switch (aLetter)
            {
                case MatchLabel.PlayerLetters.A:
                    return PlayerA;
                case MatchLabel.PlayerLetters.B:
                    return PlayerB;
                default:
                    return null;
            }
        }
        public MatchLabel.PlayerLetters Looser
        {
            get
            {
                if (PlayerA.Id == 0)
                    return MatchLabel.PlayerLetters.A;
                if (PlayerB.Id == 0)
                    return MatchLabel.PlayerLetters.B;
                switch (FWinner)
                {
                    case MatchLabel.PlayerLetters.A:
                        return MatchLabel.PlayerLetters.B;
                    case MatchLabel.PlayerLetters.B:
                        return MatchLabel.PlayerLetters.A;
                    case MatchLabel.PlayerLetters.Draw:
                        return MatchLabel.PlayerLetters.Draw;
                    default:
                        return MatchLabel.PlayerLetters.Unknown;
                }
            }
        }
        public MatchLabel.PlayerLetters Winner
        {
            get
            {
                if (PlayerA.Id == 0)
                    return MatchLabel.PlayerLetters.B;
                if (PlayerB.Id == 0)
                    return MatchLabel.PlayerLetters.A;
                return FWinner;
            }
            set
            {
                FWinner = value;
                if (Winner_Match != null)
                {
                    Winner_Match.GetPlayerByLetter(Winners_MatchLabel.Letter).Copy(GetPlayerByLetter(Winner));
                    Winner_Match.Refresh();
                }
                if (Looser_Match != null)
                {
                    Looser_Match.GetPlayerByLetter(Loosers_MatchLabel.Letter).Copy(GetPlayerByLetter(Looser));
                    Looser_Match.Refresh();
                }
                //throw new Exception("Обновить все Id в следующих матчах для победителя и проигравшего");
            }
        }
        public int WinnerId
        {
            set
            {
                FWinner = MatchLabel.PlayerLetters.Unknown;
                if (value == 0)
                    FWinner = MatchLabel.PlayerLetters.Draw;
                else 
                {
                    if (value == PlayerA.Id && value != -1)
                        FWinner = MatchLabel.PlayerLetters.A;
                    if (value == PlayerB.Id && value != -1)
                        FWinner = MatchLabel.PlayerLetters.B;
                }
            }
            get
            {
                switch (Winner)
                {
                    case MatchLabel.PlayerLetters.A:
                        return PlayerA.Id;
                    case MatchLabel.PlayerLetters.B:
                        return PlayerB.Id;
                    case MatchLabel.PlayerLetters.Draw:
                        return 0;
                    default:
                        return -1;
                }
            }
        }
        public int LooserId
        {
            get
            {
                switch (Winner)
                {
                    case MatchLabel.PlayerLetters.B:
                        return PlayerA.Id;
                    case MatchLabel.PlayerLetters.A:
                        return PlayerB.Id;
                    case MatchLabel.PlayerLetters.Draw:
                        return 0;
                    default:
                        return -1;
                }
            }
        }
        public int GetPlayerPoints(int playerId) 
        {
            if (playerId == PlayerA.Id)
                return PlayerA.Points;
            if (playerId == PlayerB.Id)
                return PlayerB.Points;
            return 0;
        }

        public OnMatchEvent OnRefresh;

        public MatchPlayer WinnerPlayer
        {
            get
            {
                if (Winner == MatchLabel.PlayerLetters.A)
                    return PlayerA;
                if (Winner == MatchLabel.PlayerLetters.B)
                    return PlayerB;
                return null;
            }
        }
        public MatchPlayer LooserPlayer
        {
            get
            {
                if (Winner == MatchLabel.PlayerLetters.B)
                    return PlayerA;
                if (Winner == MatchLabel.PlayerLetters.A)
                    return PlayerB;
                return null;
            }
        }
        public MatchInfo Looser_Match = null;
        public MatchInfo Winner_Match = null;
        public int Tag;
        public string Title { get; set; }

        public bool IsOver 
        {
            get {
                return Winner != MatchLabel.PlayerLetters.Unknown;
            }
        }

        public void Refresh()
        {
            if (OnRefresh != null)
                OnRefresh();
            if (Looser_Match != null)
                Looser_Match.Refresh();
            if (Winner_Match != null)
                Winner_Match.Refresh();
        }
        public void UpdateNextMatches()
        {
            MatchPlayer looser = null;
            MatchPlayer winner = null;
            if (Looser_Match != null)
                looser = Looser_Match.GetPlayerByLetter(Loosers_MatchLabel.Letter);
            if (Winner_Match != null)
                winner = Winner_Match.GetPlayerByLetter(Winners_MatchLabel.Letter);
            if (winner == null)
                return;
            if (PlayerA.Id == -1 || PlayerB.Id == -1)
            {
                if (looser != null)
                    looser.Id = -1;
                if (winner != null)
                    winner.Id = -1;
            }
            if (PlayerA.Id == 0)
            {
                if (winner != null)
                    winner.Copy(PlayerB);
                if (looser != null)
                    looser.Id = 0;
            }
            if (PlayerB.Id == 0)
            {
                if (winner != null)
                    winner.Copy(PlayerA);
                if (looser != null)
                    looser.Id = 0;
            }
            if (PlayerA.Id > 0 && PlayerB.Id > 0) // здесь было &&
            {
                switch (Winner)
                {
                    case MatchLabel.PlayerLetters.A:
                        if (looser != null)
                            looser.Copy(PlayerB);
                        if (winner != null)
                            winner.Copy(PlayerA);
                        break;
                    case MatchLabel.PlayerLetters.B:
                        if (looser != null)
                            looser.Copy(PlayerA);
                        if (winner != null)
                            winner.Copy(PlayerB);
                        break;
                    case MatchLabel.PlayerLetters.Unknown:
                        if (looser != null)
                            looser.Id = -1;
                        if (winner != null)
                            winner.Id = -1;
                        break;
                }
            }
            if (Looser_Match != null)
                Looser_Match.UpdateNextMatches();
            if (Winner_Match != null)
                Winner_Match.UpdateNextMatches();
        }
        public override string ToString()
        {
            return String.Format("{0} vs. {1}", PlayerA.Id, PlayerB.Id);
        }

        private string GetPlayerXmlAttributes(string playerName, MatchPlayer player) 
        {
            return String.Format(@"<{0} id='{1}' nickname='{2}' points='{3}' guid='{4}' tag='{5}'/>", playerName, player.Id, player.Name, player.Points, player.Guid, player.Tag);
        }
        public string XmlString()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement("MATCH");
            XmlAttribute attr = doc.CreateAttribute("label"); attr.Value = Label.ToString(); root.Attributes.Append(attr);
            attr = doc.CreateAttribute("winner_label"); attr.Value = Winners_MatchLabel.ToString(); root.Attributes.Append(attr);
            attr = doc.CreateAttribute("looser_label"); attr.Value = Loosers_MatchLabel.ToString(); root.Attributes.Append(attr);
            attr = doc.CreateAttribute("winner"); attr.Value = Enum.GetName(typeof(MatchLabel.PlayerLetters), Winner); root.Attributes.Append(attr);
            doc.AppendChild(root);
            root.InnerXml += GetPlayerXmlAttributes("PLAYER_A", PlayerA);
            root.InnerXml += GetPlayerXmlAttributes("PLAYER_B", PlayerB);
            return doc.OuterXml;
        }
    }
}
