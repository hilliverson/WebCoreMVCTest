using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolForNet6.FileTool
{
    public static class FolderTool
    {
        /// <summary>
        /// 取得完整路徑中的最後一個Folder or Filename。例如：D:\test\temp 會取得 temp 
        /// D:\temp\temp\excel.xls 會取得 excel.xls 
        /// </summary>
        /// <param name="FullFolder"></param>
        /// <returns></returns>
        public static string GetLastFolder(string fullFolder)
        {
            if (string.IsNullOrEmpty(fullFolder)) 
                throw new ArgumentNullException("the fullfolder is null or empty");
            //最後一個是\
            if(fullFolder.LastIndexOf("\\")==fullFolder.Length-1)
            {
                string newFullPath = fullFolder.Substring(0, fullFolder.LastIndexOf("\\"));
                return newFullPath.Substring(newFullPath.LastIndexOf("\\") + 1); 
            }
            else
            {
                return fullFolder.Substring(fullFolder.LastIndexOf("\\") + 1);
            }
        }
    }
}
