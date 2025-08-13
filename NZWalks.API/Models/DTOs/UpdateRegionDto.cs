using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTOs
{
    public class UpdateRegionDto
    {
        /// <summary>
        /// Region Code
        /// </summary>
        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "The code must be 3 characters.")]
        public string Code { get; set; }
        /// <summary>
        /// Region Name
        /// </summary>
        [Required]
        [MaxLength(50, ErrorMessage = "The name must be a maximum of 50 characters.")]
        public string Name { get; set; }
        /// <summary>
        /// Image url, nullable
        /// </summary>
        public string? RegionImageUrl { get; set; } 
    }
}
