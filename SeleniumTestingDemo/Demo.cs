using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestingDemo
{
    [TestClass]
    public class Demo
    {
        [TestMethod]
        public void VerifySearchFunctionality()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.myntra.com/";
            string title = driver.Title;
            Assert.AreEqual("Online Shopping for Women, Men, Kids Fashion & Lifestyle - Myntra", title);

            IWebElement homepageLogo = driver.FindElementByXPath("//div[@class='desktop-logoContainer']//a");
            bool isDisplayed = homepageLogo.Displayed;
            Assert.IsTrue(isDisplayed);

            IWebElement searchBox = driver.FindElementByXPath("//input[@class='desktop-searchBar']");
            searchBox.SendKeys("shirts");

            IWebElement searchButton = driver.FindElementByXPath("//a[@class='desktop-submit']");
            searchButton.Click();
            string shirtsTitle = driver.Title;
            Assert.IsTrue(shirtsTitle.Contains("Shirts"));

            string currentUrl = driver.Url;
            Assert.AreEqual("https://www.myntra.com/shirts", currentUrl);

            IWebElement subTitle = driver.FindElementByCssSelector(".title-title");
            string titleText = subTitle.Text;
            Assert.AreEqual("Shirts For Men & Women", titleText);

            IList<IWebElement> searchResultList = driver.FindElementsByXPath("//li[@class='product-base']");
            Assert.IsTrue(searchResultList.Count > 1);

            IList<IWebElement> productBrandList = driver.FindElementsByCssSelector(".product-brand");
            for(int i = 0; i < productBrandList.Count; i++)
            {
                Console.WriteLine(productBrandList[i].Text);
            }

            driver.Close();
            driver.Quit();
        }
    }
}
