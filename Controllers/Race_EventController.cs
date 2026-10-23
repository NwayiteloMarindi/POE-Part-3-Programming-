using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Race_Day.Models.DTO;
using Race_Day.Models.Entities;
using Marathon.Api.Data;
using Marathon.Api.Models.DTO;

namespace Marathon.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Race_EventController : ControllerBase
    {
        private readonly AppDatabaseContext _context;

        public Race_EventController(AppDatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetRaceEvents()
        {
            var raceEvents = _context.Race_Events.ToList();
            return Ok(raceEvents);
        }
        [HttpGet("{id}")]
        public IActionResult GetRaceEvent(int id)
        {
            var raceEvent = _context.Race_Events.Find(id);
            if (raceEvent == null)
            {
                return NotFound();
            }
            return Ok(raceEvent);
        }
        [HttpPost]
        public IActionResult CreateRaceEvent(CreateRace_Event raceEvent)
        {
            var raceEventEntity = new Race_Event
            {
                Race_EventName = raceEvent.Race_EventName,
                Race_EventDate = raceEvent.Race_EventDate,
                Description = raceEvent.Description,
                Race_EventStatus = raceEvent.Race_EventStatus
            };
            _context.Race_Events.Add(raceEventEntity);
            _context.SaveChanges();
            return Ok("Race Event created successfully");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateRaceEvent(int id, CreateRace_Event raceEvent)
        {
            var raceEventEntity = _context.Race_Events.Find(id);
            if (raceEventEntity == null)
            {
                return NotFound();
            }
            raceEventEntity.Race_EventName = raceEvent.Race_EventName;
            raceEventEntity.Race_EventDate = raceEvent.Race_EventDate;
            raceEventEntity.Description = raceEvent.Description;
            raceEventEntity.Race_EventStatus = raceEvent.Race_EventStatus;
            _context.SaveChanges();
            return Ok("Race Event updated successfully");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRaceEvent(int id)
        {
            var raceEventEntity = _context.Race_Events.Find(id);
            if (raceEventEntity == null)
            {
                return NotFound();
            }
            _context.Race_Events.Remove(raceEventEntity);
            _context.SaveChanges();
            return Ok("Race Event deleted successfully");
        }
    }
}
