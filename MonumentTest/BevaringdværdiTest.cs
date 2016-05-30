using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MonumentTest;
using MonumentApp.Model;

namespace MonumentTest
{
    [TestClass]
    public class MonumentOversigtTest
    {
        private MonumentOversigt _monumentOversigt;

        [TestInitialize]
        public void BeforeTest()
        {
            _monumentOversigt = new MonumentOversigt();
        }

        [TestMethod]
        public void BevaringdværdiTest()
        {
            string bevaringsværdi2 = "";
            string bevaringsværdi3 = "";

            for (int i = 0; i < 1; i++)
            {
                bevaringsværdi2 = bevaringsværdi2 + "B";
            }
            for (int i = 0; i < 4; i++)
            {
                bevaringsværdi3 = bevaringsværdi3 + "ABCDEFG";
            }

            _monumentOversigt.Bevaringsværdi = bevaringsværdi2;
            Assert.AreEqual(bevaringsværdi2, _monumentOversigt.Bevaringsværdi);

            try
            {
                _monumentOversigt.Bevaringsværdi = bevaringsværdi3;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Bevaringsværdi er forkert", e.Message);
            }
        }
    }
}
