using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestEShopSolution.Functions;

namespace WebUITests
{
    [TestFixture] // Đánh dấu class là một bộ test
    public class Tests
    {
        private Auth auth;

        [SetUp]
        public void Setup()
        {
            auth = new Auth();
        }

        [Test]
        public void TestLogin()
        {
            auth.PerformLogin("trunghieu", "Trunghieu123@");
            auth.PerformLogin("trunghieu123", "Trunghieu123@");
            auth.PerformLogin("", "");
        }

        [Test]
        public void TestRegister()
        {
            
        }

        [TearDown]
        public void TearDown()
        {
            auth.Clean();
        }
    }
}
