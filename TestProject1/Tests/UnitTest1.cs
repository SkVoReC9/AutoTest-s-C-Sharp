using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
// For supporting Page Object Model
// Obsolete - using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using TestProject1.Src.Pages;


namespace TestProject1
{
    
    public class Tests
    {
        IWebDriver driver;
        String search = "Биохимия 8 показателей";
        String title = "Гемотест Москва | Клинико-диагностическая лаборатория Гемотест";
        private String Browser;
        private String Version;
        private String OS;


        [SetUp]
        public void init()
        {
            driver = new ChromeDriver(@"C:\Users\Александр\source\repos\PracticTestQA\TestProject1\");
            ChromeOptions capability = new();
            capability.AddAdditionalCapability("os", OS);
            capability.AddAdditionalCapability("browser_version", Version);
            capability.AddAdditionalCapability("os", OS);
        }

        [Test]
        public void Test1()
        {
            String excepted = "Биохимический анализ крови - 8 показателей (венозная кровь) - сдать биохимию крови в лаборатории Гемотест по доступной цене в Москве и др. городах";

            StartPage start = new StartPage(driver);
            start.GoToSite();
            start.search_bio(search);

            ResultPage result = new ResultPage(driver);
            result.clickResult();
            FinalPage final = new FinalPage(driver);

            var res = final.GetTitleRes();
            if (excepted == res)
            {
                Console.WriteLine("Succes!");
            }else
            {
                Console.WriteLine("Fail");
            }

        }
        [TearDown]
        public void CleanUp()
        {
            bool passed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed;
            driver.Quit();
            Assert.IsTrue(passed);
        }
    }
}