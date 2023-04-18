﻿using AutoMapper;
using Booking.Model;
using Booking.Model.DTO;
using Booking.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketAPIController : ControllerBase
    {
        private readonly ITicketRepo _ticketRepo;
        private readonly IMapper _mapper;
        public TicketAPIController(ITicketRepo ticketRepo, IMapper mapper)
        {
            _ticketRepo = ticketRepo;
            _mapper = mapper;
        }

        [Route("get")]
        [HttpGet]
        public IEnumerable<TicketDTO> GetTickets()
        {
            var tickets = _ticketRepo.GetAll();
            return _mapper.Map<IEnumerable<TicketDTO>>(tickets);
        }
    
        [HttpGet("{id:int}")]
        public IActionResult GetTicketById(int id)
        {
            var ticket = _ticketRepo.GetById(id);
            var ticketDto = _mapper.Map<TicketDTO>(ticket);
            return Ok(ticketDto);
        }
        [Route("save")]
        [HttpPost]
        public IActionResult SaveTicket([FromBody] TicketDTO ticketDTO)
        {
            if (ticketDTO == null)
                return BadRequest(ModelState);
            var Ticket = _mapper.Map<TicketDTO, TicketTable>(ticketDTO);
            Ticket.Count += 1;
            _ticketRepo.AddTicket(Ticket);
            return Ok(Ticket);

        }
        [Route("update")]
        [HttpPut]
        public IActionResult UpdateTicket([FromBody] TicketDTO ticketDTO)
        {
            if (ticketDTO == null) return BadRequest(ModelState);
            var Ticket = _mapper.Map<TicketDTO, TicketTable>(ticketDTO);
           _ticketRepo.UpdateTicket(Ticket);     
            return Ok(Ticket);
        }
        
        [HttpDelete]
        public void DeleteTicket(int id)
        {
            _ticketRepo.DeleteTicket(id);

        }
    }
     
}






//var map = _mapper.Map<TicketDTO, TicketTable>(ticketDTO);