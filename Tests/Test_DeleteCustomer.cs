using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using xUnitFramworkSameAsPytest.lib.PageObjects;
using xUnitFramworkSameAsPytest.venv;
using System.Configuration;

namespace xUnitFramworkSameAsPytest.Tests
{
    [Collection("WebDriverCollection")]
    public class Test_DeleteCustomer
    {
        WebDriverFixture fixture;
        public Test_DeleteCustomer(WebDriverFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void test_DeleteCustomer()
        {
            DeleteCustomer cust = new DeleteCustomer(fixture.driver);
            cust.deleteCustomer(ConfigurationManager.AppSettings["cust_id"]);
        }
    }
}
