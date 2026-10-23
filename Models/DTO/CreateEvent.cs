namespace Marathon.Api.Models.DTO
{
    public class CreateEvent
    {
        public required DateTime EndDate { get; set; }
        public required DateTime StartDate { get; set; }

        public required string Title { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateTime Date { get; set; }
        public required string Location { get; set; }
    }
}
