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
    class NewAccountSuccessfull
    {
        private IWebDriver driver;
        Dictionary<string, string> registered_values = new Dictionary<string, string>();

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Account ID')]//following-sibling::td")]
        [CacheLookup]
        private IWebElement account_id { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Customer ID')]//following-sibling::td")]
        [CacheLookup]
        private IWebElement customer_id{ get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Customer Name')]//following-sibling::td")]
        [CacheLookup]
        private IWebElement customer_name { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Email')]//following-sibling::td")]
        [CacheLookup]
        private IWebElement email { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Account Type')]//following-sibling::td")]
        [CacheLookup]
        private IWebElement acc_type { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Date of Opening')]//following-sibling::td")]
        [CacheLookup]
        private IWebElement date_of_open { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Current Amount')]//following-sibling::td")]
        [CacheLookup]
        private IWebElement current_amount { get; set; }

        
        public NewAccountSuccessfull(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public Dictionary<string, string> registered_newAccount_data_storing_in_database()
        {
       
            try
            {
                registered_values.Add("acc_id", account_id.Text);
                registered_values.Add("cust_id", customer_id.Text);
                registered_values.Add("cust_name", customer_name.Text);
                registered_values.Add("cust_email", email.Text);
                registered_values.Add("cust_acc_type", acc_type.Text);
                registered_values.Add("cust_doo", date_of_open.Text);
                registered_values.Add("cust_camount", current_amount.Text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TakeScreenshot.takeScreenshotAs(driver, "registered_newAccount_data_storing_in_database");
            }
            return registered_values;
        }
    }
}
