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
    public partial class UserProfile : System.Web.UI.Page
    {
        ProfileBusiness pb = new ProfileBusiness();
        UserDetailEntity userDetailEntity = new UserDetailEntity();
        

        protected void Page_Load(object sender, EventArgs e)
        {
                
                if (!IsPostBack)
                {
                    userDetailEntity.UserId = Convert.ToInt32(Session["Id"]);
                    pb.maintainData(userDetailEntity);
                    if (userDetailEntity.UserDetailId != null && userDetailEntity.UserDetailId > 0)
                    {
                        hdf.Value = (userDetailEntity.UserDetailId).ToString();
                        rbGender.Text = userDetailEntity.Gender;
                        txtFName.Text = userDetailEntity.FName;
                        txtMName.Text = userDetailEntity.MName;
                        txtLName.Text = userDetailEntity.LName;

                        txtBOD.Text = (Convert.ToDateTime(userDetailEntity.DOB)).ToString("dd/MM/yyyy");
                        txtEmailId.Text = userDetailEntity.EMail;
                        txtUserType.Text = userDetailEntity.UserType;
                        txtMobileNo.Text = userDetailEntity.MoblileNo;
                        txtAppartment.Text = userDetailEntity.Apartment;
                        txtStreet.Text = userDetailEntity.Street;
                        txtCity.Text = userDetailEntity.City;
                        txtPincode.Text = userDetailEntity.PinCode;
                    }
                    else
                    {
                        clearInputControls();
                    }
                }
               

           
        }
       
    
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(hdf.Value)))
            {
                updateData(userDetailEntity);
            }
            else
            {
                insertDetails(userDetailEntity);
            }
        }
        public void insertDetails(UserDetailEntity userDetailEntity)
        {
            userDetailEntity.UserId = Convert.ToInt32(Session["Id"]);
            userDetailEntity.Gender = rbGender.Text;
            userDetailEntity.FName = txtFName.Text;
            userDetailEntity.MName = txtMName.Text;
            userDetailEntity.LName = txtLName.Text;
            userDetailEntity.DOB = Convert.ToDateTime(txtBOD.Text);
            userDetailEntity.EMail = txtEmailId.Text;
            userDetailEntity.UserType = txtUserType.Text;
            userDetailEntity.MoblileNo = txtMobileNo.Text;
            userDetailEntity.Apartment = txtAppartment.Text; ;
            userDetailEntity.Street = txtStreet.Text;
            userDetailEntity.City = txtCity.Text;
            userDetailEntity.PinCode = txtPincode.Text;
            pb.insertDetails(userDetailEntity);
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            clearInputControls();
        }
        public void clearInputControls()
        {
            rbGender.Text = String.Empty;
            txtFName.Text = String.Empty;
            txtMName.Text = String.Empty;
            txtLName.Text = String.Empty;
            txtBOD.Text = String.Empty;
            txtEmailId.Text = String.Empty;
            txtUserType.Text = String.Empty;
            txtMobileNo.Text = String.Empty;
            txtAppartment.Text = String.Empty; ;
            txtStreet.Text = String.Empty;
            txtCity.Text = String.Empty;
            txtPincode.Text = String.Empty;

        }
        public void updateData(UserDetailEntity userDetailEntity)
        {
            userDetailEntity.UserDetailId = Convert.ToInt32(hdf.Value);
            userDetailEntity.UserId = Convert.ToInt32(Session["Id"]);
            userDetailEntity.Gender = rbGender.Text;
            userDetailEntity.FName = txtFName.Text;
            userDetailEntity.MName = txtMName.Text;
            userDetailEntity.LName = txtLName.Text;

            userDetailEntity.DOB = Convert.ToDateTime(txtBOD.Text);
            userDetailEntity.EMail = txtEmailId.Text;
            userDetailEntity.UserType = txtUserType.Text;
            userDetailEntity.MoblileNo = txtMobileNo.Text;
            userDetailEntity.Apartment = txtAppartment.Text; ;
            userDetailEntity.Street = txtStreet.Text;
            userDetailEntity.City = txtCity.Text;
            userDetailEntity.PinCode = txtPincode.Text;
            pb.updateData(userDetailEntity);
        }
    }
}