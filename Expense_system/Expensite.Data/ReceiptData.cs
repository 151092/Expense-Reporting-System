

using Expensite.Data.Model;
using Expensite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensite.Data
{
   public class ReceiptData
    {
       ExpensiteDBDataContext db = new ExpensiteDBDataContext();
       R r = new R();
       Receipt receipt=new Receipt();
       Expense expense=new Expense();
       User user = new User();
       public void insertReceipt(REntity rEntity)
       {
           r.UserId = rEntity.UserId;
           r.ReceiptPath = rEntity.ReceiptPath;
           db.Rs.InsertOnSubmit(r);
           db.SubmitChanges();
       }
       public void retrieveImage(ReceiptEntity receiptEntity)
       {
           var receipt = (from s in db.Receipts
                          select s).FirstOrDefault();
           receiptEntity.ReceiptPath = receipt.ReceiptPath;


       }
       public List<ExpenseTypeEntity> fetchExpenseType()
       {
           var expensetype = (from s in db.ExpenseTypes
                        select new ExpenseTypeEntity
                        {
                            ExpenseTypeId = s.ExpenseTypeId,
                            ExpenseTypeName = s.ExpenseTypeName
                        }).ToList();
           return expensetype;
       }
       public List<CurrencyTypeEntity> fetchCurrencyType()
       {
           var currencyType = (from s in db.CurrencyTypes
                        select new CurrencyTypeEntity
                        {
                            CurrencyTypeId=s.CurrencyTypeId,
                            CurrencyTypeName=s.CurrencyTypeName,
                           
                           
                        }).ToList();
           return currencyType;
       }
       public string currencySymbol(int CurrencyId)
       {
           var currencySym = (from s in db.CurrencyTypes
                              where s.CurrencyTypeId == CurrencyId
                              select s.CurrencySymbol).FirstOrDefault();
           return currencySym;
       }


       public Object gridData(int userId)
       {
           var grid = from s in db.Rs
                      where s.UserId == userId
                      select s;
           List<R> list = grid.ToList();
           return list;
           
       }
       public void deleteData(REntity rEntity)
       {
           var delete = (from s in db.Rs
                        where s.ReceiptID == rEntity.ReceiptID
                        select s).FirstOrDefault();
           db.Rs.DeleteOnSubmit(delete);
           db.SubmitChanges();
       }
      
     
       public void insertReceiptDetail(ReceiptEntity receiptEntity)
       {
           float amt=0;
           receipt.ReceiptPath = receiptEntity.ReceiptPath;
          
           receipt.ReceiptDate = receiptEntity.ReceiptDate;
           receipt.ExpenseTypeId = receiptEntity.ExpenseTypeId;
           receipt.CurrencyTypeId = receiptEntity.CurrencyTypeId;
           if (receiptEntity.CurrencyTypeId == 1)
            {
            amt= Convert.ToInt64(receiptEntity.Amount);
            amt = amt * 56;
            receipt.Amount = amt;
           }
           else if (receiptEntity.CurrencyTypeId == 2)
           {
               amt = Convert.ToInt64(receiptEntity.Amount);
               amt = amt * 83;
               receipt.Amount = amt;
           }
           else if (receiptEntity.CurrencyTypeId == 3)
           {
               amt = Convert.ToInt64(receiptEntity.Amount);
               amt = amt * 100;
               receipt.Amount = amt;
           }
           else if (receiptEntity.CurrencyTypeId == 4)
           {
               receipt.Amount = Convert.ToInt64(receiptEntity.Amount);
            
           }
           else 
           {
               amt = Convert.ToInt64(receiptEntity.Amount);
               amt = amt * 1;
               receipt.Amount = amt;
           }
           receipt.Comment = receiptEntity.Comment;
           receipt.IsDeleted = receiptEntity.IsDeleted;
           db.Receipts.InsertOnSubmit(receipt);
           db.SubmitChanges();
           expense.ReceiptId =receipt.ReceiptId;
           expense.UserId = receiptEntity.expense.UserId;
           expense.Amount = Convert.ToInt64(receipt.Amount);
           expense.ExpenseDate = receipt.ReceiptDate;
           expense.IsDeleted = receipt.IsDeleted;
           db.Expenses.InsertOnSubmit(expense);
           //r.UserId = receiptEntity.re.UserId;
           //r.ReceiptPath = receipt.Receiptpath;
           //db.Rs.InsertOnSubmit(r);
           db.SubmitChanges();
       }
       public object expenseGridBind(int userId, bool isDeleted)
       {
           var gridBind = (from s in db.Expenses
                           join a in db.Receipts on s.ReceiptId equals(a.ReceiptId) 
                           join b in db.ExpenseTypes on a.ExpenseTypeId equals(b.ExpenseTypeId)
                           where s.UserId==userId && s.IsDeleted==isDeleted
                          select new {ExpenseId = s.ExpenseId, ExpenseType=b.ExpenseTypeName, Amount = s.Amount,ExpenseDate = s.ExpenseDate}).ToList();
           return gridBind;
       }
       public void editRecord(ExpenseEntity expenseEntity)
       {
           ReceiptEntity receiptE = new ReceiptEntity();
           var update = (from s in db.Expenses
                         where s.ExpenseId == expenseEntity.ExpenseId
                         select s).FirstOrDefault();

           var query = (from s in db.Receipts
                        where s.ReceiptId == update.ReceiptId
                        select s).FirstOrDefault();
           receiptE.ReceiptId = query.ReceiptId;
           receiptE.Amount = Convert.ToInt64(query.Amount);
           receiptE.ReceiptDate = query.ReceiptDate;
           receiptE.ReceiptPath = query.ReceiptPath;
           receiptE.Comment = query.Comment;
           receiptE.CurrencyTypeId = query.CurrencyTypeId;
           receiptE.ExpenseTypeId = query.ExpenseTypeId;
           expenseEntity.receiptE = receiptE;
       }
       public void updateRecord(ExpenseEntity expenseEntity)
       {
           
           var update = (from s in db.Expenses
                         where s.ExpenseId == expenseEntity.ExpenseId
                         select s).FirstOrDefault();

           var query = (from s in db.Receipts
                        where s.ReceiptId == update.ReceiptId
                        select s).FirstOrDefault();

          query.ReceiptId = expenseEntity.receiptE.ReceiptId;
          query.Amount = Convert.ToInt64(expenseEntity.receiptE.Amount);
          query.ReceiptDate = expenseEntity.receiptE.ReceiptDate;
          query.ReceiptPath = expenseEntity.receiptE.ReceiptPath;
          query.CurrencyTypeId = expenseEntity.receiptE.CurrencyTypeId;
          query.ExpenseTypeId = expenseEntity.receiptE.ExpenseTypeId;
          query.Comment = expenseEntity.receiptE.Comment;
          db.SubmitChanges();
          var expense1 = (from s in db.Expenses
                         where s.ReceiptId == query.ReceiptId
                         select s).FirstOrDefault();
          expense1.ExpenseId = expenseEntity.ExpenseId;
          expense1.ReceiptId = expenseEntity.receiptE.ReceiptId;
          expense1.UserId = expenseEntity.UserId;
          expense1.Amount = Convert.ToInt64(expenseEntity.receiptE.Amount);
          expense1.ExpenseDate = expenseEntity.receiptE.ReceiptDate;
          db.SubmitChanges();



       }
       public void deleteRecord(ExpenseEntity expenseEntity)
       {
           var delete = (from s in db.Expenses
                         where s.ExpenseId == expenseEntity.ExpenseId 
                         select s).FirstOrDefault();
           ReceiptEntity receiptEntity=new ReceiptEntity();

           receiptEntity.ReceiptId = Convert.ToInt32(delete.ReceiptId);
           var deleteReceipt = (from s in db.Receipts
                                where s.ReceiptId == receiptEntity.ReceiptId
                                select s).FirstOrDefault();
           db.Receipts.DeleteOnSubmit(deleteReceipt);
           db.Expenses.DeleteOnSubmit(delete);
           db.SubmitChanges();
       }
       public void addToExpense(REntity rEntity)
       {
           var receipt = (from s in db.Rs
                          where s.ReceiptID == rEntity.ReceiptID
                          select s).FirstOrDefault();
          receipt.ReceiptID=rEntity.ReceiptID;
          rEntity.ReceiptPath= receipt.ReceiptPath;
       }

       public object viewExpenseType(int userId, int expenseTypeId)
       {
           var expenseType = (from s in db.Expenses
                              join a in db.Receipts on s.ReceiptId equals (a.ReceiptId)
                              join b in db.ExpenseTypes on a.ExpenseTypeId equals (b.ExpenseTypeId)
                              where s.UserId == userId && s.IsDeleted == false && b.ExpenseTypeId == expenseTypeId
                              select new { ExpenseId = s.ExpenseId, ExpenseType = b.ExpenseTypeName, Amount = s.Amount, ExpenseDate = s.ExpenseDate }).ToList();
           return expenseType;
       }
      
    }
}
