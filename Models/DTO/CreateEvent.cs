namespace Marathon.Api.Models.DTO
{
    public class CreateEvent
    {
        internal DateTime EndDate;
        internal DateTime StartDate;

        public required string Title { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateTime Date { get; set; }
        public required string Location { get; set; }
    }
}
