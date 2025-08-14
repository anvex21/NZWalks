using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTOs
{
    public class RegisterRequestDto
    {
        /// <summary>
        /// Username/Email
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Roles
        /// </summary>

        public string[] Roles { get; set; }
    }
}
