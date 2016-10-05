using Expensite.Data.Model;
using Expensite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensite.Data
{
    public class ProfileData
    {
        ExpensiteDBDataContext db = new ExpensiteDBDataContext();
        UserDetail user = new UserDetail();
        public void insertDetail(UserDetailEntity userEntity)
        {
            user.UserId = userEntity.UserId;
            user.Gender = userEntity.Gender;
            user.FName = userEntity.FName;
            user.MName = userEntity.MName;
            user.LName = userEntity.LName;
            user.MobileNo = userEntity.MoblileNo;
            user.DOB = userEntity.DOB;
            user.UserType = userEntity.UserType;
            user.EMail = userEntity.EMail;
            user.Appartment = userEntity.Apartment;
            user.Street = userEntity.Street;
            user.City = userEntity.City;
            user.Pincode = userEntity.PinCode;
            db.UserDetails.InsertOnSubmit(user);
            db.SubmitChanges();





            //var qurey=(from a in db.Addresses
            //           join u in db.UserDetails on a.AddressId equals u.AddressId
            //           select new AddressEntity()
            //           {
            //               AddressId=a.AddressId,
            //               userDetail=new UserDetailEntity()
            //               {
            //                   Gender=u.Gender,
            //                   FName=u.FName,
            //                   MName=u.MName,
            //                   LName=u.LName,
            //                   DOB=u.DOB,
            //                   UserType=u.UserType,
            //                   MoblileNo=u.MobileNo

            //               }
            //           });
            //userDetail.Gender = userDetailEntity.Gender;
            //userDetail.FName = userDetailEntity.FName;
            //userDetail.MName = userDetailEntity.MName;
            //userDetail.LName = userDetailEntity.LName;
            //userDetail.DOB = userDetailEntity.DOB;
            //userDetail.UserType = userDetailEntity.UserType;
            //userDetail.MobileNo = userDetailEntity.MoblileNo;
            //db.UserDetails.InsertOnSubmit(userDetail);
            //db.SubmitChanges();
            //var query = (from u in db.Users
            //             join a in db.Addresses on u.UserId equals a.UserId
            //             where u.UserId == userDetailEntity.UserId
            //             select new UserDetailEntity()
            //             {
            //                 UserId = u.UserId,
            //                 AddressDetails = new AddressEntity()
            //                 {
            //                     UserId = a.UserId,
            //                     Apartment = a.Apartment,
            //                     City = a.City,
            //                     Street = a.Street,
            //                     PinCode = a.PinCode

            //                 }

            //   });
            //    address.Apartment = addressEntity.Apartment;
            //    address.Street = addressEntity.Street;
            //    address.City = addressEntity.City;
            //    address.PinCode = addressEntity.PinCode;
            //    }

        }
        public void maintainData(UserDetailEntity userDetailEntity)
        {
                var query = (from s in db.UserDetails
                             where s.UserId == userDetailEntity.UserId
                             select s).FirstOrDefault();
                if (query != null)
                {
                    userDetailEntity.UserDetailId = query.UserDetailId;
                    userDetailEntity.Gender = query.Gender;
                    userDetailEntity.FName = query.FName;
                    userDetailEntity.MName = query.MName;
                    userDetailEntity.LName = query.LName;
                    userDetailEntity.MoblileNo = query.MobileNo;
                    userDetailEntity.DOB = query.DOB;
                    userDetailEntity.UserType = query.UserType;
                    userDetailEntity.EMail = query.EMail;
                    userDetailEntity.Apartment = query.Appartment;
                    userDetailEntity.City = query.City;
                    userDetailEntity.Street = query.Street;
                    userDetailEntity.PinCode = query.Pincode;
                }
        }
        public void updateData(UserDetailEntity userDetailEntity)
        {
            var query = (from s in db.UserDetails
                         where s.UserDetailId == userDetailEntity.UserDetailId
                         select s).FirstOrDefault();
            query.UserId=userDetailEntity.UserId;
            query.Gender=userDetailEntity.Gender;
            query.FName=userDetailEntity.FName;
            query.MName=userDetailEntity.MName;
            query.LName=userDetailEntity.LName;
            query.MobileNo=userDetailEntity.MoblileNo;
            query.DOB=userDetailEntity.DOB;
            query.UserType=userDetailEntity.UserType;
            query.EMail=userDetailEntity.EMail;
            query.Appartment=userDetailEntity.Apartment;
            query.City=userDetailEntity.City;
            query.Street=userDetailEntity.Street;
            query.Pincode=userDetailEntity.PinCode;
            db.SubmitChanges();

        }
    }
}