using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensite.Entity
{
    public class AddressEntity
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public String Apartment { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        public String PinCode { get; set; }
        public UserDetailEntity userDetails { get; set; }

    }
}
