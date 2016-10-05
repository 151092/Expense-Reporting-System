using Expensite.Data;
using Expensite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensite.Business
{
    public class ReceiptBusiness
    {
        ReceiptData receiptData = new ReceiptData();
        public void insertReceipt(REntity rEntity)
        {
            receiptData.insertReceipt(rEntity);
        }
        public Object gridData(int userId)
        {
            Object result = receiptData.gridData(userId);
            return result;
        }
        public void retrieveImage(ReceiptEntity receiptEntity)
        {
            receiptData.retrieveImage(receiptEntity);
        }
        public void deleteData(REntity rEntity)
        {
            receiptData.deleteData(rEntity);
        }
        public List<ExpenseTypeEntity> fetchExpenseType()
        {
            return receiptData.fetchExpenseType();
            
        }
        public List<CurrencyTypeEntity> fetchCurrencyType()
        {
            return receiptData.fetchCurrencyType();
        }
        public void insertReceiptDetail(ReceiptEntity receiptEntity)
        {
            receiptData.insertReceiptDetail(receiptEntity);
        }
        public object expenseGridBind(int userId, bool isDeleted)
        {
            object gridBind = receiptData.expenseGridBind(userId, isDeleted);
            return gridBind;
        }
        public void deleteRecord(ExpenseEntity expenseEntity)
        {
            receiptData.deleteRecord(expenseEntity);
        }
        public void editRecord(ExpenseEntity expenseEntity)
        {
            receiptData.editRecord(expenseEntity);
        }
        public void updateRecord(ExpenseEntity expenseEntity)
        {
            receiptData.updateRecord(expenseEntity);
        }
        public void addToExpense(REntity rEntity)
        {
            receiptData.addToExpense(rEntity);
        }
        public object viewExpenseType(int userId, int expenseTypeId)
        {
            return receiptData.viewExpenseType(userId, expenseTypeId);
        }
        public string currencySymbol(int CurrencyId)
        {
            return receiptData.currencySymbol(CurrencyId);
        }

    }
}
