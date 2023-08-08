using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolForNet6.FTPTool
{
    public class FtpHelper
    {
        private FtpAppSet ftpData { get; set; }

        public FtpHelper(FtpAppSet ftpData)
        {
            this.ftpData = ftpData;   
        }

        public void UploadFile(string fullFilePath)
        {
            try
            {
                FtpWebRequest uploadRequest = (FtpWebRequest)WebRequest.Create(ftpData.ftpUrl+ Path.GetFileName(fullFilePath));
                uploadRequest.KeepAlive = true;
                uploadRequest.UseBinary = true;
                uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;//設定Method上傳檔案
                uploadRequest.Proxy = null;
                if (ftpData.ftpId.Length > 0)//如果需要帳號登入
                {
                    NetworkCredential nc = new NetworkCredential(ftpData.ftpId, ftpData.ftpPassword);
                    uploadRequest.Credentials = nc; //設定帳號
                }
                FileInfo localFile = new FileInfo(fullFilePath);
                uploadRequest.ContentLength = localFile.Length;
                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int contentLen;
                FileStream localFileStream = File.Open(fullFilePath, FileMode.Open, FileAccess.Read);
                var requestStream = uploadRequest.GetRequestStream();
                contentLen = localFileStream.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    requestStream.Write(buff, 0, contentLen);
                    contentLen = localFileStream.Read(buff, 0, buffLength);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
