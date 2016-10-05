using Expensite.Business;
using Expensite.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Data;
namespace Expensite.Web
{
    public partial class AccountManager : System.Web.UI.Page
    {
        AccountManagerBusiness accountManagerBusiness = new AccountManagerBusiness();
        ReportEntity reportEntity = new ReportEntity();
        ExpenseEntity expenseEntity = new ExpenseEntity();
        string userName = System.Configuration.ConfigurationManager.AppSettings["UserName"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var ReportId = Request.QueryString["reportId"];
                if (ReportId != null && ReportId != String.Empty)
                {
                    lblReportId.Text = ReportId;
                    reportEntity = accountManagerBusiness.reportData(Convert.ToInt32(ReportId));
                    lblAmt.Text = Convert.ToString(reportEntity.Amount);
                    lblDate.Text = Convert.ToString(reportEntity.ReportDate);
                    lblName.Text = reportEntity.Owner;
                    lblApprover.Text = "Account Manager";

                    GridView1.DataSource = accountManagerBusiness.viewReport(Convert.ToInt32(ReportId));
                    GridView1.DataBind();

                }

            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            float x = 0;
            string expenseId = "";
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (((CheckBox)row.FindControl("checkBox2")).Checked == true)
                {
                    expenseEntity.ExpenseId = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["ExpenseID"].ToString());
                    expenseId += (expenseEntity.ExpenseId).ToString() + ',';
                    hdf.Value = expenseId;
                }

                else
                {
                    expenseEntity.ExpenseId = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["ExpenseID"].ToString());
                    accountManagerBusiness.rejectedExpense(expenseEntity.ExpenseId);
                }
            }
            GridBind();
            string strBody = GenerateBody();
            strBody = string.Format(strBody, lblName.Text, lblAmt.Text);

            SendEmail(lblName.Text,Session["Mail"].ToString(), "", "", "Approved Expense Amount", strBody, null);

        }
        public void GridBind()
        {
            string[] res = (hdf.Value).TrimEnd(',').Split(new string[] { "," }, StringSplitOptions.None);
            GridView1.DataSource = accountManagerBusiness.approvedExpense(res);
            GridView1.DataBind();
            List<float?> temp = new List<float?>();
            float? x = 0;
            temp = accountManagerBusiness.totalAmount(res);
            foreach (var t in temp)
            {
                x += t;
                lblAmt.Text = x.ToString();
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
                string strErrorDesc = " Your Mail sent successfully";

                ClientScript.RegisterStartupScript(this.GetType(), "my alert", "alert('" + strErrorDesc + "');", true);

            }
            catch (Exception Exc)
            {
                Exc.Message.ToString();
                return false;
            }
            return true;
        }

        public string GenerateBody()
        {
            string strBody = "<div>Hello,User:{0}<br /><br />Your approved amount is :{1}<br />your rejected expenses are sent in your account<br />" + "The approved amount will be reimbursed in your salary <br/>"
                          + "<br />Thanks,<br />Expensite Team <div>";
            return strBody;
        }
        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {


            GridView1.PageIndex = e.NewPageIndex;
            GridBind();
        }

        protected void btnPolicy_Click(object sender, EventArgs e)
        {
       Response.Write("<script type='text/javascript'> window.open('policy.pdf','_new'); </script>");
          
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            var ReportId = Request.QueryString["reportId"];
            accountManagerBusiness.rejectReport(Convert.ToInt32(ReportId));
            lblAmt.Text = string.Empty;
            GridView1.DataSource = null;
            GridView1.DataBind();
            string strBody = GenerateBody1();
            strBody= string.Format(strBody,lblName.Text, ReportId);
            SendEmail(lblName.Text, Session["Mail"].ToString(), "", "", "Report Rejected", strBody, null);
           
        }

        public string GenerateBody1()
        {
            string strBody = "<div>Hello,User<br/>:{0}<br /><br />Your Rejected Report is:{1}<br /><br />" + "Please check the report That has been sent in your account<br/>" + "<br />Thanks,<br />Expensite Team <div>";
            return strBody; 
        }
       



  


        





    }
}


