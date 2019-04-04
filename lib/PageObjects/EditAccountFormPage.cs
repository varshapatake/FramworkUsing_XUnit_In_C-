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
    class EditAccountFormPage
    {
        private IWebDriver driver;
        [FindsBy(How = How.Name, Using = "a_type")]
        [CacheLookup]
        public IWebElement acc_type { get; set; }

        [FindsBy(How = How.Name, Using = "AccSubmit")]
        [CacheLookup]
        public IWebElement submit { get; set; }

        public EditAccountFormPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void edit_account()
        {
            try
            {
                SelectElement sel = new SelectElement(acc_type);
                IList<IWebElement> elem = sel.Options;

                if (elem[0].Selected)
                {
                    sel.SelectByValue(elem[1].GetAttribute("value"));
                }
                if (elem[1].Selected)
                {
                    sel.SelectByValue(elem[0].GetAttribute("value"));
                }
                submit.Click();
            }catch(Exception e)
            {
                Console.WriteLine(e);
                TakeScreenshot.takeScreenshotAs(driver, "edit_account_form");
            }

        }
    }
}
