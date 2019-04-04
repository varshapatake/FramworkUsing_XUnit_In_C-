using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitFramworkSameAsPytest.lib.PageObjects
{
    class EditCustomer1
    {
        private IWebDriver driver;
        [FindsBy(How=How.LinkText,Using= "Edit Customer")]
        [CacheLookup]
        public IWebElement EditCustomerLink{ get; set; }

        [FindsBy(How=How.Name,Using = "cusid")]
        [CacheLookup]
        public IWebElement CustomerID { get; set; }

        [FindsBy(How=How.Name,Using = "AccSubmit")]
        [CacheLookup]
        public IWebElement Submit { get; set; }

        [FindsBy(How=How.Name,Using ="")]
        [CacheLookup]
        public IWebElement Reset { get; set; }

        public EditCustomer1(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }


        public  void editCustomer(string id)
        {
            EditCustomerLink.Click();
            CustomerID.SendKeys(id);
            Submit.Click();
        }

        public void checkReset(string id)
        {
            EditCustomerLink.Click();
            CustomerID.SendKeys(id);
            Reset.Click();
        }
    }
}
