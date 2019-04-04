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
    class EditAccount
    {
        private IWebDriver driver;
        [FindsBy(How = How.LinkText, Using = "Edit Account")]
        [CacheLookup]
        public IWebElement EditAccountLink { get; set; }

        [FindsBy(How = How.Name, Using = "accountno")]
        [CacheLookup]
        public IWebElement AccountNo { get; set; }

        [FindsBy(How = How.Name, Using = "AccSubmit")]
        [CacheLookup]
        public IWebElement Submit { get; set; }

        [FindsBy(How = How.Name, Using = "res")]
        [CacheLookup]
        public IWebElement Reset{ get; set; }

        public EditAccount(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public void edit_account(string acc_no)
        {
            try
            {
                EditAccountLink.Click();
                AccountNo.SendKeys(acc_no);
                Submit.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TakeScreenshot.takeScreenshotAs(driver, "edit_account");
            }
        }
       
        public void check_Reset(string acc_no)
        {
            EditAccountLink.Click();
            AccountNo.SendKeys(acc_no);
            Reset.Click();
        }
    }
}

