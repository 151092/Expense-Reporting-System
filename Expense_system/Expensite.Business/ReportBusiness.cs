using Expensite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expensite.Data;

namespace Expensite.Business
{
    public class ReportBusiness
    {
        ReportData reportData = new ReportData();
        public int insertReportDetails(ReportEntity reportEntity,string[] expenseId, int Id)
        {
            int id=reportData.insertReportDetails(reportEntity, expenseId, Id);
            return id;
        }
        public object reportGridBind(int userId, string[] expenseId, bool isDeleted)
        {
            object result = reportData.reportGridBind(userId, expenseId, isDeleted);
            return result;

        }
        public void updateFlag(string[] expenseId)
        {
            reportData.updateFlag(expenseId);
        }
        public void reportflag(int Id)
        {
            reportData.reportflag(Id);
        }
        public object deleteExpense(int userId, string[] expenseId, int exID, bool isDeleted)
            {
               object result= reportData.deleteExpense(userId, expenseId ,exID ,isDeleted);
               return result;
            }
        public object deleteExpenseAfter(int userId, int Id, int exId)
        {
            object result = reportData.deleteExpenseAfter(userId, Id, exId);
            return result;
        }
        public void deleteFromRefs(int exId)
        {
            reportData.deleteFromRefs(exId);
        }
        public object reportDataBind(ReportEntity reportEntity)
        {
            object result = reportData.reportDataBind(reportEntity);
            return result;
        }
        public object openReport(int Id)
        {
            object result = reportData.openReport(Id);
            return result;
        }
        public void deleteReport(int Id, int userId)
        {
            reportData.deleteReport(Id, userId);
        }
        public object sortByDate(int userId, string FromDate, string ToDate)
        {
            object result = reportData.sortByDate(userId,FromDate, ToDate);
            return result;
        }
            //public void deleteMultipleExpense(int userId, string[] expenseId)
        //    {
        //        reportData.deleteMultipleExpense(userId, expenseId);
        //    }
        //}
    }
}
