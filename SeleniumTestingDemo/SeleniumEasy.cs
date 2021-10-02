using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;

namespace SeleniumTestingDemo
{
    [TestClass]
    public class SeleniumEasy
    {
        private TestContext context;

        [TestMethod]
        public void ValidateCheckbox()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.seleniumeasy.com/test";
            
            //Close pop up
            IWebElement closeButton = driver.FindElementByCssSelector("#at-cv-lightbox-inner .at4-close");

            //Wait for 5 seconds
            Thread.Sleep(5000);

            closeButton.Click();

            IWebElement inputForm = driver.FindElementByXPath("//ul[@id='treemenu']//a[contains(.,'Input Forms')]");
            inputForm.Click();

            IWebElement checkboxDemoLink = driver.FindElementByXPath("//ul[@id='treemenu']//a[contains(.,'Checkbox Demo')]");
            checkboxDemoLink.Click();

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

        [TestMethod]
        public void VerifyNavigationCommands()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.seleniumeasy.com/test";
            IWebElement noThanksLink = driver.FindElementByCssSelector("#at-cv-lightbox-inner .at4-close");

            //Wait for 5 seconds
            Thread.Sleep(5000);

            //to go back
            driver.Navigate().Back();

            //to go forward
            driver.Navigate().Forward();

            //to refresh
            driver.Navigate().Refresh();

            //GO to another URL
            driver.Navigate().GoToUrl("https://myntra.com");
        }


        [TestMethod]
        public void VerifyAlerts()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.seleniumeasy.com/test";
            IWebElement closeButton = driver.FindElementByCssSelector("#at-cv-lightbox-inner .at4-close");

            //Wait for 5 seconds
            Thread.Sleep(5000);

            closeButton.Click();

            IWebElement alertLink = driver.FindElementByXPath("//ul[@id='treemenu']//a[contains(.,'Alerts & Modals')]");
            alertLink.Click();

            IWebElement jsAlertLink = driver.FindElementByXPath("//ul[@id='treemenu']//a[contains(.,'Javascript Alerts')]");
            jsAlertLink.Click();

            IWebElement alertButton = driver.FindElementByXPath("//button[text()='Click for Prompt Box']");
            alertButton.Click();

            //Handle alert
            IAlert alert = driver.SwitchTo().Alert();
            Console.WriteLine(alert.Text);

            alert.SendKeys("This is a sample alert");

            //Cancel alert
            alert.Dismiss();

            //to accept an alert// click on OK
            //alert.Accept();
            //alert.SetAuthenticationCredentials("username", "password");

            driver.Close();
            driver.Quit();

        }

        [TestMethod]
        public void VerifyDropdownList()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.seleniumeasy.com/test";
            IWebElement closeButton = driver.FindElementByCssSelector("#at-cv-lightbox-inner .at4-close");

            //Wait for 5 seconds
            Thread.Sleep(5000);

            closeButton.Click();

            IWebElement inputForm = driver.FindElementByXPath("//ul[@id='treemenu']//a[contains(.,'Input Forms')]");
            inputForm.Click();

            IWebElement dropdown = driver.FindElementByXPath("//ul[@id='treemenu']//a[contains(.,'Select Dropdown List')]");
            dropdown.Click();

            IWebElement dropdownElement = driver.FindElementByCssSelector("#select-demo");
            SelectElement select = new SelectElement(dropdownElement);
            select.SelectByIndex(7);
            Assert.AreEqual("Saturday", select.SelectedOption.Text);

            select.SelectByText("Friday");
            Assert.AreEqual("Friday", select.SelectedOption.Text);

            select.SelectByValue("Monday");
            Assert.AreEqual("Monday", select.SelectedOption.Text);


            driver.Close();
            driver.Quit();

        }

        [TestMethod]
        public void TakeScreenshot()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.seleniumeasy.com/test";

            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            takesScreenshot.GetScreenshot().SaveAsFile("screenshot.jpeg", ScreenshotImageFormat.Jpeg);

            driver.Close();
            driver.Quit();
        }

        [TestMethod]
        public void DrangAndDrop()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.seleniumeasy.com/test/drag-and-drop-demo.html";

            IWebElement source = driver.FindElementByXPath("//span[text()='Draggable 3']");
            IWebElement target = driver.FindElementByCssSelector("#mydropzone");


            Actions action = new Actions(driver);
            action.DragAndDrop(source, target);
            action.Perform();

            action.ContextClick();

            action.DoubleClick();

            action.MoveToElement(target);
        }

        [TestMethod]
        public void WindowHandles()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.seleniumeasy.com/test";
            string window = driver.CurrentWindowHandle; // window1

            // clicking on a button which opens a new tab
            //

            IList<string> windows = driver.WindowHandles.ToList(); //window1, window2

            foreach (string windowName in windows) 
            {
                if(!windowName.Equals(window))
                {
                    driver.SwitchTo().Window(windowName);
                }
            }


            //driver.SwitchTo().Frame("Xpath of Frame");
            //driver.SwitchTo().Frame(0);   // frameindex
            //driver.SwitchTo().Frame("framename");
            IWebElement source = driver.FindElementByXPath("//span[text()='Draggable 3']");
            source.Click();

            //to come out of iframe
            driver.SwitchTo().DefaultContent();

            driver.Close();
            driver.Quit();
        }

        [TestCleanup]

        public void CleanUp()
        {
            if(context.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                
            }
        }

    }
}
