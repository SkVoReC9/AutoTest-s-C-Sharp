using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
// For supporting Page Object Model
// Obsolete - using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;


namespace TestProject1.Src.Pages
{
    class StartPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        String test_url = "https://gemotest.ru/";

        public StartPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement textBox_search;

        [FindsBy(How = How.XPath, Using = "//button[contains(.,'Найти')]")]
        private IWebElement button_search;

        [FindsBy(How = How.Id, Using = "logo")]
        private IWebElement GemoLogo;

        public void GoToSite()
        {
            driver.Navigate().GoToUrl(test_url);
        }

        public string GetTitle()
        {
            return driver.Title;
        }

        public bool LogoDisplayed()
        {
            return GemoLogo.Displayed;
        }

        public void search_bio(string input_search)
        {
            textBox_search.SendKeys("Биохимия 8 показателей");
            button_search.Click();
        }

    }
}
