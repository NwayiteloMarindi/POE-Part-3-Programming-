using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Race_Day.Models.Entities
{
    public class Participant
    {
        [Key]
        public int ParticipantId { get; set; }  
        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [Required]
        [ForeignKey("Race_EventId")]
        public int Race_EventId { get; set; }
        public required string ParticipantName { get; set; }
        public required string ParticipantEmail { get; set; }   
        public required string ParticipantPhone { get; set; }
        public required string ParticipantDOB { get; set; } // As in Date of Birth
        public required string ParticipantGender { get; set; } // As in Gender or Female
        public required string ParticipantAddress { get; set; }

    }
}
