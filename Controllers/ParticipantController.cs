using Marathon.Api.Data;
using Marathon.Api.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Race_Day.Models.Entities;

namespace Marathon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly AppDatabaseContext _context;
        public ParticipantController(AppDatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetParticipants()
        {
            var participants = _context.Participants.ToList();
            return Ok(participants);
        }
        [HttpGet("{id}")]
        public IActionResult GetParticipantById(int id)
        {
            var participant = _context.Participants.Find(id);
            if (participant == null)
            {
                return NotFound();
            }
            return Ok(participant);
        }
        [HttpPost]
        public IActionResult CreateParticipant(CreateParticipant participant)
        {
            var participantEntity = new Participant
            {

                ParticipantName = participant.ParticipantName,
                ParticipantEmail = participant.ParticipantEmail,
                ParticipantPhone = participant.ParticipantPhone,
                ParticipantDOB = participant.ParticipantDOB,
                ParticipantGender = participant.ParticipantGender,
                ParticipantAddress = participant.ParticipantAddress,
                UserId = participant.UserId,
                Race_EventId = participant.Race_EventId
            };
            _context.Participants.Add(participantEntity);
            _context.SaveChanges();
            return Ok("Participant created successfully");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateParticipant(Guid id, UpdateParticipant participant)
        {
            var participantEntity = _context.Participants.Find(id);
            if (participantEntity == null)
            {
                return NotFound();
            }
            participantEntity.ParticipantName = participant.ParticipantName;
            participantEntity.ParticipantEmail = participant.ParticipantEmail;
            participantEntity.ParticipantPhone = participant.ParticipantPhone;
            participantEntity.ParticipantDOB = participant.ParticipantDOB;
            participantEntity.ParticipantGender = participant.ParticipantGender;
            participantEntity.ParticipantAddress = participant.ParticipantAddress;
            participantEntity.UserId = participant.UserId;
            participantEntity.Race_EventId = participant.Race_EventId;
            _context.SaveChanges();
            return Ok("Participant updated successfully");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteParticipant(int id)
        {
            var participantEntity = _context.Participants.Find(id);
            if (participantEntity == null)
            {
                return NotFound();
            }
            _context.Participants.Remove(participantEntity);
            _context.SaveChanges();
            return Ok("Participant deleted successfully");
        }
    }
}
