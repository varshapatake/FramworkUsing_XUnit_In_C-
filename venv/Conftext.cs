using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Configuration;
using xUnitFramworkSameAsPytest.lib.DataBaseConnector;
using MySql.Data.MySqlClient;
using Xunit.Abstractions;

namespace xUnitFramworkSameAsPytest.venv
{
    public class WebDriverFixture : IDisposable
    {
     // IWebDriver driver;
        public WebDriverFixture()
        {
            driver = new ChromeDriver(@"C:\Users\varsha_patke\Downloads\chromedriver_win32 (1)\");
            driver.Manage().Window.Maximize();
            driver.Url = ConfigurationManager.AppSettings["URL"];//"http://demo.guru99.com/V4/index.php";
            driver.FindElement(By.Name("uid")).SendKeys(ConfigurationManager.AppSettings["username"]);
            driver.FindElement(By.Name("password")).SendKeys(ConfigurationManager.AppSettings["password"]);
            driver.FindElement(By.Name("btnLogin")).Click();
        }
       
        public void Dispose()
        {
            driver.Close();
        }
        public IWebDriver driver { get;  set; }   
    }

    public class DataBaseFixture:IDisposable
    {
       
        public MySqlConnection DBConnection { get; set; }
        public DataBaseFixture() //connecting to database
        {
            
          string databaseConnector = "datasource=127.0.0.1;port=3306;username=root;password=;database=bankproject;";
           DBConnection = new MySqlConnection(databaseConnector);
                try
                {
                    DBConnection.Open();
                    Console.WriteLine("Successfully Connected to database");
                }
                catch (Exception e)
                {
                    Console.WriteLine("error while connecting to database");
                }
        }
        
        public void Dispose()
        {
          DBConnection.Close();
            Console.WriteLine("successfully close database connection");
        }
    }


    [CollectionDefinition("WebDriverCollection")]
    public class WebDriverDefinition : ICollectionFixture<WebDriverFixture>, ICollectionFixture<DataBaseFixture>
    {
        //Nothing needed here
    }
}
