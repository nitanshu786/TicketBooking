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
    public class BookingRepo:IBookingRepo
    {

        private readonly ApplicationDbContext _context;

        public BookingRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddTicket(BookingTable bookingTable)
        { 
            _context.BookingTables.Add(bookingTable);
           _context.SaveChanges();
        }

        


        public void DeleteTicket(int id)
        {
            var find = _context.BookingTables.Find(id);
            _context.BookingTables.Remove(find);
            _context.SaveChanges();
        }

        public IEnumerable<BookingTable> GetAll()
        {
            return _context.BookingTables.Include(x=>x.TicketTable).Include(x=>x.UserTable).ToList();
        }

    }
}
