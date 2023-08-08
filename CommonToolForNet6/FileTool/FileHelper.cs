using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolForNet6.FileTool
{
    public class FileHelper
    {
        public void CopyFile(string sourceFilePath,string destinationFilePath)
        {
            if (string.IsNullOrEmpty(sourceFilePath)) 
                throw new ArgumentNullException("sourceFilePath is null or empty");
            if (string.IsNullOrEmpty(destinationFilePath))
                throw new ArgumentNullException("destinationFilePath is null or empty");
            //if (!File.Exists(sourceFilePath)) 
            //    throw new FileNotFoundException($"File is not find in {sourceFilePath}");
            File.Copy(sourceFilePath, destinationFilePath );    

        }
        
        
        public string SaveFile(string folder, string fileGUID, byte[] Files)
        {
            if (string.IsNullOrEmpty(folder))
                throw new Exception("Folder is empty, cannot save file!!");
            if (string.IsNullOrEmpty(fileGUID))
                throw new Exception("FileGUID is empty, cannot save file!!");
            if (Files.Count() == 0)
                throw new Exception("File is empty!!");
            //判斷資料夾存不存在，不存在就建一個
            if (Directory.Exists(folder)==false)
            {
                Directory.CreateDirectory(folder);
            }
            string sFilePath = folder + @"\" + fileGUID;
            //檢核是否存在，若存在的話先刪掉
            if (File.Exists(sFilePath))
                File.Delete(sFilePath);

            using (FileStream fs = new FileStream(sFilePath, FileMode.Create))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fs))
                {
                    binaryWriter.Write(Files);
                    binaryWriter.Flush();
                }
            }
            //儲存完後再作檢核(怕沒存進去可是系統也沒報錯誤)
            if (File.Exists(sFilePath)==false)
            {
                throw new Exception("File not correct save! please check file stroage.");
            }

            return sFilePath;
        }


        /// <summary>
        /// 刪除檔案
        /// </summary>
        /// <param name="sTableName"></param>
        /// <param name="sFileGUID"></param>
        public void DeleteFile(string folderName, string fileName)
        {
            if (string.IsNullOrEmpty(folderName))
                throw new Exception("Request_FolderName is empty, cannot get file!!");
            
            if (string.IsNullOrEmpty(fileName))
                throw new Exception("Request_FileName is empty, cannot get file!!");
            string sFilePath = folderName + @"\" + fileName;
            if (File.Exists(sFilePath))  //沒檔案的話...就算啦，反正本來就要刪掉的。 
            {
                File.Delete(sFilePath);
            }
        }
    }
}
