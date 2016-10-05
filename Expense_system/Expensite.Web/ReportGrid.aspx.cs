using Expensite.Business;
using Expensite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Expensite.Web
{
    public partial class ReportGrid : System.Web.UI.Page
    {
        ReportBusiness reportBusiness = new ReportBusiness();
        ReportEntity reportEntity = new ReportEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            var reportId=Request.QueryString["reportId"];
            var expenseId = Request.QueryString["expenseId"];
            if (!IsPostBack)
            {
                reportDataBind(reportEntity);
            }
               
            //if (reportId != null)
            //{
            //    gridReport.DataSource = reportBusiness.reportDataBind(reportEntity, Convert.ToInt32(reportId));
            //    gridReport.DataBind();
            //}

        }
        public void reportDataBind(ReportEntity reportEntity)
        {
            reportEntity.UserId = Convert.ToInt32(Session["Id"]);
             gridReport.DataSource = reportBusiness.reportDataBind(reportEntity);
             gridReport.DataBind();
            
        }
        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {


            gridReport.PageIndex = e.NewPageIndex;
            reportDataBind(reportEntity);
        }
        public void gridRowCommand(Object sender, GridViewCommandEventArgs e)
        {
            var Id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "OpenButton")
            {   
                Response.Redirect("Reports.aspx?reportId=" +Id);
            }
            if (e.CommandName == "DeleteButton")
            {
                int userId = Convert.ToInt32(Session["Id"]);
                reportBusiness.deleteReport(Id, userId);
                reportDataBind(reportEntity);
            }

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            gridReport.DataSource = reportBusiness.sortByDate(Convert.ToInt32(Session["Id"]),txtFromDate.Text,txtToDate.Text);
            gridReport.DataBind();
            txtFromDate.Text = string.Empty;
            txtToDate.Text = string.Empty;
        }
    }
}