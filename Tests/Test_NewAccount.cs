using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using xUnitFramworkSameAsPytest.lib.DataBaseConnector;
using xUnitFramworkSameAsPytest.lib.PageObjects;
using xUnitFramworkSameAsPytest.venv;

namespace xUnitFramworkSameAsPytest.Tests
{ 
    [Collection("WebDriverCollection")]
    public class Test_NewAccount
    {
        private readonly ITestOutputHelper output;
        WebDriverFixture webdriver;
        DataBaseFixture dbConnect;
        public Test_NewAccount(WebDriverFixture webdriver, DataBaseFixture dbConnect, ITestOutputHelper output)
        {
            
            this.webdriver = webdriver;
            this.dbConnect = dbConnect;
            this.output = output;
        }

        [Fact]
        public void testNewAccount()
        {
            //feaching data from database
            Dictionary<string, string> newAccount_items = new Dictionary<string, string>();
            DatabaseConnector db = new DatabaseConnector();
            string query = "SELECT * FROM `new_account` WHERE customer_id= " + ConfigurationManager.AppSettings["acc_no"];
            newAccount_items=db.executeQuery_newAccount(query, dbConnect.DBConnection);


            //creating new account
            NewAccount acc = new NewAccount(webdriver.driver);
            acc.newAccount(newAccount_items["cust_id"], newAccount_items["acc_type"], newAccount_items["init_amt"]);
            output.WriteLine("successfully created new account");

            //storing new account info into database
            Dictionary<string, string> registered_values = new Dictionary<string, string>();
            NewAccountSuccessfull new_acc = new NewAccountSuccessfull(webdriver.driver);
            registered_values = new_acc.registered_newAccount_data_storing_in_database();
            string query1 = "INSERT INTO `registered_newaccount_info`(`account_id`, `customer_id`, `customer_name`, `email`, `acc_type`, `datae_of_open`, `current_amt`) " +
                "VALUES ("+ registered_values["acc_id"] +","+ registered_values["cust_id"] +",'"+ registered_values["cust_name"] +"','"+ registered_values["cust_email"] + "','"+ registered_values["cust_acc_type"] + "','"+ registered_values["cust_doo"] + "',"+ registered_values["cust_camount"] + ")";
            db.save_data_in_database(query1, dbConnect.DBConnection);

        }
    }
}
