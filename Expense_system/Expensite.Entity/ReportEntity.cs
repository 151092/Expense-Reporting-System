using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensite.Entity
{
    public class ReportEntity
    {
        public int ReportId { get; set; }
        public int UserId { get; set; }
        public DateTime? ReportDate { get; set; }
        public string  ReportName { get; set; }
        public String Owner { get; set; }
        public float? Amount { get; set; }
        public bool IsDeleted { get; set; }
       // public DateTime? ReceiptDate { get; set; }
    }
}
