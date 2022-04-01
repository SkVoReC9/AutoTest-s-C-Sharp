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
        RemoteWebDriver driver;
        //IWebDriver driver;
        String search = "�������� 8 �����������";
        String title = "�������� ������ | �������-��������������� ����������� ��������";
        private String Browser;
        private String Version;
        private String OS;


        [SetUp]
        public void init()
        {
            ChromeOptions options = new();
            Dictionary<string, object> selenoidOptions = new Dictionary<string, object>();
            selenoidOptions.Add("enableVNC", true);
            options.AddAdditionalOption("selenoid:options", selenoidOptions);
            options.AddArgument("start-maximized"); // open Browser in maximized mode
            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options);

            //driver = new ChromeDriver(@"C:\Users\���������\source\repos\PracticTestQA\TestProject1");

        }

        [Test]
        public void Test1()
        {
            String excepted = "������������� ������ ����� - 8 ����������� (�������� �����) - ����� �������� ����� � ����������� �������� �� ��������� ���� � ������ � ��. �������";

            StartPage start = new StartPage(driver);
            start.GoToSite();
            start.search_bio(search);

            ResultPage result = new ResultPage(driver);
            result.clickResult();
            FinalPage final = new FinalPage(driver);

            final.AddToCartService();
            if(final.CheckCart())
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