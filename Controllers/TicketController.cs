using Marathon.Api.Data;
using Marathon.Api.Models.DTO;
using Marathon.Api.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marathon.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly AppDatabaseContext _context;
        public TicketController(AppDatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetTickets()
        {
            var tickets = _context.Tickets.ToList();
            return Ok(tickets);
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Organizer")]
        [Route("GetTicketById/{id}")]
        public IActionResult GetTicketById(int id)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Organiser")]
        [Route("GetTicketByUserId/{userId}")]
        public IActionResult GetTicketByUserId(int userId)
        {
            var tickets = _context.Tickets.Where(t => t.UserId == userId).ToList();
            if (tickets == null || tickets.Count == 0)
            {
                return NotFound();
            }
            return Ok(tickets);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Organiser")]
        public IActionResult CreateTicket(GenerateTicketDTOcs ticket)
        {
            var ticketEntity = new Ticket
            {
                Race_EventId = ticket.Race_EventId,
                UserId = ticket.UserId,
                TicketType = ticket.TicketType,
                TicketPrice = ticket.TicketPrice,
                TicketName = ticket.TicketName,
                TicketDescription = ticket.TicketDescription,
                PurchaseDate = DateOnly.FromDateTime(DateTime.Now),
                TicketStatus = "Active"
            };
            _context.Tickets.Add(ticketEntity);
            _context.SaveChanges();
            return Ok("Ticket created successfully");
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Organiser")]
        public IActionResult UpdateTicket(int id, ScanTicket ticket)
        {
            var ticketEntity = _context.Tickets.Find(id);
            if (ticketEntity == null)
            {
                return NotFound();
            }
            ticketEntity.Race_EventId = ticket.Race_EventId;
            ticketEntity.UserId = ticket.UserId;
            ticketEntity.TicketType = ticket.TicketType;
            ticketEntity.TicketPrice = ticket.TicketPrice;
            ticketEntity.TicketName = ticket.TicketName;
            ticketEntity.TicketDescription = ticket.TicketDescription;
            ticketEntity.PurchaseDate = ticket.PurchaseDate;
            ticketEntity.TicketStatus = "Used";
            _context.SaveChanges();
            return Ok("Ticket updated successfully");
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Organiser")]
        public IActionResult DeleteTicket(int id)
        {
            var ticketEntity = _context.Tickets.Find(id);
            if (ticketEntity == null)
            {
                return NotFound();
            }
            _context.Tickets.Remove(ticketEntity);
            _context.SaveChanges();
            return Ok("Ticket deleted successfully");
        }

    }
}
