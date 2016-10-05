using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensite.Entity
{
    public class UserDetailEntity
    {
        public int UserDetailId { get; set; }
        public int UserId { get; set; }
        public String UserType { get; set; }
        public string Gender { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public DateTime? DOB { get; set; }
        public String EMail { get; set; }
        public string MoblileNo { get; set; }
        public String Apartment { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        public String PinCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
