using Marathon.Api.Data;
using Marathon.Api.Models.DTO;
using Marathon.Api.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marathon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly AppDatabaseContext _context;
        public EventController(AppDatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetEvents()
        {
            var events = _context.Events.ToList();
            return Ok(events);
        }
        [HttpGet("{id}")]
        public IActionResult GetEventById(Guid id)
        {
            var @event = _context.Events.FirstOrDefault(e => e.Id == id);
            if (@event == null)
            {
                return NotFound();
            }
            return Ok(@event);
        }
        [HttpPost]
        public IActionResult CreateEvent(CreateEvent eventDTO)
        {
            var eventEntite = new Event
            {
                Id = Guid.NewGuid(),
                Title = eventDTO.Title,
                Name = eventDTO.Name,
                Description = eventDTO.Description,
                EndDate= eventDTO.EndDate,
                StartDate = eventDTO.StartDate,
            };
            _context.Events.Add(eventEntite);
            _context.SaveChanges();
            return Ok("Event was create successfully");

        }
        [HttpPut("{id:guid}")]

        public IActionResult UpdateEvent(Guid id, CreateEvent eventDTO)
        {
            var eventEntitie = _context.Events.FirstOrDefault(e => e.Id == id);
            if (eventEntitie == null)
            {
                return NotFound();
            }
            eventEntitie.Title = eventDTO.Title;
            eventEntitie.Name = eventDTO.Name;
            eventEntitie.Description = eventDTO.Description;
            eventEntitie.StartDate = eventDTO.StartDate;
            eventEntitie.EndDate = eventDTO.EndDate;
            _context.SaveChanges();
            return Ok("Event was updated successfully");
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEvent(Guid id)
        {
            var eventEntitie = _context.Events.FirstOrDefault(e => e.Id == id);
            if (eventEntitie == null)
            {
                return NotFound();
            }
            _context.Events.Remove(eventEntitie);
            _context.SaveChanges();
            return Ok("Event was deleted successfully");
        }
    }
}
