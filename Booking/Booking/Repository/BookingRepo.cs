using Booking.Data;
using Booking.Model;
using Booking.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Booking.Repository
{
    public class BookingRepo : IBookingRepo
    {

        private readonly ApplicationDbContext _context;

        public BookingRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public BookingTable AddTicket(BookingTable bookingTable)
        {

            if (bookingTable != null)
            {
              
               
                var item = _context.BookingTables.Where(s => s.TicketId == bookingTable.TicketId).FirstOrDefault(s => s.UserId == bookingTable.UserId);

                if (item != null && item.UserId == bookingTable.UserId)
                {
                    item.Count = item.Count + bookingTable.Count;

                    _context.SaveChanges();
                    return bookingTable;
                }
                 _context.BookingTables.Add(bookingTable);
                 _context.SaveChanges();
                  return bookingTable;  
            }
            else
            {
                return null;
            }
        }
        public void DeleteTicket(int id)
        {
            var find = _context.BookingTables.Find(id);
            _context.BookingTables.Remove(find);
            _context.SaveChanges();
        }

        public IEnumerable<BookingTable> GetAll()
        {
            return _context.BookingTables.Include(x => x.TicketTable).Include(x => x.UserTable).ToList();

        }

    }
}
