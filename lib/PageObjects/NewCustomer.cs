using MySql.Data.MySqlClient;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using xUnitFramworkSameAsPytest.lib.DataBaseConnector;
using xUnitFramworkSameAsPytest.Screenshots.ScreenshotMethod;

namespace xUnitFramworkSameAsPytest.lib.PageObjects
{ 
    class NewCustomer 
    {      
        private IWebDriver driver;
      
        [FindsBy(How = How.LinkText, Using = "New Customer")]
        [CacheLookup]
        private IWebElement NewCustomerLink { get; set; }

        [FindsBy(How = How.Name, Using = "name")]
        [CacheLookup]
        private IWebElement Name { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='radio']")]
        [CacheLookup]
        private IList<IWebElement> Gender { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@onkeyup='validatedob();']")]
        [CacheLookup]
        private IWebElement DateOfBirth{ get; set; }

        [FindsBy(How = How.Name, Using = "addr")]
        [CacheLookup]
        private IWebElement Address { get; set; }

        [FindsBy(How = How.Name, Using = "city")]
        [CacheLookup]
        private IWebElement City { get; set; }

        [FindsBy(How = How.Name, Using = "state")]
        [CacheLookup]
        private IWebElement State { get; set; }

        [FindsBy(How = How.Name, Using = "pinno")]
        [CacheLookup]
        private IWebElement PinNo { get; set; }

        [FindsBy(How = How.Name, Using = "telephoneno")]
        [CacheLookup]
        private IWebElement TelephoneNo { get; set; }

        [FindsBy(How = How.Name, Using = "emailid")]
        [CacheLookup]
        private IWebElement EmailId { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        [CacheLookup]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Name, Using = "sub")]
        [CacheLookup]
        private IWebElement Submit { get; set; }
        public NewCustomer(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void register(string name,string gender,string dob,string add,string city,string state,string pin,string mobile,string email,string password)
        {
            
            try
            {
                NewCustomerLink.Click();
                Name.SendKeys(name);
                foreach (var gender1 in Gender)
                {
                    String gen = gender1.GetAttribute("value");
                    if (String.Equals(gen, gender, StringComparison.OrdinalIgnoreCase))
                    {
                        gender1.Click();
                    }
                }
                DateOfBirth.SendKeys(dob);
                Address.SendKeys(add);
                City.SendKeys(city);
                State.SendKeys(state);
                PinNo.SendKeys(pin);
                TelephoneNo.SendKeys(mobile);
                EmailId.SendKeys(email);
                Password.SendKeys(password);

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(Submit)).Click();
                
            }
           
            catch(Exception e)
            {
                Console.WriteLine(e);
                TakeScreenshot.takeScreenshotAs(driver, "register");
            }
        }

    }
}
