using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonToolForNet6.ExtensionTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolForNet6.ExtensionTool.Tests
{
    [TestClass()]
    public class ListHelperTests
    {
        
        private List<TestList> GetTestList()
        {
            var list = new List<TestList>();
            list.Add(new TestList("id ", "name ", "value "));
            list.Add(new TestList("id2 ", "name2", "value2 "));
            return list;

        }
        private List<TestList> GetExpectedList()
        {
            var list = new List<TestList>();
            list.Add(new TestList("id", "name", "value"));
            list.Add(new TestList("id2", "name2", "value2"));
            return list;
        }
        [TestMethod("測試將List中所有物件的String屬性作trim()")]
        public void TrimAllStringTest()
        {
            var testList = GetTestList();
            var expectedList = GetExpectedList();
            testList = testList.TrimAllString<TestList>();
            for (int i = 0; i < expectedList.Count; i++)
            {
                Assert.AreEqual(expectedList[i].id,testList[i].id);
                Assert.AreEqual(expectedList[i].name,testList[i].name);
                Assert.AreEqual(expectedList[i].value,testList[i].value );
            }
            
        }
       
    }

    internal class TestList
    {
        public TestList(string pid,string pname,string pvalue)
        {
            id = pid;
            name=pname; 
            value= pvalue;  
        }
        public string id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
    }
}