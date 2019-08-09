using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net.Mail;


namespace Customer_Purchase_Order_System
{
    class Notifier
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Sid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Notifier(string id)
        {
            Sid = id;
        }

        public void SendMailSupervisor()
        {
            From = "client.stretchline@gmail.com";
            To = "alwiskaveen@gmail.com";
            Username = "client.stretchline@gmail.com";
            Password = "Kaveenhyacinth1";

            string sub = "New Sales Order: " + Sid;
            string body = "Dear Sir/Madam,\n\nWe received a new sales order details. The purchase order number is " + Sid + ". Please review the details.\n\nThank you.\nBest Regards,\nStretchLine PVT LTD";

            MailMessage mail = new MailMessage(From, To, sub, body);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential(Username, Password);
            client.Send(mail);

            MessageBox.Show("Notification has been sent to the supervisor", "Automated Mail Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SendMailCustomer()
        {

            From = "client.stretchline@gmail.com";
            To = "alwiskaveen@gmail.com";
            Username = "client.stretchline@gmail.com";
            Password = "Kaveenhyacinth1";

            string sub = "Order On Processing: " + Sid;
            string body = "Dear Sir/Madam,\n\nWe just reviewed your sales order "+Sid+". Once the Yarn Lab done with the lab test you will be notified.\n\nThank you.\n\nBest Regards,\nStretchLine PVT LTD.";

            MailMessage mail = new MailMessage(From, To, sub, body);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential(Username, Password);
            client.Send(mail);
        }

        public void SendMailYarnLab()
        {

            From = "client.stretchline@gmail.com";
            To = "alwiskaveen@gmail.com";
            Username = "client.stretchline@gmail.com";
            Password = "Kaveenhyacinth1";

            string sub = "New Lab Test: " + Sid;
            string body = "Dear Sir/Madam,\n\nWe just reviewed "+Sid+" sales order. Please continue the order confirmation process.\n\nThank you.\n\nBest Regards,\nStretchLine PVT LTD.";

            MailMessage mail = new MailMessage(From, To, sub, body);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential(Username, Password);
            client.Send(mail);

            MessageBox.Show("Notification has been sent to the customer and to the Yarn Lab", "Automated Mail Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
