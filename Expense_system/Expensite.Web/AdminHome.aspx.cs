using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Expensite.Entity;
using Expensite.Business;
using System.Net;
using System.Collections;

namespace Expensite.Web
{
    public partial class AdminHome : System.Web.UI.Page
    {
        
        AdminBusiness adminBusiness = new AdminBusiness();
        UserEntity userEntity = new UserEntity();
        UpdateEntity updateEntity = new UpdateEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        
        public void ClearInputControls()
        {
            txtmail.Text = String.Empty;
            txtPassword.Text = String.Empty;
        }

       

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            bool userExist;
            userExist = adminBusiness.userInfo(txtmail.Text);
            if (userExist == false)
            {
                userEntity.EMail = txtmail.Text;
                userEntity.Password = txtPassword.Text;


                adminBusiness.InsertData(userEntity);
                string strBody = GenerateBodyForReport();
                strBody = string.Format(strBody, txtmail.Text, txtPassword.Text);
                SendEmail(txtmail.Text, "admin@gmail.com", "", "", "Expensite Credentials", strBody, null);
                ClearInputControls();
                string strErrorDesc = " Your Mail sent successfully";

                ClientScript.RegisterStartupScript(this.GetType(), "my alert", "alert('" + strErrorDesc + "');", true);
            }
            else
            {
                string strErrorDesc = "please Enter valid Email-Id";
                ClientScript.RegisterStartupScript(this.GetType(), "my alert", "alert('" + strErrorDesc + "');", true);
             //   Response.Write(@"<script language='javascript'>alert('" + strErrorDesc + " .');</script>");
            }
        }

        protected void btnClear_Click1(object sender, EventArgs e)
        {
            txtmail.Text = String.Empty;
            txtPassword.Text = String.Empty;
        }

        protected void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            updateEntity.Date = txtDate.Text;
            updateEntity.Description = txtUpdate.Text;
            adminBusiness.Upadates(updateEntity);

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
                string strErrorDesc = "Your Mail is sent successfully";
                ClientScript.RegisterStartupScript(this.GetType(), "my alert", "alert('" + strErrorDesc + "');", true);

           
            }
            catch (Exception Exc)
            {
                Exc.Message.ToString();
                return false;
            }
            return true;
        }

        public string GenerateBodyForReport()
        {
            string strBody = "<div>Hello User,<br /><br />Here is your Email-id and password for expensite <br />The Email is as given by you for company detalis<br /><br/>"
                             +"Email :{0}<br/>"+"Password :{1}<br/>"  + "<br />Thanks,<br />Expensite Team <div>";
            return strBody;
        }


    }
}