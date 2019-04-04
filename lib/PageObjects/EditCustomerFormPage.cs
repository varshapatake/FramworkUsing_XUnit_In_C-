using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xUnitFramworkSameAsPytest.Screenshots.ScreenshotMethod;

namespace xUnitFramworkSameAsPytest.lib.PageObjects
{
    class EditCustomerFormPage
    {
        private IWebDriver driver;

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

        [FindsBy(How = How.Name, Using = "sub")]
        [CacheLookup]
        private IWebElement Submit { get; set; }
        public EditCustomerFormPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void edit_customer(string field_to_change, string add, string city, string state, string pin, string mobile, string email)
        {
            // DatabaseConnectorFixture db = new DatabaseConnectorFixture();
            // values=db.executeQuery(query);
            try
            {
                if (field_to_change.Equals("address"))
                {
                    Address.Clear();
                    Address.SendKeys(add);
                }
                if (field_to_change.Equals("city"))
                {
                    City.Clear();
                    City.SendKeys(city);
                }
                if (field_to_change.Equals("state"))
                {
                    State.Clear();
                    State.SendKeys(state);
                }
                if (field_to_change.Equals("pin"))
                {
                    PinNo.Clear();
                    PinNo.SendKeys(pin);
                }
                if (field_to_change.Equals("mobile"))
                {
                    TelephoneNo.Clear();
                    TelephoneNo.SendKeys(mobile);
                }
                if (field_to_change.Equals("email"))
                {
                    EmailId.Clear();
                    EmailId.SendKeys(email);
                }

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                // Assert.Equal("dfdg", driver.Title);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(Submit)).Click();
                
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                TakeScreenshot.takeScreenshotAs(driver, "edit_customer");
            }
        }
    }
}
