using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Customer_Purchase_Order_System
{
    class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Login(string Usern, string Passw)
        {
            Username = Usern;
            Password = Passw;
        }
        public bool LoginAuthentication()
        {
            string ConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Customer_Purchase_Order_System\DataBase\stretchline.mdf;Integrated Security=True;Connect Timeout=30";
            string Query = "SELECT * FROM tbl_employee where username='"+Username+"' AND password='"+Password+"'";

            //Fill a data table with the results
            var adapter = new SqlDataAdapter(Query, ConString);
            var dtbl = new DataTable();
            adapter.Fill(dtbl);

            //Login Authentication
            if(dtbl.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
