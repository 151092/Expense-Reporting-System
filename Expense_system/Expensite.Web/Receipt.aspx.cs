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
    public partial class WebForm2 : System.Web.UI.Page
    {
        int id;
        ReceiptBusiness receiptBusiness = new ReceiptBusiness();
        REntity rEntity = new REntity();
        ReceiptEntity receiptEntity = new ReceiptEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridData();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            receiptUpload();
            insertReceipt(rEntity);
        }
        private void receiptUpload()
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string filename = System.IO.Path.GetFileName(FileUploadControl.PostedFile.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/Receipt/") + filename);
                   // Response.Write("Upload status: The file  uploaded <br/>");
                }
                catch (Exception ex)
                {
                    Response.Write("Upload status: The file could not be uploaded. The following error occured:<br/> " + ex.Message);
                }

            }
           
        }
        public void insertReceipt(REntity rEntity)
        {
            rEntity.UserId = Convert.ToInt32(Session["Id"]);
            rEntity.ReceiptPath = FileUploadControl.FileName;
            receiptBusiness.insertReceipt(rEntity);
            gridData();
        }

        private void gridData()
        {
            int userId = Convert.ToInt32(Session["Id"]);
            GridView1.DataSource = receiptBusiness.gridData(userId);
            GridView1.DataBind();
        }

        public void onRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "DeleteCommand")
            {
                rEntity.ReceiptID = id;
                receiptBusiness.deleteData(rEntity);
                gridData();
            }
        }
        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {


            GridView1.PageIndex = e.NewPageIndex;
            gridData();
        }
        protected void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach(GridViewRow  gvRow in GridView1.Rows)
            {
                CheckBox check = (CheckBox)gvRow.FindControl("checkBox2");
                check.Checked = true;
          }
        }

        protected void btnExpense_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
                if (((CheckBox)row.FindControl("checkBox2")).Checked == true)
                {
                    rEntity.ReceiptID = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["ReceiptID"].ToString());
                    
                    receiptBusiness.addToExpense(rEntity);
                    Response.Redirect("Expenses.aspx?ReceiptId=" + rEntity.ReceiptID);
                }

        }

    }
}