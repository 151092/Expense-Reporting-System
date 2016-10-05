using Expensite.Data;
using Expensite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensite.Business
{
   public class SettingBusiness
    {
       SettingData settingData = new SettingData();
       public void fetchPassword(UserEntity userEntity)
        {
            settingData.fetchPassword(userEntity);
        }
       public void changePassword(UserEntity userEntity)
       {
           settingData.changePassword(userEntity);
       }
       public void deleteAccount(int userId)
       {
           settingData.deleteAccount(userId);
       }
    }
}
