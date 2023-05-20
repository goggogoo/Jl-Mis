using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            string ss = new WebUI.Utilities.Dbopr().getstr("SELECT LS_XM FROM RS_USERS").ToString();
            System.Console.WriteLine("wwwww");
            //Assert.AreEqual(ss, "mmm");

        }
    }
}
