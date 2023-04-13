using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Repository.IRepository
{
  public  interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject);
       
    }
}
