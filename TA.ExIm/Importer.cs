using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TA.ExIm
{
    class Importer
    {
        public static IImporter GetImporter(string filename)
        {
            string ext = Path.GetExtension(filename);
            if(ext == ".cmdx")
                return new XmlImporter();
            if(ext == ".cmzx")
                return new ZipImporter();
            if (ext == ".cmdb")
                return new SqLiteImporter();
            return null;
        }
    }
}
