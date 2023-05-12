using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Repository.IRepository
{
   public interface IBookingRepo
    {
        IEnumerable<BookingTable> GetAll();
        void DeleteTicket(int id);
        BookingTable AddTicket(BookingTable bookingTable);
    }
}
