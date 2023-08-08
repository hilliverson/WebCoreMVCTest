using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonToolForNet6.FileTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolForNet6.FileTool.Tests
{
    [TestClass()]
    public class FolderToolTests
    {
        [TestMethod("測試取得完整路徑的最後一個資料夾名稱或是檔案名稱")]
        public void GetLastFolderTest()
        {
            string testfullPathCase1 = "D:\\temp\\temp\\hill";
            string testfullPathCase2 = "D:\\temp\\temp\\hill\\";
            string testfullPathCase3 = "D:\\temp\\temp\\hill.doc";
            Assert.AreEqual("hill", FolderTool.GetLastFolder(testfullPathCase1));
            Assert.AreEqual("hill", FolderTool.GetLastFolder(testfullPathCase2));
            Assert.AreEqual("hill.doc", FolderTool.GetLastFolder(testfullPathCase3));

        }
    }
}