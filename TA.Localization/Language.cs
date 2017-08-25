using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Localizator
{
    public class Language
    {
        public string Id;
        public string Description;
        public override string ToString()
        {
            return Description;
        }

    }
}
