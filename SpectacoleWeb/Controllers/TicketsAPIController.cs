using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpectacoleWeb.Business_Logic;
using SpectacoleWeb.Data;
using SpectacoleWeb.Models;

namespace SpectacoleWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsAPIController : ControllerBase
    {
        private readonly TicketService _ticketService;

        public TicketsAPIController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: api/TicketsAPI/show
        [HttpGet("{show}_{date1}_{date2}")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicket(string show, DateTime date1, DateTime date2)
        {

            var tickets = await _ticketService.GetByShowAndDate(show, date1, date2);
           

            if (tickets == null)
            {
                return NotFound();
            }

            return Ok(tickets);
        }

 
    }
}
