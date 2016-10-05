using Expensite.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Expensite.Web
{
    public partial class DeleteAccount : System.Web.UI.Page
    {
        SettingBusiness settingBusiness = new SettingBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int UserId = Convert.ToInt32(Session["Id"]);
            settingBusiness.deleteAccount(UserId);

            Response.Redirect("Login.aspx");
            string strErrorDesc = " Your Account deleted successfully";

            ClientScript.RegisterStartupScript(this.GetType(), "my alert", "alert('" + strErrorDesc + "');", true);
        }
    }
}