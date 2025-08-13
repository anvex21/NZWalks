using NZWalks.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTOs
{
    public class WalkCreateDto
    {
        /// <summary>
        /// Name of the walk
        /// </summary>
        [Required]
        [MaxLength(50, ErrorMessage = "The name must be a maximum of 50 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Desciption
        /// </summary>
        [Required]
        [MaxLength(500, ErrorMessage = "The description must be a maximum of 500 characters.")]
        public string Description { get; set; }

        /// <summary>
        /// Length of the walk
        /// </summary>
        [Required]
        [Range(0, 100)]
        public double LengthInKm { get; set; }

        /// <summary>
        /// WalkImageUrl
        /// </summary>
        public string? WalkImageUrl { get; set; }

        /// <summary>
        /// Difficulty Id
        /// </summary>
        [Required]
        public Guid DifficultyId { get; set; }


        /// <summary>
        /// RegionId
        /// </summary>
        [Required]
        public Guid RegionId { get; set; }
   
    }
}
