using System.ComponentModel.DataAnnotations.Schema;

namespace Marathon.Api.Models.DTO
{
    public class RegisterParticipant
    {
        [ForeignKey("Race_EventId")]
        public int Race_EventId { get; set; }
        [ForeignKey("RaceId")]
        public int RaceId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("ParticipantId")]
        public int ParticipantId { get; set; }
        public required string ParticipantName { get; set; }
        public required string ParticipantEmail { get; set; }
        public required string ParticipantPhone { get; set; }
        public required string ParticipantAddress { get; set; }
        public required string ParticipantCity { get; set; }
        public required string ParticipantProvince { get; set; }
        public required string ParticipantPostalCode { get; set; }
        public int RegistrationId { get; internal set; }
        public required string ParticipantGender { get; set; }
        public required string ParticipantDOB { get; set; } // As in Date of Birth
       
    }
}
