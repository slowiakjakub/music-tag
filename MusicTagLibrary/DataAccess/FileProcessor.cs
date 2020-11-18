using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace MusicTagLibrary.DataAccess
{
    public static class FileProcessor
    {
        public static void RenameFile(ref string sourceFilePath, string finalFileName)
        {
            FileInfo fi = new FileInfo(sourceFilePath);
            if(fi.Exists)
            {
                string newFilePath = $@"{fi.Directory.FullName}\{finalFileName}.mp3";
                fi.MoveTo(newFilePath);
                sourceFilePath = newFilePath;
            }
        }
    }
}
