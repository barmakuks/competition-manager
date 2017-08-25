using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.ExIm
{
    class ZipImporter : XmlImporter
    {
        public override bool Open(string pathToXml)
        {
            if (Zipper.IsFilePacked(pathToXml))
                pathToXml = Zipper.UnpackFile(pathToXml);
            return base.Open(pathToXml);
        }
    }
}
