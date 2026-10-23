using System.ComponentModel.DataAnnotations;

namespace Marathon.Api.Models.DTO
{
    public class CreateRace_Event
    {
        
        public required string Race_EventName { get; set; }
        public required DateOnly Race_EventDate { get; set; }
        public required string Description { get; set; }

        public required string Race_EventStatus { get; set; }
    }
}
