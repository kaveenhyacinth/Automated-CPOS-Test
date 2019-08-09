using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Customer_Purchase_Order_System
{
    class DbHandler
    {
        public int Po_no { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Deliver_Location { get; set; }
        public string Delivary_Type { get; set; }
        public string Delivary_Date { get; set; }
        public string Bill_Address { get; set; }
        public string Item_Code { get; set; }
        public string Color_Shade { get; set; }
        public double Quantity { get; set; }
        public double Unit_Price { get; set; }
        public double Total_Price { get; set; }
        public string Currency { get; set; }
        public string Payment_Term { get; set; }
        public string Inco_Term { get; set; }
        public string End_Buyer { get; set; }
        public string Order_Date { get; set; }
        public string Entry_Date { get; set; }

        public string Review_Date { get; set; }
        public string Cus_name { get; set; }
        public string Cus_mail { get; set; }
        public string Cus_add { get; set; }

        public string Username { get; set; }


        public DbHandler(int pono, string contact, string email, string tel, string fax, string delLocation, string delType, string delDate, string bill, string itemCode, string colorShade, double quanty, double unitPrice, double totalPrice, string currency, string paymentType, string incoType, string endBuyer, string orderDate, string entryDate, string reviewDate, string cusName, string cusEmail, string cusAdd)
        {
            this.Po_no = pono;
            this.Contact = contact;
            this.Email = email;
            this.Tel = tel;
            this.Fax = fax;
            this.Deliver_Location = delLocation;
            this.Delivary_Type = delType;
            this.Delivary_Date = delDate;
            this.Bill_Address = bill;
            this.Item_Code = itemCode;
            this.Color_Shade = colorShade;
            this.Quantity = quanty;
            this.Unit_Price = unitPrice;
            this.Total_Price = totalPrice;
            this.Currency = currency;
            this.Payment_Term = paymentType;
            this.Inco_Term = incoType;
            this.End_Buyer = endBuyer;
            this.Order_Date = orderDate;
            this.Entry_Date = entryDate;
            this.Review_Date = reviewDate;
            this.Cus_name = cusName;
            this.Cus_mail = cusEmail;
            this.Cus_add = cusAdd;
        }

        public DbHandler(int pono, string contact, string email, string tel, string fax, string delLocation, string delType, string delDate, string bill, string itemCode, string colorShade, double quanty, double unitPrice, double totalPrice, string currency, string paymentType, string incoType, string endBuyer, string orderDate, string entryDate, string cusName, string cusEmail, string cusAdd)
        {
            this.Po_no = pono;
            this.Contact = contact;
            this.Email = email;
            this.Tel = tel;
            this.Fax = fax;
            this.Deliver_Location = delLocation;
            this.Delivary_Type = delType;
            this.Delivary_Date = delDate;
            this.Bill_Address = bill;
            this.Item_Code = itemCode;
            this.Color_Shade = colorShade;
            this.Quantity = quanty;
            this.Unit_Price = unitPrice;
            this.Total_Price = totalPrice;
            this.Currency = currency;
            this.Payment_Term = paymentType;
            this.Inco_Term = incoType;
            this.End_Buyer = endBuyer;
            this.Order_Date = orderDate;
            this.Entry_Date = entryDate;
            this.Cus_name = cusName;
            this.Cus_mail = cusEmail;
            this.Cus_add = cusAdd;

        }

        public DbHandler(string username)
        {
            this.Username = username;
        }

        public DbHandler(int po)
        {
            this.Po_no = po;
        }

        public void SaveOrder()
        {
            if (!Check())
            {

                string ConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Customer_Purchase_Order_System\DataBase\stretchline.mdf;Integrated Security=True;Connect Timeout=30";
                string InsertQuery = "INSERT INTO tbl_salesOrder(po_no, contact, email, tel, fax, deliver_location, delivary_type, delivery_date, bill_address, item_code, color_shade, quantity, unit_price, total_price, currency, payment_term, inco_term, end_buyer, order_date, entry_date, cus_name, cus_email, cus_add, confirmation) VALUES (" + Po_no + ", '" + Contact + "', '" + Email + "', '" + Tel + "', '" + Fax + "', '" + Deliver_Location + "', '" + Delivary_Type + "', '" + Delivary_Date + "', '" + Bill_Address + "', '" + Item_Code + "', '" + Color_Shade + "', " + Quantity + ", " + Unit_Price + ", " + Total_Price + ", '" + Currency + "', '" + Payment_Term + "', '" + Inco_Term + "', '" + End_Buyer + "', '" + Order_Date + "', '" + Entry_Date + "', '"+Cus_name+"', '"+Cus_mail+"', '"+Cus_add+"', 'NA')";

                var con = new SqlConnection(ConString);
                var cmd = new SqlCommand(InsertQuery, con);


                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();

                    Notifier ntf = new Notifier(Po_no.ToString());
                    ntf.SendMailSupervisor();
                }
                catch (Exception)
                {
                    MessageBox.Show("Connection_Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }

            }
            else
            {
                MessageBox.Show("You have already saved this order", "Look Out!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public bool Check()
        {
            string ConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Customer_Purchase_Order_System\DataBase\stretchline.mdf;Integrated Security=True;Connect Timeout=30";
            string sql = "SELECT * FROM tbl_salesOrder WHERE po_no=" + Po_no + "";

            SqlDataAdapter sda = new SqlDataAdapter(sql, ConString);
            DataTable set = new DataTable();

            sda.Fill(set);

            if (set.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        

        public void UpdateOrder()
        {
            string ConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Customer_Purchase_Order_System\DataBase\stretchline.mdf;Integrated Security=True;Connect Timeout=30";
            string InsertQuery = "UPDATE tbl_salesOrder SET contact='" + Contact + "', email='" + Email + "', tel='" + Tel + "', fax='" + Fax + "', deliver_location='" + Deliver_Location + "', delivary_type='" + Delivary_Type + "', delivery_date='" + Delivary_Date + "', bill_address='" + Bill_Address + "', item_code='" + Item_Code + "', color_shade='" + Color_Shade + "', quantity=" + Quantity + ", unit_price=" + Unit_Price + ", total_price=" + Total_Price + ", currency='" + Currency + "', payment_term='" + Payment_Term + "', inco_term='" + Inco_Term + "', end_buyer='" + End_Buyer + "', order_date='" + Order_Date + "', entry_date='" + Entry_Date + "', review_date='" + Review_Date + "', cus_name='"+Cus_name+"', cus_email='"+Cus_mail+"', cus_add='"+Cus_add+"', confirmation='confirmed' WHERE po_no=" + Po_no + "";

            var con = new SqlConnection(ConString);
            var cmd = new SqlCommand(InsertQuery, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                Notifier cusNtf = new Notifier(Po_no.ToString());
                cusNtf.SendMailCustomer();

                Notifier yarnNtf = new Notifier(Po_no.ToString());
                yarnNtf.SendMailYarnLab();
            }
            catch (Exception)
            {
                MessageBox.Show("Connection_Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

        }


        public string GetName()
        {
            string fName, lName, fullName;

            string ConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Customer_Purchase_Order_System\DataBase\stretchline.mdf;Integrated Security=True;Connect Timeout=30";
            string InsertQuery = "SELECT f_name, l_name FROM tbl_employee WHERE emp_id='"+Username+"'";

            var con = new SqlConnection(ConString);
            var cmd = new SqlCommand(InsertQuery, con);

            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    fName = (dr["f_name"].ToString());
                    lName = (dr["l_name"].ToString());

                    fullName = fName + " " + lName;

                    return fullName;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Connection_Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            return "Hi There!";

        }

    }
}
        //public void SubmitOrder()
        //{
        //    string ConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Customer_Purchase_Order_System\DataBase\stretchline.mdf;Integrated Security=True;Connect Timeout=30";
        //    string InsertQuery = "INSERT INTO tbl_salesOrder (po_no, contact, email, tel, fax, deliver_location, delivary_type, delivery_date, bill_address, item_code, color_shade, quantity, unit_price, total_price, currency, payment_term, inco_term, end_buyer, order_date, entry_date, review_date, cus_name, cus_email, cus_add) VALUES (" + Po_no + ", '" + Contact + "', '" + Email + "', '" + Tel + "', '" + Fax + "', '" + Deliver_Location + "', '" + Delivary_Type + "', '" + Delivary_Date + "', '" + Bill_Address + "', '" + Item_Code + "', '" + Color_Shade + "', " + Quantity + ", " + Unit_Price + ", " + Total_Price + ", '" + Currency + "', '" + Payment_Term + "', '" + Inco_Term + "', '" + End_Buyer + "', '" + Order_Date + "', '" + Entry_Date + "', '" + Review_Date + "', '" + Cus_name + "', '" + Cus_mail + "', '" + Cus_add + "')";

        //    var con = new SqlConnection(ConString);
        //    var cmd = new SqlCommand(InsertQuery, con);

        //    try
        //    {
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Connection_Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
