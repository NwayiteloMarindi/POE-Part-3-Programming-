using System.ComponentModel.DataAnnotations.Schema;

namespace Marathon.Api.Models.DTO
{
    public class GenerateTicketDTOcs
    {
        [ForeignKey("Race_EventId")]
        public int Race_EventId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public required string TicketType { get; set; }
        public required decimal TicketPrice { get; set; }
        public string? TicketName { get; set; }
        public string? TicketDescription { get; set; }
        public required DateOnly PurchaseDate { get; set; }
        public required string TicketStatus { get; set; }
    }
}
