using Booking.Model;
using Booking.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Repository.IRepository
{
   public interface IRegister
    {
        bool IsUniqueUser(string Name,string email);
        UserTable Login(string Email, string Passward);
        UserTable Registers(UserDTO userDTO);
    }
}
