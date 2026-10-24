using Marathon.Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Race_Day.Models.DTO;
using Race_Day.Models.Entities;

namespace Marathon.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly AppDatabaseContext _context;
        public RaceController(AppDatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetRaces()
        {
            var races = _context.Race.ToList();
            return Ok(races);
        }
        [HttpGet("{id}")]
        public IActionResult GetRaceById(Guid id)
        {
            var race = _context.Race.Find(id);
            if (race == null)
            {
                return NotFound();
            }
            return Ok(race);
        }
        [HttpPost]
        public IActionResult CreateRace(CreateRace race)
        {
            var raceEntity = new Race
            {
                Race_EventId = race.Race_EventId,
                Race_name = race.Race_name,
                Race_Number = race.Race_Number,
                Race_distance = race.Race_distance,
                Race_time = race.Race_time,
                Race_Description = race.Race_Description
            };
           
            _context.Race.Add(raceEntity);
            _context.SaveChanges();
            return Ok("Race created successfully");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateRace(int id, CreateRace race)
        {
            var raceEntity = _context.Race.Find(id);
            if (raceEntity == null)
            {
                return NotFound();
            }
            raceEntity.Race_EventId = race.Race_EventId;
            raceEntity.Race_name = race.Race_name;
            raceEntity.Race_Number = race.Race_Number;
            raceEntity.Race_distance = race.Race_distance;
            raceEntity.Race_time = race.Race_time;
            raceEntity.Race_Description = race.Race_Description;
            _context.SaveChanges();
            return Ok("Race updated successfully");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRace(int id)
        {
            var raceEntity = _context.Race.Find(id);
            if (raceEntity == null)
            {
                return NotFound();
            }
            _context.Race.Remove(raceEntity);
            _context.SaveChanges();
            return Ok("Race deleted successfully");
        }
    }
}
