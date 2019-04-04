
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xUnitFramworkSameAsPytest.lib.DataBaseConnector
{
    public class DatabaseConnector
    {
    
        List<string> item = new List<string>();
        Dictionary<string, string> Register_items = new Dictionary<string, string>();
        Dictionary<string, string> newAccount_items = new Dictionary<string, string>();
        Dictionary<string, string> edit_customer = new Dictionary<string, string>();
        public Dictionary<string, string> executeQuery_register(string query, MySqlConnection DBConnection)
        {
            MySqlCommand cmd = new MySqlCommand(query, DBConnection);
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string Name = reader.GetString(0), Gender = reader.GetString(1), Dob = reader.GetString(2), Address = reader.GetString(3), City = reader.GetString(4), State = reader.GetString(5), Pin = reader.GetString(6), MobileNo = reader.GetString(7), Email = reader.GetString(8), Password = reader.GetString(9);
                    Register_items.Add("Name", Name);
                    Register_items.Add("Gender", Gender);
                    Register_items.Add("Dob", Dob);
                    Register_items.Add("Address", Address);
                    Register_items.Add("City", City);
                    Register_items.Add("State", State);
                    Register_items.Add("Pin", Pin);
                    Register_items.Add("MobileNo", MobileNo);
                    Register_items.Add("Email", Email);
                    Register_items.Add("Password", Password);
                }
            }
            reader.Close();
            return Register_items;
        }

        public void save_data_in_database(string query, MySqlConnection DBConnection)
        {
            MySqlCommand cmd = new MySqlCommand(query, DBConnection);
            MySqlDataReader reader;
            reader= cmd.ExecuteReader();
            reader.Close();
        }

        public void delete_data_from_database(string query, MySqlConnection DBConnection)
        {
            MySqlCommand cmd = new MySqlCommand(query, DBConnection);
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
        }


        public Dictionary<string, string> executeQuery_newAccount(string query, MySqlConnection DBConnection)
        {
            MySqlCommand cmd = new MySqlCommand(query, DBConnection);
            MySqlDataReader reader=cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string cust_id = reader.GetString(0), acc_type = reader.GetString(1), init_amt = reader.GetString(2);
                    newAccount_items.Add("cust_id", cust_id);
                    newAccount_items.Add("acc_type", acc_type);
                    newAccount_items.Add("init_amt", init_amt);
                }
            }
            reader.Close();
            return newAccount_items;
        }

        public Dictionary<string,string> get_edit_customer_data(string query, MySqlConnection DBConnection)
        {
            MySqlCommand cmd = new MySqlCommand(query, DBConnection);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string address = reader.GetString(0), city = reader.GetString(1), state = reader.GetString(2),pin=reader.GetString(3),mobile=reader.GetString(4),email=reader.GetString(5);
                    edit_customer.Add("address",address);
                    edit_customer.Add("city", city);
                    edit_customer.Add("state", state);
                    edit_customer.Add("pin", pin);
                    edit_customer.Add("mobile", mobile);
                    edit_customer.Add("email", email);
                }
            }
            reader.Close();
            return edit_customer;
        }
    } 
}
