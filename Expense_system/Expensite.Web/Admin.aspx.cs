using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Expensite.Entity;
using Expensite.Business;

namespace Expensite.Web
{
    public partial class Admin : System.Web.UI.Page
    {
        AdminBusiness adminBusiness = new AdminBusiness();
        UserEntity userEntity = new UserEntity();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            userEntity.EMail = txtEmail.Text;
            userEntity.Password = txtPassword.Text;
            adminBusiness.InsertData(userEntity);
            ClearInputControls();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputControls();
        }
        public void ClearInputControls()
        {
            txtEmail.Text = String.Empty;
            txtPassword.Text = String.Empty;
        }
    }
}