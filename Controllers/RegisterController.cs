using Marathon.Api.Data;
using Marathon.Api.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Race_Day.Models.Entities;
//In charge of handeling the registration of participants for the marathon event.

namespace Marathon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly AppDatabaseContext _context;
        public RegisterController(AppDatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllRegistrations()
        {
            var registrations = _context.Registrations.ToList();
            return Ok(registrations);
        }
        [HttpGet("{registrationId}")]
        public IActionResult GetRegistrationById(int registrationId)
        {
            var registration = _context.Registrations.FirstOrDefault(r => r.RegistrationId == registrationId);
            if (registration == null)
            {
                return NotFound("Registration not found");
            }
            return Ok(registration);
        }
        [HttpPost]
        public IActionResult RegisterParticipant(RegisterParticipant registerParticipant)
        {
            var participantEntity = new Registration
            {
                ParticipantName = registerParticipant.ParticipantName,
                ParticipantEmail = registerParticipant.ParticipantEmail,
                ParticipantPhone = registerParticipant.ParticipantPhone,
                ParticipantCity = registerParticipant.ParticipantCity,
                ParticipantProvince = registerParticipant.ParticipantProvince,
                ParticipantPostalCode = registerParticipant.ParticipantPostalCode,
                ParticipantAddress = registerParticipant.ParticipantAddress,
                UserId = registerParticipant.UserId,
                Race_EventId = registerParticipant.Race_EventId
            };
            _context.Registrations.Add(participantEntity);
            _context.SaveChanges();
            return Ok("Participant registered successfully");
        }
        [HttpPut("{registrationId}")]
        public IActionResult PutRegistration(EditRegistration registration,int Id)
        {
            var existingRegistration = _context.Registrations.Find(Id);
            if (existingRegistration == null)
            {
                return NotFound("Registration not found");
            }
            existingRegistration.ParticipantName = registration.ParticipantName;
            existingRegistration.ParticipantEmail = registration.ParticipantEmail;
            existingRegistration.ParticipantPhone = registration.ParticipantPhone;
            existingRegistration.ParticipantAddress = registration.ParticipantAddress;
            existingRegistration.ParticipantCity = registration.ParticipantCity;
            existingRegistration.ParticipantProvince = registration.ParticipantProvince;
            existingRegistration.ParticipantPostalCode = registration.ParticipantPostalCode;
            _context.SaveChanges();
            return Ok("Participant updated successfully");
        }
        [HttpDelete("{registrationId}")]
        public IActionResult DeleteRegistration(Registration registration)
        {
            var existingRegistration = _context.Registrations.FirstOrDefault(r => r.RegistrationId == registration.RegistrationId);
            if (existingRegistration == null)
            {
                return NotFound("Registration not found");
            }
            _context.Registrations.Remove(existingRegistration);
            _context.SaveChanges();
            return Ok("Participant deleted successfully");
        }
          
    }
}
