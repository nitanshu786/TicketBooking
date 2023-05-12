using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Model
{
    public class RegisterVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime RefreshDates { get; set; }

    }
}
