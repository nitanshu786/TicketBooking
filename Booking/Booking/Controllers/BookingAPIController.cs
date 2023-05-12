using AutoMapper;
using Booking.Data;
using Booking.Model;
using Booking.Model.DTO;
using Booking.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IBookingRepo _booking;
        private readonly ITicketRepo _ticketRepo;
        private readonly IMapper _mapper;

        public BookingAPIController(IBookingRepo booking, IMapper mapper, ApplicationDbContext context, ITicketRepo ticketRepo)
        {
            _booking = booking;
            _mapper = mapper;
            _context = context;
            _ticketRepo = ticketRepo;
        }

        [HttpGet]
        public IEnumerable<BookingDTO> GetALL()
        {
            
            var bookings = _booking.GetAll();
           return _mapper.Map<IEnumerable<BookingDTO>>(bookings);


        }

        [HttpPost]
        public IActionResult post([FromBody] BookingDTO booking)
        {
           
            if (booking == null)
                return BadRequest("something went wrong while save data");
            var items = _ticketRepo.GetAll();
            var counts = items.FirstOrDefault(s => s.Id == booking.TicketId);
            if(counts.Count<booking.Count)
            {
                return null;
            }
            if (counts!=null)
            {
                counts.Count = counts.Count - booking.Count;
            }
            var data = _mapper.Map<BookingDTO, BookingTable>(booking);
          var save =  _booking.AddTicket(data);
            if (save == null)
                return BadRequest(ModelState);
            return Ok(data);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _booking.DeleteTicket(id);
            return Ok();
        }


    }
}
