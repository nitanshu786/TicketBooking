using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Repository.IRepository
{
   public interface ITicketRepo
    {
        IEnumerable<TicketTable> GetAll();
        TicketTable GetById(int id);
        void AddTicket(TicketTable ticket);
        void UpdateTicket(TicketTable ticket);
        void DeleteTicket(int id);

    }
}
