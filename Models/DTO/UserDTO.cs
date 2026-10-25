using System.ComponentModel.DataAnnotations;

namespace Marathon.Api.Models.DTO
{
    public class UserDTO
    {
        [Required, StringLength(100)]
        public string UserAccountName { get; set; } = "";

        [Required, EmailAddress, StringLength(200)]
        public string UserAccountEmail { get; set; } = "";

        [Required, Phone, StringLength(20)]
        public string UserAccountPhone { get; set; } = "";

        [Required, StringLength(100, MinimumLength = 8)]
        public string Password { get; set; } = "";
    }
}