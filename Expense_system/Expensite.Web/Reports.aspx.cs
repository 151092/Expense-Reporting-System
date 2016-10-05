using Expensite.Business;
using Expensite.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Expensite.Web
{
    public partial class Reports : System.Web.UI.Page
    {
        ReportBusiness reportBusiness = new ReportBusiness();
        ReportEntity reportEntity = new ReportEntity();
        ExpenseEntity expenseEntity = new ExpenseEntity();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    reportGridBind();
            //}
           
            reportEntity.UserId = Convert.ToInt32(Session["Id"]);
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblName.Text = Session["Mail"].ToString();
            txtFrom.Text = Session["Mail"].ToString();
            var expenseId = Request.QueryString["expenseId"];
            reportGridBind();
            var reportId = Request.QueryString["reportId"];
            hdf.Value = reportId;
            if (expenseId != null)
            {
                btnSave.Visible = true;
                btnCancl.Visible = false;
                btnSubmit.Visible = false;
                pnlSubmit.Visible = false;
                string[] res = expenseId.TrimEnd(',').Split(new string[] { "," }, StringSplitOptions.None);
                int userId = Convert.ToInt32(Session["Id"]);
                bool isDeleted = true;
                reportBusiness.updateFlag(res);
                GridView1.DataSource = reportBusiness.reportGridBind(userId, res, isDeleted);
                GridView1.DataBind();

                //reportBusiness.deleteMultipleExpense(userId, res);


            }
            if (reportId != null)
            {
                btnCancl.Visible = true;
                btnSave.Visible = false;
                pnlSubmit.Visible = true;
                btnSubmit.Visible = true;
                GridView1.DataSource = reportBusiness.openReport(Convert.ToInt32(reportId));
                GridView1.DataBind();

            }


        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            var expenseId = Request.QueryString["expenseId"];
            if (expenseId != null)
            {
                string[] res = expenseId.TrimEnd(',').Split(new string[] { "," }, StringSplitOptions.None);
                int Id = 0;
                reportEntity.UserId = Convert.ToInt32(Session["Id"]);
                reportEntity.ReportName = txtReport.Text;
                string MyString = lblDate.Text;
                DateTime myDateTime;
                myDateTime= new DateTime();
                myDateTime = DateTime.ParseExact(MyString, "dd/MM/yyyy", null);
                reportEntity.ReportDate = myDateTime;
                reportEntity.Owner = lblName.Text;
                int reportId = reportBusiness.insertReportDetails(reportEntity, res, Id);
                //reportBusiness.updateFlag(res);
                Response.Redirect("ReportGrid.aspx?reportId=" + reportId);


            }

            reportGridBind();
        }
        public void reportGridBind()
        {
            var expenseId = Request.QueryString["expenseId"];
            if (expenseId != null)
            {
                string[] res = expenseId.TrimEnd(',').Split(new string[] { "," }, StringSplitOptions.None);
                int userId = Convert.ToInt32(Session["Id"]);

                // for (int i = 0; i <= res.Length; i++)
                //{
                bool isDeleted = true;
                GridView1.DataSource = reportBusiness.reportGridBind(userId, res, isDeleted);
                GridView1.DataBind();
                // }

            }
        }
        public void onRowCommand(Object sender, GridViewCommandEventArgs e)
        {
            var Id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "DeleteButton")
            {
                var expenseId = Request.QueryString["expenseId"];
                if (expenseId != null)
                {
                    string[] res = expenseId.TrimEnd(',').Split(new string[] { "," }, StringSplitOptions.None);

                    int userId = Convert.ToInt32(Session["Id"]);
                    bool isDeleted = true;
                    GridView1.DataSource = reportBusiness.deleteExpense(userId, res, Id, isDeleted);
                    GridView1.DataBind();
                    //  reportBusiness.deleteFromRefs(Id);
                }
                else
                {
                    var reportId = Convert.ToInt32(Request.QueryString["reportId"]);
                    int userId = Convert.ToInt32(Session["Id"]);
                    GridView1.DataSource = reportBusiness.deleteExpenseAfter(userId, reportId, Id);
                    GridView1.DataBind();
                    reportBusiness.deleteFromRefs(Id);

                }



            }

        }
        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {


            GridView1.PageIndex = e.NewPageIndex;
            reportGridBind();
        }



        protected void btnCancl_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportGrid.aspx");
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
            string strBody = "<div>Hello Account Manager,<br /><br />Here is The Expense Report of User {0} <br />To see the Report Please click Button <br /><br/>"
                               + "<a href='http://localhost:5241/Login.aspx?ReportId={1}'> View Report </a> <br /> "
                                +    "<br />Thanks,<br />Expensite Team <div>";
            return strBody;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            var reportId = Convert.ToInt32(Request.QueryString["reportId"]);
            reportBusiness.reportflag(reportId);
            string strBody = GenerateBodyForReport();
            strBody = string.Format(strBody, txtFrom.Text, hdf.Value);
            SendEmail(txtTo.Text, txtFrom.Text, "", "", "Expense Report", strBody, null);
            
        }

       

       
    }
}


      

