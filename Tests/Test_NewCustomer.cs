using MySql.Data.MySqlClient;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using xUnitFramworkSameAsPytest.lib.DataBaseConnector;
using xUnitFramworkSameAsPytest.lib.PageObjects;
using xUnitFramworkSameAsPytest.Screenshots.ScreenshotMethod;
using xUnitFramworkSameAsPytest.venv;
using System.Configuration;

namespace xUnitFramworkSameAsPytest.Tests
{
    [Collection("WebDriverCollection")]
    public class Class1 
    {
        //public IWebDriver driver;
        private readonly ITestOutputHelper output;
        string gender = "f";
        DataBaseFixture dbConnect;
         WebDriverFixture fixture;
        public Class1(WebDriverFixture fixture, DataBaseFixture dbConnect, ITestOutputHelper output)
        {
            this.fixture = fixture;
            this.dbConnect = dbConnect;
            this.output = output;
        }
         
        [Fact]
        public void registration()
        {
            Dictionary<string, string> item = new Dictionary<string, string>();
            Dictionary<string, string> user_data = new Dictionary<string, string>();

            //getting new customer data from database
            string query = "select * from new_customer where ID="+ ConfigurationManager.AppSettings["regitration_id"];
            output.WriteLine(query);
            DatabaseConnector db = new DatabaseConnector();
            item =db.executeQuery_register(query, dbConnect.DBConnection);

            //fill registration form
            NewCustomer cust = new NewCustomer(fixture.driver);
            output.WriteLine(item["Gender"]);
            cust.register(item["Name"],item["Gender"], item["Dob"], item["Address"], item["City"], item["State"], item["Pin"], item["MobileNo"], item["Email"], item["Password"]);

            //inserting registered user data into database
            RegistrationSuccessfull reg = new RegistrationSuccessfull(fixture.driver);
            user_data = reg.registered_data_storing_in_database();
            
            //query to insert data in database
            string query1 = "INSERT INTO `registered_user_info`(`customer_id`, `customer_name`, `gender`, `birthdate`, `address`, `city`, `state`, `pin`, `mobile`, `email`)" +
                "VALUES("+user_data["cust_id"]+ ",'"+ user_data["cust_name"] +"','"+ user_data["cust_gender"]+"' , '" + user_data["cust_dob"] + "','" + user_data["cust_add"] + "','" + user_data["cust_city"] + "','" + user_data["cust_state"] + "'," + user_data["cust_pin"] + "," + user_data["cust_phone"] + ",'" + user_data["cust_email"] + "')";

            db.save_data_in_database(query1, dbConnect.DBConnection);
            output.WriteLine("successfully stored data in database");

            //deleting registered data from new customer table
            string query3 = "DELETE FROM `new_customer` WHERE id="+ ConfigurationManager.AppSettings["regitration_id"];
            db.delete_data_from_database(query3, dbConnect.DBConnection);
            output.WriteLine("successfully deleted registered data from new_customer table");
        }
     }
  }


