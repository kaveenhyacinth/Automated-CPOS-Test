using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_Purchase_Order_System
{
    public partial class frmSupervisor : Form
    {
        public string UserName { get; set; }

        public frmSupervisor()
        {
            InitializeComponent();
        }

        public frmSupervisor(string usern)
        {
            this.UserName = usern;
            InitializeComponent();
        }


        private void FrmSupervisor_Load(object sender, EventArgs e)
        {
            DbHandler db = new DbHandler(UserName);

            lblProfile.Text = db.GetName();

            txtPo.Focus();
        }

        private void BtnL_Click(object sender, EventArgs e)
        {
            string PurOrderNo = txtPo.Text.Trim();
            if (!(PurOrderNo == ""))
            {
                DbHandler dbh = new DbHandler(int.Parse(txtPo.Text));

                if (dbh.Check())
                {

                    string ConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Customer_Purchase_Order_System\DataBase\stretchline.mdf;Integrated Security=True;Connect Timeout=30";
                    string InsertQuery = "SELECT * FROM tbl_salesOrder WHERE po_no=" + int.Parse(txtPo.Text) + "";

                    var con = new SqlConnection(ConString);
                    var cmd = new SqlCommand(InsertQuery, con);

                    try
                    {
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            txtPn.Text = (dr["po_no"].ToString());
                            txtN.Text = (dr["contact"].ToString());
                            txtemail.Text = (dr["email"].ToString());
                            txttel.Text = (dr["tel"].ToString());
                            txtf.Text = (dr["fax"].ToString());
                            txtDl.Text = (dr["deliver_location"].ToString());
                            txtDt.Text = (dr["delivary_type"].ToString());
                            txtDd.Text = (dr["delivery_date"].ToString());
                            txtBa.Text = (dr["bill_address"].ToString());
                            txtIcode.Text = (dr["item_code"].ToString());
                            txtCshade.Text = (dr["color_shade"].ToString());
                            txtQ.Text = (dr["quantity"].ToString());
                            txtUprice.Text = (dr["unit_price"].ToString());
                            txtT.Text = (dr["total_price"].ToString());
                            txtC.Text = (dr["currency"].ToString());
                            txtCurr.Text = (dr["currency"].ToString());
                            txtpT.Text = (dr["payment_term"].ToString());
                            txtIT.Text = (dr["inco_term"].ToString());
                            txtEb.Text = (dr["end_buyer"].ToString());
                            txtOd.Text = (dr["order_date"].ToString());
                            txtEd.Text = (dr["entry_date"].ToString());
                            txtCname.Text = (dr["cus_name"].ToString());
                            txtCemail.Text = (dr["cus_email"].ToString());
                            txtCaddress.Text = (dr["cus_add"].ToString());

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

                    btnSub.Enabled = true;
                    btnSub.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Sorry, We didn't receive that order yet.", "Automated Data Handler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                label29.Text = "Please Enter Valid Data";
                txtPo.Text = string.Empty;
                txtPo.Focus();
            }
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Do you wish to continue?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlg == DialogResult.Yes)
            {
                int Po_no = int.Parse(txtPn.Text.Trim());
                string Contact = txtN.Text.Trim();
                string Email = txtemail.Text.Trim();
                string Tel = txttel.Text.Trim();
                string Fax = txtf.Text.Trim();
                string Deliver_Location = txtDl.Text.Trim();
                string Delivary_Type = txtDt.Text.Trim();
                string Delivary_Date = txtDd.Text.Trim();
                string Bill_Address = txtBa.Text.Trim();
                string Item_Code = txtIcode.Text.Trim();
                string Color_Shade = txtCshade.Text.Trim();
                double Quantity = double.Parse(txtQ.Text.Trim());
                double Unit_Price = double.Parse(txtUprice.Text.Trim());
                double Total_Price = double.Parse(txtT.Text.Trim());
                string Currency = txtC.Text.Trim();
                string Payment_Term = txtpT.Text.Trim();
                string Inco_Term = txtIT.Text.Trim();
                string End_Buyer = txtEb.Text.Trim();
                string Order_Date = txtOd.Text.Trim();
                string Entry_Date = txtEd.Text.Trim();
                string Review_Date = txtRd.Text.Trim();
                string Cus_name = txtCname.Text.Trim();
                string Cus_mail = txtCemail.Text.Trim();
                string Cus_add = txtCaddress.Text.Trim();

                DbHandler db = new DbHandler(Po_no, Contact, Email, Tel, Fax, Deliver_Location, Delivary_Type, Delivary_Date, Bill_Address, Item_Code, Color_Shade, Quantity, Unit_Price, Total_Price, Currency, Payment_Term, Inco_Term, End_Buyer, Order_Date, Entry_Date, Review_Date, Cus_name, Cus_mail, Cus_add);
                db.UpdateOrder();
            }
           
        }




        //Misellanious




        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void GroupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void TextBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label19_Click(object sender, EventArgs e)
        {

        }

        private void Label22_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Label17_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }


    }
}
