using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Model.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserTable UserTable { get; set; }
        public int TicketId { get; set; }
        public TicketTable TicketTable { get; set; }
        public int Count { get; set; }
    }
}
