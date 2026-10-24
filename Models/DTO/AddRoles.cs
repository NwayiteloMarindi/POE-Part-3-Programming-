namespace Marathon.Api.Models.DTO
{
    public class AddRoles
    {
        public required string RoleName { get; set; }
        public string? RoleDescription { get; set; }
    }
}