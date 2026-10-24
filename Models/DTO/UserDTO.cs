namespace Marathon.Api.Models.DTO
{
    public class UserDTO
    {
        public int UserAccountId { get; set; }
        public required string UserAccountName { get; set; }
        public required string UserAccountEmail { get; set; }
        public required string UserAccountPassword { get; set; }
        public required string UserAccountRole { get; set; }
        public required string UserAccountPhone { get; set; }
    }
}
