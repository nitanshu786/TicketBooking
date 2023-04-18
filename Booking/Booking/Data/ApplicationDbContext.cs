using Booking.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Ioption):base(Ioption)
        {
                
        }
        public DbSet<BookingTable> BookingTables { get; set; }
        public DbSet<TicketTable> TicketTables { get; set; }
        public DbSet<UserTable> UserTables { get; set; }


        public override int SaveChanges()
        {
            
                foreach (var entry in ChangeTracker.Entries().Where(s=>s.State==EntityState.Deleted))
                   {
                 
                    entry.State = EntityState.Modified;
                    entry.CurrentValues.SetValues(new { IsDeleted = true });
                   
            }
            return base.SaveChanges();
        }
    }
}
