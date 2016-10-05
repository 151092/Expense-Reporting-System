using Expensite.Data.Model;
using Expensite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensite.Data
{
    public class AnalyticsData
    {


        ExpensiteDBDataContext db = new ExpensiteDBDataContext();
        AnalyticsEntity analyticsEntity = new AnalyticsEntity();
        List<AnalyticsEntity> anal = new List<AnalyticsEntity>();
        public List<Chart> GetPieChartData(List<AnalyticsEntity> entity)
        {
            var data = (from d in entity
                        select new Chart { Label = d.ExpName, Value1 = d.percentage }).ToList();

            List<Chart> newdata = data.ToList();
            return newdata;

        }

     public List<TempEntity> ExpensetypeId()
        {
            var exptype = (from e in db.ExpenseTypes
                           select new TempEntity { ExpenseTypeId = e.ExpenseTypeId, ExpenseTypeName = e.ExpenseTypeName }).ToList();
            return exptype;
            
            
        }
        

        public List<TempEntity> data()
        {
            var exptype = (from e in db.ExpenseTypes
                           select e.ExpenseTypeId).ToList();
            List<int> expenseTypeid = exptype.ToList();


            var recamount = (from a in db.Receipts
                             join b in db.ExpenseTypes on a.ExpenseTypeId equals b.ExpenseTypeId
                             join c in db.Expenses on a.ReceiptId equals c.ReceiptId
                             where expenseTypeid.Contains(b.ExpenseTypeId) && c.IsDeleted==true
                             select new TempEntity { Amount = a.Amount, date = a.ReceiptDate, ExpenseTypeId = a.ExpenseTypeId, ExpenseTypeName = b.ExpenseTypeName }).ToList();


            return recamount;


        }

    }
}


