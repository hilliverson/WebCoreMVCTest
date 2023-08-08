using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolForNet6.ZipTool
{
    public class ZipHelper
    {
        public void ZipFolder(string beZipFolder, string zipFile)
        {
            if (string.IsNullOrEmpty(beZipFolder))
                throw new ArgumentNullException("beZipFolder is null or empty");
            if (string.IsNullOrEmpty(zipFile))
                throw new ArgumentNullException("zipFolder is null or empty");
            if (File.Exists(zipFile)) File.Delete(zipFile);
            if (!Directory.Exists(beZipFolder))
                throw new ArgumentNullException("no such be zip folder");
            ZipFile.CreateFromDirectory(beZipFolder, zipFile);

        }
    }
}
