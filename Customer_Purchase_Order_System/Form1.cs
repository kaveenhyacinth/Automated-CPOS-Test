using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_Purchase_Order_System
{
    public partial class frmLogin : Form
    {
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string UserName = txtUsername.Text;
            string Password = txtPwd.Text;

            Login log = new Login(txtUsername.Text.Trim(), txtPwd.Text.Trim());
            bool validity = log.LoginAuthentication();
            if (validity)
            {
                if (txtUsername.Text.Contains("s"))
                {
                    frmSupervisor supervisor = new frmSupervisor((UserName));
                    supervisor.Show();
                }
                else if (txtUsername.Text.Contains("d"))
                {
                    frmDEO deo = new frmDEO(UserName);
                    deo.Show();
                }

            }
            else
            {  
                lblerror.Text = "Please Enter valid data!";
            }
        }

        private void TxtUserName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";

                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";

                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPwd_Enter(object sender, EventArgs e)
        {
            if(txtPwd.Text== "Password")
            {
                txtPwd.Text = "";
                txtPwd.PasswordChar = '*';
                txtPwd.ForeColor = Color.Black;
            }
        }

        private void txtPwd_Leave(object sender, EventArgs e)
        {
            if (txtPwd.Text == "")
            {
                txtPwd.PasswordChar = '\0';
                txtPwd.Text = "Password";

                txtPwd.ForeColor = Color.Gray;
            }
        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel6_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
