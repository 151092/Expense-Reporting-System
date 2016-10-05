using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expensite.Entity;
using Expensite.Data;
using System.Web;

namespace Expensite.Business
{
    public class AdminBusiness
    {
        AdminData adminData = new AdminData();
        
        public object admindata()
        {
            return adminData.admindata();
        }
        public void InsertData(UserEntity userEntity)
        {
            
            adminData.InsertData(userEntity);
        }
        public bool MatchData(UserEntity userEntity)
        {
            bool result = adminData.MatchData(userEntity);
            if (result == true)
            {
           
                return true;
            }
            else
            {
                return false;
            }
        }
        public UserEntity GetUserData(string userEmailId)
        {
           return adminData.GetUserData(userEmailId);
        }
        public string forgotPassword(UserDetailEntity userDetail)
        {
            var password = "";
            password = adminData.forgotPassword(userDetail);
            return password;
        }

        public UserDetailEntity userName(int userId)
        {
            return adminData.userName(userId);
        }

        public void Upadates(UpdateEntity updateEntity)
        {
            adminData.Upadates(updateEntity);
        }
        public bool userInfo(string mail)
        {
            return adminData.userInfo(mail);
        }

    }
}
