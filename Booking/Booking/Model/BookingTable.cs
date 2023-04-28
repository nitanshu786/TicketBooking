using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Model
{
    public class BookingTable
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserTable UserTable { get; set; }
        public int TicketId { get; set; }
        [ForeignKey("TicketId")]
        public TicketTable TicketTable { get; set; }
        public int Count { get; set; }
    }
}
