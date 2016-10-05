using Expensite.Business;
using Expensite.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Net;
using System.Web.UI.WebControls;

namespace Expensite.Web
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        UserDetailEntity userdetail = new UserDetailEntity();
        AdminBusiness adminBusiness = new AdminBusiness();

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
       
            var password = "";
            userdetail.EMail = txtEmail1.Text;
            userdetail.MoblileNo = txtMobile.Text;
            password = adminBusiness.forgotPassword(userdetail);
            string strBody = GenerateBodyForForgetPassword();
            strBody = string.Format(strBody, password);
            if (password != null && password != string.Empty)
            {

                SendEmail(txtEmail1.Text, "expensite@gmail.com", "", "", "Your Password", strBody, null);
            }
            
        }

        private bool SendEmail(string To, string From, string CC, string BCC, string Subject, string Body, ArrayList EmailAttechment)
        {
            //To = "jitu@softwebsolutions.com";
            //========== Find the config application path ==========//
            System.Configuration.Configuration Config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(System.Web.HttpContext.Current.Request.ApplicationPath);

            //========== Find the mail setting from the web config file ==========//
            System.Net.Configuration.MailSettingsSectionGroup MailSettings = (System.Net.Configuration.MailSettingsSectionGroup)Config.GetSectionGroup("system.net/mailSettings");

            //========== Obtain the Network Credentials from the mailSettings section ==========//
           NetworkCredential Credential = new NetworkCredential(MailSettings.Smtp.Network.UserName, MailSettings.Smtp.Network.Password);

            //========== Create the SMTP Client ==========//
            System.Net.Mail.SmtpClient Client = new System.Net.Mail.SmtpClient();

            //========== Assign the host address ==========//
            Client.Host = MailSettings.Smtp.Network.Host;

            //========== Assign the network credentials to the smtp client ==========//
           Client.Credentials = Credential;

            //========== Create the mail object ==========//
            System.Net.Mail.MailMessage ObjEmail = new System.Net.Mail.MailMessage();
           
            //========== Assign the values to the mail object ==========//
            if (From == "") { ObjEmail.From = new System.Net.Mail.MailAddress(From); } else { ObjEmail.From = new System.Net.Mail.MailAddress(From); }
            string[] _Str_Email_Address = To.Split(';');
            foreach (string item in _Str_Email_Address)
            {
                ObjEmail.To.Add(item);
            }
            if (BCC.Length != 0)
                ObjEmail.Bcc.Add(BCC);
            if (CC.Length != 0)
                ObjEmail.CC.Add(CC);
            ObjEmail.Subject = Subject.Replace("\n", " ").Replace("\r", " ").Replace("\t", "");
            ObjEmail.IsBodyHtml = true;
            ObjEmail.Priority = System.Net.Mail.MailPriority.Normal;
            ObjEmail.DeliveryNotificationOptions = System.Net.Mail.DeliveryNotificationOptions.OnFailure;
            ObjEmail.Body = Body;
            

            //========== Check the email attachment for the email ==========//
            if (EmailAttechment != null && EmailAttechment.Count != 0)
            {
                for (int i = 0; i <= EmailAttechment.Count - 1; i++)
                {
                    System.Net.Mail.Attachment attachFile = new System.Net.Mail.Attachment(EmailAttechment[i].ToString());
                    ObjEmail.Attachments.Add(attachFile);
                }
            }
            try
            {
                Client.Send(ObjEmail);
            }
            catch (Exception Exc)
            {
                Exc.Message.ToString();
                return false;
            }
            return true;
        }

       public string GenerateBodyForForgetPassword()
         {
             string strBody = "<div>Hello User,<br /><br />You have requested to receive password via email.<br />So,here is your password : {0}<br />" 
                            + "<br />Thanks,<br />Expensite Team <div>";
             return strBody;
         }

    }
}


        
    
