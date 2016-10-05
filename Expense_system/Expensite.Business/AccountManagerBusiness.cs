using Expensite.Data;
using Expensite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensite.Business
{
   public class AccountManagerBusiness
    {
       AccountManagerData accountManagerData = new AccountManagerData();
       public object viewReport(int Id)
       {
           object result = accountManagerData.viewReport(Id);
           return result;
       }
       public ReportEntity reportData(int reportId)
       {
           return accountManagerData.reportData(reportId);
       }
       public object approvedExpense(string[] Id)
       {
           object approved = accountManagerData.approvedExpense(Id);
           return approved;
       }
       public void rejectedExpense(int expenseId)
       {
           accountManagerData.rejectedExpense(expenseId);
       }
       public List<float?> totalAmount(string[] Id)
       {
          return accountManagerData.totalAmount(Id);
       }
       public void rejectReport(int reportId)
       {
           accountManagerData.rejectReport(reportId);
       }
    }
}
