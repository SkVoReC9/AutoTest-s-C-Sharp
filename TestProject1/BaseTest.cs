using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace TestProject1
{

    public class BaseTest
    {
        private RemoteWebDriver driver { get; set; }
        [SetUp]
        public virtual void InitDriver()
        {
            ChromeOptions options = new();
            Dictionary<string, object> selenoidOptions = new Dictionary<string, object>();
            selenoidOptions.Add("enableVNC", true);
            options.AddAdditionalOption("selenoid:options", selenoidOptions);
            options.AddArgument("start-maximized"); 
            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options);

            //driver = new ChromeDriver(@"C:\Users\Александр\source\repos\PracticTestQA\TestProject1");
        }

        public RemoteWebDriver getDriver() { return this.driver; }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
