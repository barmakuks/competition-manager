using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Utils
{
    public class StringAlt : IComparable, IComparable<StringAlt>, IComparer<StringAlt>
    {
        string str = "";
        public StringAlt()
        {
        }
        public StringAlt(char[] s)
        {
            str = new string(s);
        }
        public StringAlt(string s)
        {
            str = s;
        }

        public bool IsNull 
        {
            get {
                return str == null || str == "";
            }
        }

        public static implicit operator StringAlt(string s)
        {
            return new StringAlt(s);
        }
        public static implicit operator string(StringAlt sa)
        {
            return sa.str;
        }
        public int Compare(StringAlt x, StringAlt y)
        {
            if (x.str == "" && y.str != "")
                return 1;
            if (x.str != "" && y.str == "")
                return -1;
            return x.str.CompareTo(y.str);
        }
        public override string ToString()
        {
            return str;
        }

        public static bool operator != (StringAlt a, StringAlt b)
        {
            return a.str != b.str;
        }
        /*public static bool operator !=(StringAlt a, string b)
        {
            return a.str != b;
        }*/
        public static bool operator !=(string a, StringAlt b)
        {
            return a != b.str;
        }

        public static bool operator ==(StringAlt a, StringAlt b)
        {
            object objA = a as StringAlt;
            object objB = b as StringAlt;
            if (objA == null && objB == null)
                return true;            
            if (objA == null || objB == null)
                return false;
            return a.str == b.str;
        }
        /*public static bool operator ==(StringAlt a, string b)
        {
            return a.str == b;
        }*/
        public static bool operator ==(string a, StringAlt b)
        {
            return a == b.str;
        }


        public override bool Equals(object obj)
        {
            return this.str.Equals((obj as StringAlt).str);
        }
        public override int GetHashCode()
        {
            return str.GetHashCode();
        }

        #region IComparable<StringAlt> Members

        public int CompareTo(StringAlt other)
        {
            return Compare(this, other);
        }

        #endregion

        #region IComparable Members

        public int CompareTo(object obj)
        {
            return Compare(this, obj as StringAlt);
        }

        #endregion
    }
}
