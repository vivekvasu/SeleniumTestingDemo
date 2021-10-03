# Selenium
**What is Selenium ?**\
Selenium Webdriver is an open-source collection of APIs which is used for testing web applications. \
Selenium Webdriver tool is used for automating web application testing to verify whether the application is working as expected.\
It mainly supports browsers like Firefox, Chrome, Safari and Internet Explorer. It also permits you to execute cross-browser testing.
	

**Can selenium automate Captcha & Window Pop Ups ?**\
  No We cannot automate captcha\
  Selenium cannot handle windows pop ups also. We have to depend on 3rd party tools like **AutoIT** to autoamte it.


**What are the different components in Selenium Suite ?**\
	Selenium IDE\
	Selenium RC\
	Selenium WebDriver\
	Selenium Grid

**What are the advantages of Selenium ?**\
	It is OpenSource\
	Supports Multi Language (Python,C#,Java,Ruby,Js)\
	Supports Multiple browsers (Chrome,Firefox,Edge,Safari,Opera,IE )\
	Large community support\
	Supports Cross Browser testing\
	Supports Parallel testing

**What are the disadvantages of selenium ?**
	Cannot automate Desktop Applications\
	Cannot automate Captcha\
	Require programming knowledge\
	No dedicated owner in case any support is required.\

**What is the current stable version of Selenium ?**\
	 3.141.59


**What are the different methods that selenium supports to identify webelements ?**\
	ID\
	Name\
	Class Name\
	Tag Name\
	Link Text\
	Partial LinkText\
	XPath\
	CSS Selector

**What is Xpath ?**\
	XPath in Selenium is an XML path used for navigation through the HTML structure of the page.\
	It is a syntax or language for finding any element on a web page using XML path expression.\
	Syntax - Xpath=//tagname[@attribute='attributevalue']

**What will happen if there are multiple elements found for a single xpath ?**\
	It will always pick the first web element.\

**Difference between FindElement() and FindElements() ?**\
	Find Element command is used to uniquely identify a (one) web element within the web page.\
	Whereas, the Find Elements command is used to uniquely identify the list of web elements within the web page.

	Syntax
	-------
	List<IWebElement> elementName = driver.findElements(By.xpath("//div"));
	List<IWebElement> listOfElements = driver.findElements(By.xpath("//div"));

**What is the difference between / (single slash) and // (double slash) in xpath ?**\
	Single Slash “/” – Single slash is used to create Xpath with absolute path i.e. the xpath would be created to start selection from the document node/start node.\

	Double Slash “//” – Double slash is used to create Xpath with relative path i.e. the xpath would be created to start selection from anywhere within the document.\

**What is absolute and relative xpath? Which is better ? Why ?**\
	Absolute XPath:
	—-----------------
  It is the direct way to find the element, but the disadvantage of the absolute XPath is that if there are any changes made in the path of the element then that XPath fails.\
	It starts with single forward slash (/)\
	Example - /html/body/div[2]/div[1]/div/h4[1]/b/html[1]/body[1]/div[2]/div[1]/div[1]/h4[1]/b[1]

	Relative Xpath
  —-----------------\
  It  starts from the middle of HTML DOM structure.\ 
  It starts with double forward slash (//). It can search elements anywhere on the webpage, means no need to write a long xpath and you can start from the middle 	of HTML DOM structure. 
	Example - //div[@class='featured-box cloumnsize1']//h4[1]//b[1]

	Relative Xpath is always preferred as it is not a complete path from the root element.

**How selenium works (Architecture) ?**\
  ![image](https://user-images.githubusercontent.com/26665783/135740894-0f224c4c-14d4-438f-930e-a1ec7acbcfa0.png)

	1. Selenium executes commands with Selenium Client Library (Java,C#,Python,Js,Ruby)\
	2. JSON Wire Protocol receives the command and convert it to a JSON format and send a REST API request to BrowserDriver over HTTP protocol\
	3. WebDriver will direct the request to the browser server\
	4. Browser will perform the operation and will communicate the response back to the BrowserDriver\
	5. BrowserDriver will send the response back to Selenium Client Library over HTTP protocol via JSON Wire Protocol

**How to launch a url ?**\
	IWebDriver driver = new ChromeDriver();
	driver.Url = "https://www.seleniumeasy.com/test"; 

**What are the browser navigation commands ?**\
	//to go back
        driver.Navigate().Back();

        //to go forward
        driver.Navigate().Forward();

        //to refresh
        driver.Navigate().Refresh();

        //Go to another URL
        driver.Navigate().GoToUrl("https://myntra.com");

**How to maximize a window ?**\
	IWebDriver driver = new ChromeDriver();
	driver.Manage().Window.Maximize();

**How to get PageTitle ?**\
	driver.Title;

**How to select a dropdown ? What are the methods available to select a dropdown value ?**\

**How to fetch the text of a web element ?**\
	element.Text

**How to select the checkbox and radio button ?**\
	using click() method

**How to handle Frames in xpath ?**\
	driver.SwitchTo().Frame("Xpath of Frame");
	or
	driver.SwitchTo().Frame(0);   // frameindex
	or
	driver.SwitchTo().Frame("framename");

**How to switch to a new window ? Which is the method used ?**\
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

**What is the difference between driver.CurrentWindowHandle and driver.WindowHandles ?**\
  driver.CurrentWindowHandle returns the address of the current browser tab, where the control is. It's return type is String

	driver.WindowHandles returns address of all open browser tabs and its return type is collection of String

**How can I perform drag and drop ?**\
	Use Actions Class 
	IWebElement source = driver.FindElement(By.XPath("//span[text()='Draggable 3']"));
       	IWebElement target = driver.FindElement(By.CssSelector("#mydropzone"));

       	Actions action = new Actions(driver);
        	action.DragAndDrop(source, target);
       	action.Perform();

**How to take a screenshot in selenium ?**\
	We have to cast driver to an Interface ITakesScreenshot;
	ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
        takesScreenshot.GetScreenshot().SaveAsFile("screenshot.jpeg", ScreenshotImageFormat.Jpeg);

**What are the different waits in selenium ? Which is best ?**\
	Implicit Wait\
	Explicit Wait\
	Fluent Wait\

**What is cross browser testing ? How can we achieve it in selenium ?**\
	Cross Browser Testing is a type of functional test to check that your web application works as expected in different browsers and in different browser versions.\ 
Example: Checking whether a test case is working on Chrome 96, Firefox,I.E and Chrome 90

if(browser.equalsIgnoreCase("firefox")){
			//create firefox instance
			driver = new FirefoxDriver(“//path);
		}
		else if(browser.equalsIgnoreCase("chrome")){
			//create chrome instance
			driver = new ChromeDriver(“//path);

**How To Handle Alerts ?**\
            //Handle alert
            IAlert alert = driver.SwitchTo().Alert();
            Console.WriteLine(alert.Text);
	
           //To enter text on an alert
            alert.SendKeys("This is a sample alert");

            //To cancel alert
            alert.Dismiss();

            //to accept an alert// click on OK
            alert.Accept();
	
            //to set auth credentials in alert
            alert.SetAuthenticationCredentials("username", "password");




