using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Model
{
    public class RegisterVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime RegisterDate { get; set; }
        public int RoleId { get; set; }
        public RoleTable RoleTable { get; set; }
    }
}
