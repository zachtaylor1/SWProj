using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWProjv1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWProjv1.Tests
{
    [TestClass()]
    public class RAApplicationDataTests
    {
        [TestMethod()]
        public void RAApplicationDataTest()
        {
            try
            {
                SWProjv1.StudentHome sh = new StudentHome(new Student());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}