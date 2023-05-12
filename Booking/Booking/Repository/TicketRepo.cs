using Booking.Data;
using Booking.Model;
using Booking.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Repository
{
    public class TicketRepo : ITicketRepo
    {
        private readonly ApplicationDbContext _context;

        public TicketRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddTicket(TicketTable ticket)
        {
            _context.Add(ticket);
            _context.SaveChanges();
        }

        public void DeleteTicket(int id)
        {
            var Ticketindb = _context.TicketTables.Find(id);
            if (Ticketindb != null)
                _context.Remove(Ticketindb);
            _context.SaveChanges();
        }

        public IEnumerable<TicketTable> GetAll()
        {
            var data= _context.TicketTables.Where(s => !s.IsDeleted);
            foreach (var item in data)
            {
                var books = _context.BookingTables.Where(s => s.TicketId == item.Id).Sum(s => s.Count);
                if (books != 0)
                {
                    item.Count = item.Count - books;
                  if(item.Count<=0)
                    {
                        var count = books + item.Count;
                        item.Count = count;
                    }
                    
                }

            }
            return data;
        }

        public TicketTable GetById(int id)
        {
            return _context.TicketTables.Find(id);
        }

        public void UpdateTicket(TicketTable ticket)
        {
           var item=  _context.TicketTables.Update(ticket);

            _context.SaveChanges();
        }
    }
}
