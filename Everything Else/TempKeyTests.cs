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
    public class StudentStaticTest
    {
        [TestMethod()]
        public void StudentTest()
        {
            SWProjv1.Student stustatic = new Student();
            stustatic.firstName = "Assert";
            for (int i = 0; i < 20; i++)
            {
                SWProjv1.Student stu = new SWProjv1.Student();
            }
            Assert.AreEqual(stustatic.firstName, "Assert");
            //checks to ensure static Student instantiation works correctly, doesnt overwrite. Issues with this before.

        }
    }
}