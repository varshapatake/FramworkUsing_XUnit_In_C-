using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitFramworkSameAsPytest.lib.PageObjects
{
    class NewAccount
    {
        private IWebDriver driver;

        [FindsBy(How = How.LinkText, Using = "New Account")]
        [CacheLookup]
        private IWebElement NewAccountLink { set; get; }

        [FindsBy(How = How.Name, Using = "cusid")]
        [CacheLookup]
        private IWebElement CustomerId{get;set;}

        [FindsBy(How=How.Name,Using = "selaccount")]
        [CacheLookup]
        private IWebElement AccountType { get; set; }

        [FindsBy(How=How.Name,Using = "inideposit")]
        [CacheLookup]
        private IWebElement InitialDeposite { get; set; }

        [FindsBy(How=How.Name,Using = "button2")]
        [CacheLookup]
        private IWebElement Submit { get; set; }

        [FindsBy(How=How.Name,Using = "reset")]
        [CacheLookup]
        private IWebElement Reset { get; set; }

        public NewAccount(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void newAccount(string cust_id,string acc_type,string initial_ammount)
        {
            NewAccountLink.Click();
            
            CustomerId.SendKeys(cust_id);

            SelectElement option = new SelectElement(AccountType);
            option.SelectByText(acc_type);

            
            InitialDeposite.SendKeys(initial_ammount);

            Submit.Click();
        }

        public void resetCheck(string cust_id, string acc_type, string initial_ammount)
        {
            NewAccountLink.Click();
            CustomerId.Clear();
            CustomerId.SendKeys(cust_id);

            SelectElement option = new SelectElement(AccountType);
            option.SelectByText(acc_type);

            InitialDeposite.Clear();
            InitialDeposite.SendKeys(initial_ammount);

            Reset.Click();
        }
    }
}
