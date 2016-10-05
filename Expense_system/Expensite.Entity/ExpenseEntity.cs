using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensite.Entity
{
   public class ExpenseEntity
    {
        public int ExpenseId { get; set; }
        public int ReceiptId { get; set; }
        public int UserId { get; set; }
        public float Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public ReceiptEntity receiptE { get; set; } 


    }
}
