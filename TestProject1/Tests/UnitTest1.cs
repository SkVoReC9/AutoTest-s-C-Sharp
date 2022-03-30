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
using NUnit.Framework;

namespace TestProject1
{
    
    public class Tests
    {
        IWebDriver driver;
        String search = "�������� 8 �����������";
        String title = "�������� ������ | �������-��������������� ����������� ��������";
        private String Browser;
        private String Version;
        private String OS;


        [SetUp]
        public void init()
        {
            driver = new ChromeDriver(@"C:\Users\���������\source\repos\PracticTestQA\TestProject1\");
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