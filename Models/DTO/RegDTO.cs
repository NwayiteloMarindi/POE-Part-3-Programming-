using System.ComponentModel.DataAnnotations.Schema;

namespace Marathon.Api.Models.DTO
{
    public class RegDTO
    {
        public int Race_EventId { get; set; }
        [ForeignKey("RaceId")]
        public int RaceId { get; set; }
        public required string ParticipantName { get; set; }
        public required string ParticipantEmail { get; set; }
        public required string ParticipantPhone { get; set; }
        public required string ParticipantAddress { get; set; }
        public required string ParticipantCity { get; set; }
        public required string ParticipantProvince { get; set; }
        public required string ParticipantPostalCode { get; set; }
    }
}
