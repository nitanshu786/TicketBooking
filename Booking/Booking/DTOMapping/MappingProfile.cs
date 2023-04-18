using AutoMapper;
using Booking.Model;
using Booking.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.DTOMapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterVM, UserDTO>().ReverseMap();
            CreateMap<LoginDTO, UserTable>().ReverseMap();
            CreateMap<BookingDTO, BookingTable>().ReverseMap();
            CreateMap<TicketDTO, TicketTable>().ReverseMap();
          
        }
    }
}
