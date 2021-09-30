using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
namespace SeleniumTestingDemo
{
    [TestClass]
    public class SeleniumEasy
    {
        [TestMethod]
        public void ValidateCheckbox()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            /*IWebElement noThanksLink = driver.FindElementByXPath("//a[contains(.,'No, thanks!')]");
            noThanksLink.Click();
            IWebElement inputForm = driver.FindElementByXPath("//ul[@id='treemenu']//a[contains(.,'Input Forms')]");
            inputForm.Click();

            IWebElement checkboxDemoLink = driver.FindElementByXPath("//ul[@id='treemenu']//a[contains(.,'Checkbox Demo')]");
            checkboxDemoLink.Click();*/

            IWebElement checkbox = driver.FindElementByCssSelector("#isAgeSelected");
            bool checkboxStatus = checkbox.Selected;
            Assert.IsFalse(checkboxStatus);

            checkbox.Click();

            bool updateCheckboxStatus = checkbox.Selected;
            Assert.IsTrue(updateCheckboxStatus);
            Console.WriteLine(updateCheckboxStatus);

            IWebElement successTextElement = driver.FindElementByCssSelector("#txtAge");

            string expectedText = successTextElement.Text;
            Console.WriteLine(expectedText);

            Assert.AreEqual("Success - Check box is checked", expectedText);

            driver.Close();
            driver.Quit();

        }

        [TestMethod]
        public void ValidateRadioButtons()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.seleniumeasy.com/test/basic-radiobutton-demo.html";

            IWebElement maleRadioButton = driver.FindElementByXPath("//input[@value='Male']");
            bool checkboxStatus = maleRadioButton.Selected;

            //verified status is unselected
            Assert.IsFalse(checkboxStatus);

            maleRadioButton.Click();

            bool updatedRadioButtonStatus = maleRadioButton.Selected;
            //verified status is selected
            Assert.IsTrue(updatedRadioButtonStatus);
            Console.WriteLine(updatedRadioButtonStatus);

            driver.FindElementByCssSelector("#buttoncheck").Click();

            IWebElement successTextElement = driver.FindElementByCssSelector(".radiobutton");

            string expectedText = successTextElement.Text;
            Console.WriteLine(expectedText);

            Assert.AreEqual("Radio button 'Male' is checked", expectedText);

            driver.Close();
            driver.Quit();

        }

    }
}
