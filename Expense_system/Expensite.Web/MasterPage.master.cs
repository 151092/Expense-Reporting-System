using Expensite.Business;
using Expensite.Entity;
using Expensite.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Expensite.Web
{

    public partial class MasterPage : System.Web.UI.MasterPage
    {
        AdminBusiness adminBusiness = new AdminBusiness();
        UserEntity userEntity = new UserEntity();
        UserDetailEntity userDetailEntity = new UserDetailEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            rptRSS.DataSource = adminBusiness.admindata();
            rptRSS.DataBind();
            int userId;
            if (!IsPostBack)
            {
                if (Session["Mail"] == null)
                {
                    Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Cache.SetNoStore();
                    Response.Redirect("Login.aspx");
                }
                userId = Convert.ToInt32(Session["Id"]);
                userDetailEntity = adminBusiness.userName(userId);
                if (userDetailEntity != null)
                {
                    lblUserName.Text = userDetailEntity.FName + " " + userDetailEntity.LName;
                }
                else
                {
                    lblUserName.Text = Session["Mail"].ToString();
                }
               
                if (Session["Mail"].ToString()== "accountManager@gmail.com")
                {
                    Analytic.Visible = true;
                  
                }
                else
                {
                    Analytic.Visible = false;
                }
            }
            //if (Convert.ToBoolean(Session["AccountManager"]) == true)
            //{
            //    Analytic.Visible = true;
            //    lblUserName.Text = userName;
            //}
            //else
            //{
            //    Analytic.Visible = false;
            //}

        }
        protected string FormatForXML(object input)
        {
            string data = input.ToString();      // cast the input to a string

            // replace those characters disallowed in XML documents
            data = data.Replace("&", "&amp;");
            data = data.Replace("\"", "&quot;");
            data = data.Replace("'", "&apos;");
            data = data.Replace("<", "&lt;");
            data = data.Replace(">", "&gt;");

            return data;
        }
       
      
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            Response.Redirect("Login.aspx");
 
        }
     
    }
}
