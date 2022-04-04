using System;
using NUnit.Framework;
using System.Threading;
using TestProject1.Src.Pages;


namespace TestProject1
{
    [TestFixture]
    public class Tests : BaseTest
    {

        //IWebDriver driver;
        String search = "�������� 8 �����������";

        [Test]
        public void Test1()
        {
            StartPage start = new StartPage(driver);
            start.GoToSite();
            Thread.Sleep(10000);
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

    }
}