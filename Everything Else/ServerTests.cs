using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWProjv1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SWProjv1.Tests
{
    [TestClass()]
    public class ServerTests
    {
        [TestMethod()]
        public void InitTest()
        {
            try
            {
                Server.Init();
                Server.Init();
                Server.Init();
                Server.Init();
                Server.Init();
                Server.Init();
                Server.Init();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod()]
        public void LogInQueryTest()
        {
            int x;
            x = Server.LogInQuery("A", "B");
            Assert.AreEqual(x, -1);
            x = Server.LogInQuery("AdMiN", "ADmiNPasSS");
            Assert.AreEqual(x, -1);
            x = Server.LogInQuery("student2", "iamstudent");
            Assert.AreEqual(x, 1);
            x = Server.LogInQuery("admin", "adminpass");
            Assert.AreEqual(x, 2);
            x = Server.LogInQuery("ra1", "rapass");
            Assert.AreEqual(x, 3);
        }
        [TestMethod()]
        public void Emptyrun_queryTest()
        {
            try
            {
                var x = Server.run_query("");
                Assert.Fail();
            }
            catch (Exception e)
            {

            }
        }
        public void Wrongrun_queryTest()
        {
            try
            {
                var x = Server.run_query("SELECT  FROM User_T WHERE UserID = '3'");
                Assert.Fail();
            }
            catch (Exception e)
            {

            }
        }
        public void Correctrun_queryTest()
        {
            try
            {
                var x = Server.run_query("SELECT * FROM User_T WHERE UserID = '3'");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}