using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensite.Entity
{
   public class TempEntity
    {
        public float? Amount { get; set; }
        public string date { get; set; }
        public int? ExpenseTypeId { get; set; }
        public string ExpenseTypeName { get; set; }

    }
   public class Chart
   {
       public string Label { get; set; }
       public double? Value1 { get; set; }

   }
}
