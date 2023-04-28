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
        private readonly IMapper _mapper;

        public BookingAPIController(IBookingRepo booking, IMapper mapper, ApplicationDbContext context)
        {
            _booking = booking;
            _mapper = mapper;
            _context = context;
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
            try
            {
                // Check if there are enough tickets available
                var ticket = _context.TicketTables.FirstOrDefault(s=>s.Id==booking.TicketId);
                if (ticket.Count <= booking.Count)
                {
                    return BadRequest("Not enough tickets available.");
                }
               
                
                ticket.Count -= booking.Count;
                _context.Entry(ticket).State = EntityState.Modified;
                var data = _mapper.Map<BookingDTO, BookingTable>(booking);
                _booking.AddTicket(data);
                return Ok(data);
              

                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            //if (booking == null && booking.Count>=20)
            //    return BadRequest("something went wrong while save data");
            //var data = _mapper.Map<BookingDTO, BookingTable>(booking);
            //_booking.AddTicket(data);
            //return Ok(data);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _booking.DeleteTicket(id);
            return Ok();
        }


    }
}
