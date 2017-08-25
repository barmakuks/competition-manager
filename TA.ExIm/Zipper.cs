using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
namespace TA.ExIm
{
    class Zipper
    {
        public static void PackFile(string srcFile, string destFile) 
        {
            ZipFile zipfile = ZipFile.Create(destFile);
            zipfile.BeginUpdate();
            zipfile.Add(srcFile, Path.GetFileName(srcFile));
            zipfile.CommitUpdate();
            zipfile.Close();                
        }

        public static string UnpackFile(string srcFile) 
        {
            return UnpackFile(srcFile, Path.GetTempPath());
        }
        public static string UnpackFile(string srcFile, string destDir) 
        {
            FileStream fileStreamIn = new FileStream(srcFile, FileMode.Open, FileAccess.Read);
            ZipInputStream zipInStream = new ZipInputStream(fileStreamIn);
            ZipEntry entry = zipInStream.GetNextEntry();
            string filename = Path.Combine(destDir, entry.Name);
            FileStream fileStreamOut = new FileStream(filename, FileMode.Create, FileAccess.Write);
            int size;
            byte[] buffer = new byte[1024];
            do
            {
                size = zipInStream.Read(buffer, 0, buffer.Length);
                fileStreamOut.Write(buffer, 0, size);
            } while (size > 0);
            zipInStream.Close();
            fileStreamOut.Close();
            fileStreamIn.Close();
            return filename;
        }
        public static bool IsFilePacked(string srcFile) 
        {
            try
            {
                ZipFile zipFile = new ZipFile(srcFile);
                if (zipFile == null)
                    return false;
                return zipFile.TestArchive(true); ;
            }
            catch (Exception) 
            {
                return false;
            }
        }
    }
}
