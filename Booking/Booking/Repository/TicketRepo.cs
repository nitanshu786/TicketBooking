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
            return _context.TicketTables.Where(s => !s.IsDeleted);
        }

        public TicketTable GetById(int id)
        {
            return _context.TicketTables.Find(id);
        }

        public void UpdateTicket(TicketTable ticket)
        {
            _context.TicketTables.Update(ticket);
            _context.SaveChanges();
        }
    }
}
