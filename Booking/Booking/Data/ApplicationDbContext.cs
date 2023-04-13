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
        public DbSet<RoleTable> RoleTables { get; set; }
        
    }
}
