using Expensite.Data.Model;
using Expensite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensite.Data
{
    public class SettingData
    {
        ExpensiteDBDataContext db = new ExpensiteDBDataContext();
        User user = new User();
        public void fetchPassword(UserEntity userEntity)
        {
            var oldPassword = (from s in db.Users
                               where s.UserId == userEntity.UserId
                               select s).FirstOrDefault();
            userEntity.Password = oldPassword.Password;


        }
        public void changePassword(UserEntity userEntity)
        {
            var uapdatePassword = (from s in db.Users
                                   where s.UserId == userEntity.UserId
                                   select s).FirstOrDefault();
            uapdatePassword.Password = userEntity.Password;
            db.SubmitChanges();
        }
        public void deleteAccount(int userId)
        {
            var delete = (from s in db.Users
                          where s.UserId == userId
                          select s).FirstOrDefault();
            delete.IsDeleted = true;
            db.SubmitChanges();
        }
 

    }
}