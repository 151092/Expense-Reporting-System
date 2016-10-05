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
    public partial class ChangePassword : System.Web.UI.Page
    {
        SettingBusiness settingBusiness = new SettingBusiness();
        UserEntity userEntity = new UserEntity();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btnChangePaswrd_Click(object sender, EventArgs e)
        {
            userEntity.UserId = Convert.ToInt32(Session["Id"]);
            settingBusiness.fetchPassword(userEntity);
            if (userEntity.Password == txtOldPassword.Text)
            {
                if (txtNewPassword.Text == txtConfirmPassword.Text)
                {
                    userEntity.UserId = Convert.ToInt32(Session["Id"]);
                    userEntity.Password = txtConfirmPassword.Text;
                    settingBusiness.changePassword(userEntity);
                    string strErrorDesc = " Your Password changed successfully";

                    ClientScript.RegisterStartupScript(this.GetType(), "my alert", "alert('" + strErrorDesc + "');", true);
                }
                else
                {
                    string strErrorDesc = "New password and confirm password not match...Plzzz try Again ";

                    ClientScript.RegisterStartupScript(this.GetType(), "my alert", "alert('" + strErrorDesc + "');", true);

                }

            }
            else
            {
                Response.Redirect("ErrorPage.aspx");
            }
        }
    }
}