namespace Marathon.Api.Models.DTO
{
    public class UpdateParticipant
    {
        public required string ParticipantName { get; set; }
        public required string ParticipantEmail { get; set; }
        public required string ParticipantPhone { get; set; }
        public required string ParticipantDOB { get; set; }
        public required string ParticipantGender { get; set; }
        public required string ParticipantAddress { get; set; }
        public int UserId { get; set; }
        public int Race_EventId { get; set; }
    }
}