using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitFramworkSameAsPytest.lib.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Name, Using = "uid")]
        [CacheLookup]
        private IWebElement UserId{ get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        [CacheLookup]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Name, Using = "btnLogin")]
        [CacheLookup]
        private IWebElement LoginBtn { get; set; }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void loginToApptication(string username,string password)
        {
            
            UserId.SendKeys("mgr123");
            Password.SendKeys("mgr!23");
            LoginBtn.Click();
        }
    }
}

