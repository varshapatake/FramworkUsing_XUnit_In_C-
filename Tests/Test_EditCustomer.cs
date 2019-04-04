using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using xUnitFramworkSameAsPytest.lib.PageObjects;
using xUnitFramworkSameAsPytest.venv;
using System.Configuration;
using xUnitFramworkSameAsPytest.lib.DataBaseConnector;
using Xunit.Abstractions;

namespace xUnitFramworkSameAsPytest.Tests
{
    [Collection("WebDriverCollection")]
    public class Test_EditCustomer
    {
        ITestOutputHelper output;
        WebDriverFixture webdriver;
        DataBaseFixture dbconnect;
        public Test_EditCustomer(WebDriverFixture webdriver, DataBaseFixture dbconnect,ITestOutputHelper output)
        {
            this.webdriver = webdriver;
            this.dbconnect = dbconnect;
            this.output = output;
        }

        [Fact]
         public void test_EditCustomer()
        {
            //getting data from database
            Dictionary<string, string> edit_customer_data = new Dictionary<string, string>();
            DatabaseConnector db = new DatabaseConnector();
            string query = "SELECT * FROM `edit_customer` WHERE Id="+ ConfigurationManager.AppSettings["edit_customer_id"];
            edit_customer_data = db.get_edit_customer_data(query, dbconnect.DBConnection);

            //providing id of customer which info need to edit
            output.WriteLine(ConfigurationManager.AppSettings["cust_id"]);
            EditCustomer1 ed_cust = new EditCustomer1(webdriver.driver);
            ed_cust.editCustomer(ConfigurationManager.AppSettings["cust_id"]);

            //filling edit customer form
            EditCustomerFormPage ed = new EditCustomerFormPage(webdriver.driver);
            output.WriteLine(ConfigurationManager.AppSettings["cust_field_to_change"]);
            ed.edit_customer(ConfigurationManager.AppSettings["cust_field_to_change"], edit_customer_data["address"], edit_customer_data["city"], edit_customer_data["state"], edit_customer_data["pin"], edit_customer_data["mobile"], edit_customer_data["email"]);
        }
    }
}
