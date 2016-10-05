using Expensite.Data.Model;
using Expensite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensite.Data
{
   public class ReportData
    {
        ExpensiteDBDataContext db = new ExpensiteDBDataContext();
        Report report = new Report();
        Ref ref1 = new Ref();
        int reportId;
        public int insertReportDetails(ReportEntity reportEntity, string[] expenseId, int Id)
        {
            List<string> expenseID = expenseId.ToList();
            float? x = 0;
            foreach (var expense in expenseID)
            {

                var amount = (from s in db.Expenses
                              where s.ExpenseId == Convert.ToInt32(expense)
                              select s.Amount).FirstOrDefault();


                x += amount;

                report.Amount = x;

            }
            report.UserId = reportEntity.UserId;
            report.ReportName = reportEntity.ReportName;
            report.Date = reportEntity.ReportDate;
            report.Owner = reportEntity.Owner;
            report.IsDeleted = false;
            db.Reports.InsertOnSubmit(report);
            db.SubmitChanges();
            //reportId = report.ReportId;
            //ref1.ReportId = report.ReportId;

            
            Id = report.ReportId;
           
            foreach(var expId in expenseID)
            {
                Ref re = new Ref();
                {
                    re.ReportId = report.ReportId;
                    re.ExpenseId = Convert.ToInt32(expId);
                }
                db.Refs.InsertOnSubmit(re);
            }
           
            db.SubmitChanges();
            return Id;
        }
        public object reportGridBind(int userId, string[] expenseId, bool isDeleted)
        {
          
           
           List<string> expenseID = expenseId.ToList();

            var gridBind = (from s in db.Expenses
                            where s.UserId == userId && expenseID.Contains(s.ExpenseId.ToString()) 
                            select new { ExpenseId = s.ExpenseId, Amount = s.Amount, ExpenseDate = s.ExpenseDate }).ToList();
            //gridBind=gridBind.Where(x=>)
            return gridBind;

            

        }
        public void updateFlag(string[] expenseId)
        {
            List<string> expenseID = expenseId.ToList();
            foreach (var expense in expenseID)
            {
                var query = (from s in db.Expenses
                             where s.ExpenseId == Convert.ToInt32(expense)
                             select s).FirstOrDefault();
                query.IsDeleted = true;
                db.SubmitChanges();
            }
        }
        //public void deleteMultipleExpense(int userId, string[] expenseId)
        //{
        //    List<string> expenseID = expenseId.ToList();
        //    var deleteExpense = from s in db.Expenses
        //                         where s.UserId == userId && expenseID.Contains(s.ExpenseId.ToString())
        //                         select s;
        //    foreach (var delete in deleteExpense)
        //    {
        //        db.Expenses.DeleteOnSubmit(delete);
        //    }

        //    db.SubmitChanges();
 
        //}

        public object deleteExpense(int userId, string[] expenseId, int exID, bool isDeleted)
        {
            List<string> expenseID = expenseId.ToList();
            expenseID.Remove(exID.ToString());
            var delete = (from s in db.Expenses
                          where s.ExpenseId==exID && s.UserId == userId
                          select s).FirstOrDefault();
            delete.IsDeleted = false;
            db.SubmitChanges();
   
          

            var gridBind = (from s in db.Expenses
                            where s.UserId == userId && expenseID.Contains(s.ExpenseId.ToString()) && s.IsDeleted == isDeleted
                            select new { ExpenseId = s.ExpenseId, Amount = s.Amount, ExpenseDate = s.ExpenseDate }).ToList();
           
            return gridBind;
            
        }
        public void deleteFromRefs(int exID)
        {
            var deleteFromRef = (from s in db.Refs
                                 where s.ExpenseId == exID
                                 select s).FirstOrDefault();
            db.Refs.DeleteOnSubmit(deleteFromRef);
            db.SubmitChanges();
        }
        public object reportDataBind(ReportEntity reportEntity)
        {
            var query = (from s in db.Reports
                        where s.UserId==reportEntity.UserId && s.IsDeleted==false
                         select new { ReportId = s.ReportId, Amount = s.Amount }).ToList();
            return query;
        }
        public object openReport(int Id)
        {
            var report = (from s in db.Refs
                          where s.ReportId == Id
                          select s.ExpenseId).ToList();
            var gridBind=(from s in db.Expenses
                          where report.Contains(s.ExpenseId) && s.IsDeleted==true
                          select new { ExpenseId = s.ExpenseId, Amount = s.Amount, ExpenseDate = s.ExpenseDate }).ToList();
            //gridBind=gridBind.Where(x=>)
            return gridBind; 
          
            
        }
        public void reportflag(int Id)
        {
            var report = (from s in db.Reports
                         where s.ReportId == Id
                         select s).FirstOrDefault();
            report.IsDeleted = true;
            db.SubmitChanges();
        }
        public object deleteExpenseAfter(int userId, int Id, int exId)
        {

            var report = (from s in db.Refs
                          where s.ReportId == Id
                          select s.ExpenseId).ToList();
            var flag = (from s in db.Expenses
                          where s.ExpenseId == exId && s.UserId == userId
                          select s).FirstOrDefault();
            flag.IsDeleted = false;
            db.SubmitChanges();
            var reportamy = (from s in db.Reports
                             where s.ReportId == Id
                             select s).FirstOrDefault();
             float? y = 0;

            y = reportamy.Amount;
                var amount = (from s in db.Expenses
                              where s.ExpenseId == exId
                              select s.Amount).FirstOrDefault();
                
                y = y - amount;
                reportamy.Amount = y;
                db.SubmitChanges();
            var delete=(from s in db.Expenses
                          where report.Contains(s.ExpenseId) && s.IsDeleted==true
                        select new { ExpenseId = s.ExpenseId, Amount = s.Amount, ExpenseDate = s.ExpenseDate }).ToList();
            return delete;
        }
        public void deleteReport(int Id, int userId)
        {
            var report = (from s in db.Refs
                          where s.ReportId == Id
                          select s.ExpenseId).ToList();
            var deleteExpense = (from s in db.Expenses
                                 where report.Contains(s.ExpenseId) && s.UserId == userId
                                 select s).ToList();
            db.Expenses.DeleteAllOnSubmit(deleteExpense);

            var deleteReport = (from s in db.Reports
                                where s.ReportId == Id && s.UserId==userId
                                select s).FirstOrDefault();
            db.Reports.DeleteOnSubmit(deleteReport);
            var deleteRef = (from s in db.Refs
                             where s.ReportId == Id
                             select s).ToList();
            db.Refs.DeleteAllOnSubmit(deleteRef);
            db.SubmitChanges();
        
        }
        public object sortByDate(int userId, string FromDate, string ToDate)
        {
            string MyString =FromDate;
            DateTime myFromDate;
            myFromDate = new DateTime();
            myFromDate = DateTime.ParseExact(MyString, "MM/dd/yyyy", null);
            string MyString1 = ToDate;
            DateTime myToDate;
            myToDate = new DateTime();
            myToDate = DateTime.ParseExact(MyString1, "MM/dd/yyyy", null);
               var qry =(from s in db.Reports
                       where (s.UserId==userId &&s.Date >= myFromDate 
                        && s.Date <= myToDate )
                        select new { s.ReportId, s.Amount }).ToList();
                 return qry;
        }
    }
}
       
