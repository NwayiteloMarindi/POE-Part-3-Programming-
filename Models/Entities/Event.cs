using System.ComponentModel.DataAnnotations;

namespace Marathon.Api.Models.Entities
{
    public class Event
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Type { get; set; }
    }
}
