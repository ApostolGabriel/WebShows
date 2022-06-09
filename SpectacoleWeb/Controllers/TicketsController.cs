using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpectacoleWeb.Business_Logic;
using SpectacoleWeb.Data;
using SpectacoleWeb.Models;

namespace SpectacoleWeb.Controllers
{
    public class TicketsController : Controller
    {
        private readonly TicketService _ticketService;

        public TicketsController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }


        // GET: Tickets
        [Authorize(Roles = $"{Roles.Client}")]
        public async Task<IActionResult> Index()
        {
            return View(await _ticketService.Get());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _ticketService.GetById((int)id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        [Authorize(Roles = $"{Roles.Client}")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = $"{Roles.Client}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Show,Row,Column")] Ticket ticket)
        {

            if (ModelState.IsValid)
            {
                try {
                    await _ticketService.Add(ticket);
                    await _ticketService._unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.ToString().Equals("Invalid show"))
                    {
                        Console.WriteLine("No show");
                        TempData["Message"] = "Enter a valid show";
                        return View();
                    }
                    else if (ex.ToString().Equals("No more tickets"))
                    {
                        Console.WriteLine("no tickets");
                        TempData["Message"] = "There are no more tickets at this show";
                        return View();

                    }
                    else 
                    {
                        Console.WriteLine("no tickets");
                        TempData["Message"] = "Arg Null Exception";
                        return View();

                    }
                }
                
            }
            return View(ticket);
        }

        private bool TicketExists(int id)
        {
            var show = _ticketService.GetById(id);
            if (show == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IActionResult ExportCSV()
        {
            return File(Encoding.UTF8.GetBytes(_ticketService.Export("csv")), "text/csv", "tickets.csv");
        }

        public IActionResult ExportJson()
        {
            string filename = "tickets.json";
            string jsonstring = _ticketService.Export("json");
            return File(Encoding.UTF8.GetBytes(jsonstring), "application/json", filename);
        }
    }
}
