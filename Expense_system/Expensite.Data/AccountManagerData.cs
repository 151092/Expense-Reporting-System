using Expensite.Data.Model;
using Expensite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensite.Data
{
    public class AccountManagerData
    {
        ExpensiteDBDataContext db = new ExpensiteDBDataContext();
        Report report = new Report();
        Ref ref1 = new Ref();
       
        public object viewReport(int Id)
        {
            var report = (from s in db.Refs
                          where s.ReportId == Id
                          select s.ExpenseId).ToList();
            var gridBind = (from s in db.Expenses
                            join a in db.Receipts on s.ReceiptId equals a.ReceiptId
                            where report.Contains(s.ExpenseId) && s.IsDeleted == true
                            select new { ExpenseId = s.ExpenseId, Amount = s.Amount, ExpenseDate = s.ExpenseDate, ReceiptPath=a.ReceiptPath }).ToList();
            return gridBind; 
        }
        public ReportEntity reportData(int reportId)
        {
            var reportData = (from s in db.Reports
                              where s.ReportId == reportId
                              select new ReportEntity
                              {
                                  Amount = s.Amount,
                                  ReportDate = s.Date,
                                  Owner = s.Owner
                              }).FirstOrDefault();
            return reportData;
        }
       public object approvedExpense(string[] Id)
       {
           List<string> expenseID = Id.ToList();
           var approved = (from s in db.Expenses
                           join a in db.Receipts on s.ReceiptId equals a.ReceiptId
                           where expenseID.Contains(s.ExpenseId.ToString())
                           select new { ExpenseId = s.ExpenseId, Amount = s.Amount, ExpenseDate = s.ExpenseDate, ReceiptPath = a.ReceiptPath }).ToList();
           return approved;

       }
       public void rejectedExpense(int expenseId)
       {
           var query = (from s in db.Expenses
                        where s.ExpenseId == expenseId
                        select s).FirstOrDefault();
           query.IsDeleted = false;
           db.SubmitChanges();
           var delete = (from s in db.Refs
                         where s.ExpenseId == expenseId
                         select s).FirstOrDefault();
           db.Refs.DeleteOnSubmit(delete);
           db.SubmitChanges();
       }
       public List<float?> totalAmount(string[] Id)
       {
           List<string> expenseID = Id.ToList();
           var approved = (from s in db.Expenses
                           where expenseID.Contains(s.ExpenseId.ToString())
                           select s.Amount).ToList();

           return approved;
       }

       public void rejectReport(int reportId)
       {
           var reject = (from s in db.Reports
                         where s.ReportId == reportId
                         select s).FirstOrDefault();
           reject.IsDeleted = false;
           db.SubmitChanges();
       }
        
    }
}
