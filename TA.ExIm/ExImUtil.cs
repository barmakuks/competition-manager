using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.ExIm
{
    public class ExImUtil
    {
        public static bool Export() 
        {
            return fExport.ShowExport();
        }
        public static bool Import() 
        {
            return fImport.ShowImport();
        }
    }
}
