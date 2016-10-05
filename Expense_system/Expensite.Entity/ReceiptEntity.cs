using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensite.Entity
{
    public class ReceiptEntity
    {
        public int ReceiptId { get; set; }
        public string ReceiptDate { get; set; }
        public string ReceiptPath { get; set; }
        public float Amount { get; set; }
        public int CurrencyTypeId { get; set; }
        public int ExpenseTypeId { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public ExpenseEntity expense { get; set; }
        //public REntity re { get; set; }

    }
}
