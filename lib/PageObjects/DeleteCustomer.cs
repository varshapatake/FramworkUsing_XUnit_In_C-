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
    class DeleteCustomer
    {
        private IWebDriver driver;

        [FindsBy(How=How.LinkText,Using = "Delete Customer")]
        [CacheLookup]
        public IWebElement DeleteCustomerLink { get; set; }

        [FindsBy(How=How.Name,Using= "cusid")]
        [CacheLookup]
        public IWebElement CustomerId { get; set; }

        [FindsBy(How=How.Name,Using = "AccSubmit")]
        [CacheLookup]
        public IWebElement submit { get; set; }

        [FindsBy(How=How.Name,Using = "res")]
        [CacheLookup]
        public IWebElement reset { get; set; }

        public DeleteCustomer(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public void deleteCustomer(string id)
        {
            try { 
            DeleteCustomerLink.Click();
            CustomerId.Clear();
            CustomerId.SendKeys(id);
            submit.Click();
            driver.SwitchTo().Alert().Accept();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                TakeScreenshot.takeScreenshotAs(driver, "delete_customer");
            }
        }

        public void resetcheck(string id)
        {
            DeleteCustomerLink.Click();
            CustomerId.Clear();
            CustomerId.SendKeys(id);
            reset.Click();
        }
    }
}
