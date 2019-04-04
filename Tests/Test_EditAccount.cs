using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using xUnitFramworkSameAsPytest.lib.PageObjects;
using xUnitFramworkSameAsPytest.venv;
using System.Configuration;

namespace xUnitFramworkSameAsPytest.Tests
{
    [Collection("WebDriverCollection")]
    public class Test_EditAccount
    {
        ITestOutputHelper output;
        WebDriverFixture webdriver;
        DataBaseFixture dbconnect;

        public Test_EditAccount(WebDriverFixture webdriver, DataBaseFixture dbconnect, ITestOutputHelper output)
        {
            this.webdriver = webdriver;
            this.dbconnect = dbconnect;
            this.output = output;
        }

        [Fact]
        public void edit_account()
        {
            EditAccount ed = new EditAccount(webdriver.driver);
            ed.edit_account(ConfigurationManager.AppSettings["edit_account_id"]);

            EditAccountFormPage ed_acc = new EditAccountFormPage(webdriver.driver);
            ed_acc.edit_account();

        }
    }
}
