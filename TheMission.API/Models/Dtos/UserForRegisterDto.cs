using System.ComponentModel.DataAnnotations;

namespace TheMission.API.Models.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Password length must be between 6 and 16 characters.")]
        public string Password { get; set; }
    }
}