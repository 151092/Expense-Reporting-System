using Expensite.Business;
using Expensite.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Expensite.Web
{
    public partial class Expenses : System.Web.UI.Page
    {
        int expenseId;
        ReceiptBusiness receiptBusiness = new ReceiptBusiness();
        ReceiptEntity receiptEntity = new ReceiptEntity();
        REntity rEntity = new REntity();
        ExpenseEntity expenseEntity = new ExpenseEntity();
        ExpenseTypeEntity expenseTypeEntity = new ExpenseTypeEntity();
        CurrencyTypeEntity currencyTypeEntity = new CurrencyTypeEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fetchExpenseType();
                fetchCurrencyType();
                
                ExpenseGridBind();
                fetchExpenseType1();
                var receiptId = Request.QueryString["ReceiptId"];
                if (receiptId != null)
                {
                    ModalPopupExtender.Show();
                    addToExpense(rEntity);
                    receiptImage.AlternateText = receiptEntity.ReceiptPath;
                }

               
            }
            //ExpenseGridBind();
            //if (dlCurrency.)
            //{
            //    ModalPopupExtender.Show();
            //}
            
        }
        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            
           ExpenseGrid.PageIndex = e.NewPageIndex;
           ExpenseGridBind();
        }
 

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (GridViewRow row in ExpenseGrid.Rows)
                if (((CheckBox)row.FindControl("checkGrid")).Checked == true)
                {

                    expenseEntity.ExpenseId = Convert.ToInt32(ExpenseGrid.DataKeys[row.RowIndex].Values["ExpenseID"].ToString());
                    hdf1.Value = (expenseEntity.ExpenseId).ToString();
                    receiptBusiness.editRecord(expenseEntity);
                    ModalPopupExtender.Show();
                    hdf.Value = (expenseEntity.receiptE.ReceiptId).ToString();
                    txtAmount.Text = (expenseEntity.receiptE.Amount).ToString();
                    txtComment.Text = expenseEntity.receiptE.Comment;
                    txtDate.Text = (Convert.ToDateTime(expenseEntity.receiptE.ReceiptDate)).ToString("dd/MM/yyyy");
                    dlCurrency.SelectedValue = (expenseEntity.receiptE.CurrencyTypeId).ToString();
                    dlExpenseType.SelectedValue = (expenseEntity.receiptE.ExpenseTypeId).ToString();
                    receiptImage.ImageUrl = "~/Receipt/" + expenseEntity.receiptE.ReceiptPath;
                    receiptImage.AlternateText = expenseEntity.receiptE.ReceiptPath;

                    count++;

                }
            if (count > 1)
            {
                ModalPopupExtender.Hide();
            }

        }
        protected void btnSave_click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(hdf.Value)))
            {
                updateRecord(expenseEntity);
            }
            else
            {
                receiptUpload();
               
                receiptEntity.ReceiptDate = txtDate.Text;
                if (!receipt.HasFile)
                {
                    receiptEntity.ReceiptPath = receiptImage.AlternateText;
                }
                else
                {
                    receiptEntity.ReceiptPath = receipt.FileName;

                }
                // receiptEntity.ReceiptPath = receipt.FileName;
                receiptEntity.CurrencyTypeId = Convert.ToInt32(dlCurrency.SelectedValue.ToString());
                
                receiptEntity.Amount = Convert.ToInt64(txtAmount.Text);
                receiptEntity.ExpenseTypeId = Convert.ToInt32(dlExpenseType.SelectedValue.ToString());
                receiptEntity.Comment = txtComment.Text;
                receiptEntity.IsDeleted = false;
                expenseEntity.UserId = Convert.ToInt32(Session["Id"]);

                receiptEntity.expense = expenseEntity;
                //rEntity.UserId = Convert.ToInt32(Session["Id"]);
                //rEntity.ReceiptPath = receiptEntity.ReceiptPath;
                //receiptEntity.re = rEntity;
                receiptBusiness.insertReceiptDetail(receiptEntity);


            }
            ExpenseGridBind();
            ClearInputControls();

        }
        public void updateRecord(ExpenseEntity expenseEntity)
        {
            if (!receipt.HasFile)
            {
                receiptEntity.ReceiptPath = receiptImage.AlternateText;
            }
            else
            {
                receiptEntity.ReceiptPath = receipt.FileName;

            }
            expenseEntity.ExpenseId = Convert.ToInt32(hdf1.Value);
            expenseEntity.UserId = Convert.ToInt32(Session["Id"]);
            receiptEntity.ReceiptId = Convert.ToInt32(hdf.Value);
            receiptEntity.Amount = Convert.ToInt64(txtAmount.Text);
           
            receiptEntity.ReceiptDate = txtDate.Text;
            // receiptEntity.ReceiptPath=receipt.FileName;
            receiptEntity.CurrencyTypeId = Convert.ToInt32((dlCurrency.SelectedValue).ToString());
            receiptEntity.ExpenseTypeId = Convert.ToInt32((dlExpenseType.SelectedValue).ToString());
            receiptEntity.Comment = txtComment.Text;
            expenseEntity.receiptE = receiptEntity;

            receiptBusiness.updateRecord(expenseEntity);
        }

        private void receiptUpload()
        {
            if (receipt.HasFile)
            {
                try
                {
                    string filename = System.IO.Path.GetFileName(receipt.PostedFile.FileName);
                    receipt.SaveAs(Server.MapPath("~/Receipt/") + filename);
                    receiptBusiness.retrieveImage(receiptEntity);

                }
                catch (Exception ex)
                {
                    Response.Write("Upload status: The file could not be uploaded. The following error occured:<br/> " + ex.Message);
                }

            }
            else
            {
                if (receiptImage.ImageUrl == String.Empty)
                {
                    string strErrorDesc = "Please select one file";

                    Console.WriteLine(@"<script language='javascript'>alert('The following errors have occurred: \n" + strErrorDesc + " .');</script>");
                }
            }

        }


        public void fetchExpenseType()
        {
            var expenseType = receiptBusiness.fetchExpenseType();
            dlExpenseType.DataSource = expenseType;
            dlExpenseType.DataValueField = "ExpenseTypeId";
            dlExpenseType.DataTextField = "ExpenseTypeName";
            dlExpenseType.DataBind();

        }
        public void fetchCurrencyType()
        {
            var currencyType = receiptBusiness.fetchCurrencyType();
            dlCurrency.DataSource = currencyType;
            dlCurrency.DataValueField = "CurrencyTypeId";
            dlCurrency.DataTextField = "CurrencyTypeName";
         
            dlCurrency.DataBind();

        }

        public void ExpenseGridBind()
        {
            int userId = Convert.ToInt32(Session["Id"]);
            bool isdeleted = false;
            ExpenseGrid.DataSource = receiptBusiness.expenseGridBind(userId, isdeleted);
            ExpenseGrid.DataBind();

        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in ExpenseGrid.Rows)
                if (((CheckBox)row.FindControl("checkGrid")).Checked == true)
                {
                    expenseEntity.ExpenseId = Convert.ToInt32(ExpenseGrid.DataKeys[row.RowIndex].Values["ExpenseID"].ToString());
                    receiptBusiness.deleteRecord(expenseEntity);
                }
            ExpenseGridBind();
        }
        protected void ClearInputControls()
        {
            txtAmount.Text = String.Empty;
            txtComment.Text = String.Empty;
            txtDate.Text = String.Empty;
            //lblSymbol.Text = String.Empty;
            hdf.Value = String.Empty;
            hdf1.Value = String.Empty;
            
            dlCurrency.SelectedIndex = 0;
            dlExpenseType.SelectedIndex = 0;

        }

        protected void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in ExpenseGrid.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("checkGrid");
                check.Checked = true;
            }
        }
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            if (receipt.HasFile)
            {

                string path = (Server.MapPath("~/Receipt/") + System.IO.Path.GetFileName(receipt.PostedFile.FileName));
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                if (file.Exists)
                {
                    Response.Clear();
                    Response.ContentType = MimeType(Path.GetExtension(path));
                    Response.AddHeader("Content-Disposition",
                        string.Format("attachment; filename = {0}",
                        System.IO.Path.GetFileName(path)));
                    Response.AddHeader("Content-Length", file.Length.ToString("F0"));
                    Response.TransmitFile(path);
                    Response.End();
                }
                else
                {
                    Response.Write("This file does not exist.");
                }
            }
            else
            {
                string path = (Server.MapPath("~/Receipt/") + System.IO.Path.GetFileName(receiptImage.AlternateText));
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                if (file.Exists)
                {
                    Response.Clear();
                    Response.ContentType = MimeType(Path.GetExtension(path));
                    Response.AddHeader("Content-Disposition",
                        string.Format("attachment; filename = {0}",
                        System.IO.Path.GetFileName(path)));
                    Response.AddHeader("Content-Length", file.Length.ToString("F0"));
                    Response.TransmitFile(path);
                    Response.End();
                }
                else
                {
                    Response.Write("This file does not exist.");
                }

            }

        }

        public static string MimeType(string Extension)
        {
            string mime = "application/octetstream";
            if (string.IsNullOrEmpty(Extension))
                return mime;
            string ext = Extension.ToLower();
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (rk != null && rk.GetValue("Content Type") != null)
                mime = rk.GetValue("Content Type").ToString();
            return mime;
        }



        public void addToExpense(REntity rEntity)
        {
            var receiptId = Request.QueryString["ReceiptId"];
            rEntity.ReceiptID = Convert.ToInt32(receiptId);
            receiptBusiness.addToExpense(rEntity);
            receiptImage.ImageUrl = "~/Receipt/" + rEntity.ReceiptPath;
            receiptEntity.ReceiptPath = rEntity.ReceiptPath;
            receiptBusiness.deleteData(rEntity);
        }

        protected void btnAddToReport_Click(object sender, EventArgs e)
        {
            string expenseId = "";
            foreach (GridViewRow row in ExpenseGrid.Rows)
            {
                if (((CheckBox)row.FindControl("checkGrid")).Checked == true)
                {
                    expenseEntity.ExpenseId = Convert.ToInt32(ExpenseGrid.DataKeys[row.RowIndex].Values["ExpenseID"].ToString());
                    expenseEntity.IsDeleted = true;
                    expenseId += (expenseEntity.ExpenseId).ToString() + ',';

                }

            } 
            
            Response.Redirect("Reports.aspx?expenseID=" + expenseId);
        }


        public void fetchExpenseType1()
        {
            var expenseType1 = receiptBusiness.fetchExpenseType();
            drpExpenseType.DataSource = expenseType1;
            drpExpenseType.DataValueField = "ExpenseTypeId";
            drpExpenseType.DataTextField = "ExpenseTypeName";
            drpExpenseType.DataBind();

        }
   


        protected void drpExpenseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(drpExpenseType.SelectedValue) != 0)
            {
                ExpenseGrid.DataSource = receiptBusiness.viewExpenseType(Convert.ToInt32(Session["Id"]), Convert.ToInt32(drpExpenseType.SelectedValue));
                ExpenseGrid.DataBind();
               
            }
            drpExpenseType.SelectedIndex = 0;
           
        }

        //protected void drpCurrencyType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (lblSymbol.Text == string.Empty)
        //    {
        //        int currencyId = Convert.ToInt32(dlCurrency.SelectedValue);
        //        lblSymbol.Text = receiptBusiness.currencySymbol(currencyId);
        //        ModalPopupExtender.Show();
        //    }
        //}

    }
}
  

