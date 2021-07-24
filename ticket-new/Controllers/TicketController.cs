using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ticket_new.Models;

namespace ticket_new.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        
        private readonly ILogger<TicketsController> _logger;
        private ITicketRepository _ticketRepository;

        public TicketsController(ILogger<TicketsController> logger, ITicketRepository ticketRepository)
        {
            _logger = logger;
            _ticketRepository = ticketRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ticket>> GetTickets([FromQuery] PaginParam paginParam)
        {
            return Ok(_ticketRepository.GetTickets(paginParam));
        }

        [HttpGet("{id}")]
        public ActionResult<Ticket> GetTicket(long id)
        {
            var ticket = _ticketRepository.GetTicketById(id);
            if(ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpPost]
        public ActionResult<Ticket> AddTicket([FromBody]Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var newTicket = _ticketRepository.AddTicket(ticket);
            return Ok(newTicket);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTicket(long id)
        {
            var ticketResult = _ticketRepository.DeleteTicket(id);
            if (ticketResult)
            {
                return NoContent();
            }
            
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateTicket([FromBody]Ticket ticket)
        {
            var ticketResult = _ticketRepository.UpdateTicket(ticket);
            if (!ModelState.IsValid || ticketResult == null)
            {
                return BadRequest();
            }

            return Ok(ticketResult);
        }
    }
}
