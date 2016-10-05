using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expensite.Data.Model;
using Expensite.Entity;

namespace Expensite.Data
{
    public class AdminData
    {
        ExpensiteDBDataContext db = new ExpensiteDBDataContext();
        User user = new User();
        Admin admin = new Admin();
        public object admindata()
        {
            var query = (from s in db.Admins
                        select s).ToList();
            return query;
        }
        public void InsertData(UserEntity userEntity)
        {
            user.EMail = userEntity.EMail;
            user.Password = userEntity.Password;
            user.IsDeleted = false;    
             db.Users.InsertOnSubmit(user);
             db.SubmitChanges();
          
            
            
        }
        public bool MatchData(UserEntity userEntity)
        {
            var query = (from s in db.Users
                        where s.EMail == userEntity.EMail && s.Password == userEntity.Password && s.IsDeleted==false
                        select s).FirstOrDefault();
            
            if (query != null)
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
            var query = (from s in db.Users
                         where s.EMail == userEmailId
                         select new UserEntity {
                         EMail=s.EMail,
                         UserId=s.UserId
                         }).FirstOrDefault();
            return query;
           
        }
        public string forgotPassword(UserDetailEntity userEntity)
        {
            var password = "";
            var forgot = (from s in db.UserDetails
                          where s.EMail == userEntity.EMail &&
                          s.MobileNo == userEntity.MoblileNo
                          select s).FirstOrDefault();

            if (forgot != null)
            {

                var fetchpass = (from s in db.Users
                                 where s.UserId == forgot.UserId
                                 select s).FirstOrDefault();

                password = fetchpass.Password;

            }



            return password;
        }

        public UserDetailEntity userName(int userId)
        {
            var query = (from s in db.UserDetails
                         where s.UserId == userId
                         select new UserDetailEntity
                         {
                             FName = s.FName,
                             LName = s.LName
                         }).FirstOrDefault();
            return query;
        }

        public void Upadates(UpdateEntity updateEntity)
        {
            admin.Date = updateEntity.Date;
            admin.Description = updateEntity.Description;
            db.Admins.InsertOnSubmit(admin);
            db.SubmitChanges();
        }
        public bool userInfo(string mail)
        {
            var y = (from s in db.Users
                     where s.EMail == mail
                     select s.EMail).FirstOrDefault();
            if (y != string.Empty && y!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
