using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Customer_Purchase_Order_System
{
    public partial class frmDEO : Form
    {
        public string UserName { get; set; }

        public frmDEO()
        {
            InitializeComponent();
        }

        public frmDEO(string usern)
        {
            this.UserName = usern;
            InitializeComponent();
        }

        private void FrmDEO_Load(object sender, EventArgs e)
        {
            DbHandler db = new DbHandler(UserName);

            lblProfile.Text = db.GetName();

            txtPO.Focus();
        }

        private void BtnL_Click(object sender, EventArgs e)
        {
            string PurOrderNo = txtPO.Text.Trim();
            if (!(PurOrderNo == ""))
            {
                XmlDocument XmlDoc = new XmlDocument();

                try
                {
                    XmlDoc.Load(@"P:\" + PurOrderNo + ".xml");

                    XmlElement root = XmlDoc.DocumentElement;
                    string id = root.GetElementsByTagName("PurOrderNo")[0].Attributes[0].InnerText;
                    if (id == PurOrderNo)
                    {
                        label24.Text = string.Empty;

                        txtCname.Text = root.GetElementsByTagName("CusName")[0].InnerText;
                        txtCemail.Text = root.GetElementsByTagName("CusE-mail")[0].InnerText;
                        txtCaddress.Text = root.GetElementsByTagName("CusAddress")[0].InnerText;
                        txtPn.Text = root.GetElementsByTagName("PONo")[0].InnerText;
                        txtC.Text = root.GetElementsByTagName("Currency")[0].InnerText;
                        txtCurr.Text = root.GetElementsByTagName("Currency")[0].InnerText;
                        txtDt.Text = root.GetElementsByTagName("DelType")[0].InnerText;
                        txtOd.Text = root.GetElementsByTagName("Odate")[0].InnerText;
                        txtT.Text = root.GetElementsByTagName("tot")[0].InnerText;
                        txtDd.Text = root.GetElementsByTagName("Delidate")[0].InnerText;
                        txtDl.Text = root.GetElementsByTagName("DeliLoc")[0].InnerText;
                        txtBa.Text = root.GetElementsByTagName("BillAddress")[0].InnerText;
                        txtIcode.Text = root.GetElementsByTagName("ItemCode")[0].InnerText;
                        txtCshade.Text = root.GetElementsByTagName("ColorShade")[0].InnerText;
                        txtQ.Text = root.GetElementsByTagName("Qty")[0].InnerText;
                        txtUprice.Text = root.GetElementsByTagName("UnitPrice")[0].InnerText;
                        txtPT.Text = root.GetElementsByTagName("PayTerm")[0].InnerText;
                        txtIT.Text = root.GetElementsByTagName("IncoTerm")[0].InnerText;
                        txtEb.Text = root.GetElementsByTagName("EndBuyer")[0].InnerText;
                        txtN.Text = root.GetElementsByTagName("ConName")[0].InnerText;
                        txtemail.Text = root.GetElementsByTagName("ConE-mail")[0].InnerText;
                        txttel.Text = root.GetElementsByTagName("ConTel")[0].InnerText;
                        txtf.Text = root.GetElementsByTagName("ConFax")[0].InnerText;
                        //txtDl.Text = root.GetElementsByTagName("OrderDate")[0].InnerText;

                    }
                    else
                    {
                        label24.Text = "Please Enter Valid Data";
                        txtPO.Text = string.Empty;
                        txtPO.Focus();
                    }
                }
                catch (Exception)
                {
                    label24.Text = "There is no such Order";
                }
            }
            else
            {
                label24.Text = "Please Enter Valid Data";
                txtPO.Text = string.Empty;
                txtPO.Focus();
            }

            btnS.Enabled = true;
        }

        private void BtnS_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Do you wish to continue?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(dlg == DialogResult.Yes)
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
                string Payment_Term = txtPT.Text.Trim();
                string Inco_Term = txtIT.Text.Trim();
                string End_Buyer = txtEb.Text.Trim();
                string Order_Date = txtOd.Text.Trim();
                string Entry_Date = txtEd.Text.Trim();
                string Cus_name = txtCname.Text.Trim();
                string Cus_mail = txtCemail.Text.Trim();
                string Cus_add = txtCaddress.Text.Trim();

                DbHandler db = new DbHandler(Po_no, Contact, Email, Tel, Fax, Deliver_Location, Delivary_Type, Delivary_Date, Bill_Address, Item_Code, Color_Shade, Quantity, Unit_Price, Total_Price, Currency, Payment_Term, Inco_Term, End_Buyer, Order_Date, Entry_Date, Cus_name, Cus_mail, Cus_add);
                db.SaveOrder();
            }
            //else if(dlg == DialogResult.No)
            //{
            //    MessageBox.Show("Order not saved!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "s001")
            {
                txtSe.Text = "carrimsr@strline.lk";
            }
            else if(comboBox1.Text == "s002")
            {
                txtSe.Text = "nirushanatmk@strline.lk";
            }
        }



        //Misellanious



        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtN_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label24_Click(object sender, EventArgs e)
        {

        }

    }
}
