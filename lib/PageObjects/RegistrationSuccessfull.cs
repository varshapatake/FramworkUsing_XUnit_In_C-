using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xUnitFramworkSameAsPytest.Screenshots.ScreenshotMethod;

namespace xUnitFramworkSameAsPytest.lib.PageObjects
{
    class RegistrationSuccessfull
    {
        private IWebDriver driver;
        Dictionary<string, string> registered_values = new Dictionary<string, string>();

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Customer ID')]//following-sibling::td")]
        [CacheLookup]
        private IWebElement customer_id { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Customer Name')]//following-sibling::td")]
        [CacheLookup]
        private IWebElement customer_name { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Gender')]//following-sibling::td")]
        [CacheLookup]
        private IWebElement Cust_gender { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Birthdate')]//following-sibling::td")]
        [CacheLookup]
        private IWebElement DateOfBirth { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Address')]//following-sibling::td")]
        [CacheLookup]
        private IWebElement Address { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'City')]//following-sibling::td")]
        [CacheLookup]
        private IWebElement City { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'State')]//following-sibling::td")]
        [CacheLookup]
        private IWebElement State { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Pin')]//following-sibling::td")]
        [CacheLookup]
        private IWebElement PinNo { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Mobile No.')]//following-sibling::td")]
        [CacheLookup]
        private IWebElement TelephoneNo { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Email')]//following-sibling::td")]
        [CacheLookup]
        private IWebElement EmailId { get; set; }

       
        public RegistrationSuccessfull(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public Dictionary<string,string> registered_data_storing_in_database()
        {
            // DatabaseConnectorFixture db = new DatabaseConnectorFixture();
            // values=db.executeQuery(query);
            try { 
            registered_values.Add("cust_id", customer_id.Text);
            registered_values.Add("cust_name", customer_name.Text);
            registered_values.Add("cust_gender", Cust_gender.Text);
            registered_values.Add("cust_dob", DateOfBirth.Text);
            registered_values.Add("cust_add", Address.Text);
            registered_values.Add("cust_city", City.Text);
            registered_values.Add("cust_state", State.Text);
            registered_values.Add("cust_pin", PinNo.Text);
            registered_values.Add("cust_phone", TelephoneNo.Text);
            registered_values.Add("cust_email", EmailId.Text);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TakeScreenshot.takeScreenshotAs(driver, "registered_data_storing_in_database");
            }
            return registered_values;
        }
    }
}
