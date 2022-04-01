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
    class FinalPage
    {
        private RemoteWebDriver driver;
        //private IWebDriver driver;

        public FinalPage(RemoteWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//h1[contains(. , 'Биохимия 8')]")]
        private IWebElement NameOfLab;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[3]/div[5]/div/div[3]/div/div[3]/div/div[4]/div[1]/div[3]/div")]
        private IWebElement AddToCart;

        [FindsBy(How = How.Id, Using = "basket_text")]
        private IWebElement CartButton;

        [FindsBy(How = How.Id, Using = "basket_list")]
        private IWebElement CartLabExist;

        public string GetTitleRes()
        {
            return driver.Title;
        }

        public void AddToCartService()
        {
            AddToCart.Click();
        }

        public bool CheckCart()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            CartButton.Click();
            if(CartLabExist.Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
