using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DBHelper;

namespace BLL_Tests
{
    [TestFixture]
    public class BHelperTest
    {
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
        }



        [Test]
        public void Test_BHelper()
        {
            BHelper bHelper = new BHelper(null);
            
        }
    }
}
