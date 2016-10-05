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
    public partial class login1 : System.Web.UI.Page
    {
        AdminBusiness adminBusiness = new AdminBusiness();
        UserEntity userEntity = new UserEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            var ReportId = Request.QueryString["reportId"];
            hdf.Value = ReportId;

           
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            userEntity.EMail = txtEmail.Text;
            userEntity.Password = txtPassword.Text;
           bool result= adminBusiness.MatchData(userEntity);
           
           if (result == true)
           {
               userEntity = adminBusiness.GetUserData(txtEmail.Text);
               Session["Mail"] = userEntity.EMail;
               Session["Id"] = userEntity.UserId;
               if (Session["Mail"].ToString() == "accountManager@gmail.com" )//&& hdf.Value!=string.Empty && hdf.Value!=null
               {
                   Response.Redirect("AccountManager.aspx?reportId=" + hdf.Value);
               }
               else
               {
                   Response.Redirect("Expenses.aspx");
               }
           }
           else if (txtEmail.Text == "admin@yahoo.com" && txtPassword.Text == "admin")
           {
               Response.Redirect("AdminHome.aspx");
           }
           //else if(txtEmail.Text == userName && txtPassword.Text== password)
           // {
           //     Session["AccountManager"] = true;
           //     Response.Redirect("AccountManager.aspx?reportId="+hdf.Value);
           // }

           else
           {
               Response.Redirect("ErrorPage.aspx");
           }
        }
      
        protected void lnkForgot_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }
    }
}