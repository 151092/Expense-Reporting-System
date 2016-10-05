using Expensite.Data;
using Expensite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Expensite.Business
{
   public class ProfileBusiness
    {
       ProfileData pd = new ProfileData();
       public void insertDetails(UserDetailEntity userEntity)
       {
           pd.insertDetail(userEntity);
       }
       public void maintainData(UserDetailEntity userDetailEntity)
       {
           pd.maintainData(userDetailEntity);
       }
       public void updateData(UserDetailEntity userDetailEntity)
       {
           pd.updateData(userDetailEntity);
       }
       
        
    }
}
