using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTOs
{
    public class LoginRequestDto
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

    }
}
