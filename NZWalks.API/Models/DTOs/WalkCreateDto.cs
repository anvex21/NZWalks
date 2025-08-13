using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models.DTOs
{
    public class WalkCreateDto
    {
        /// <summary>
        /// Name of the walk
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Desciption
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Length of the walk
        /// </summary>
        public double LengthInKm { get; set; }

        /// <summary>
        /// WalkImageUrl
        /// </summary>
        public string? WalkImageUrl { get; set; }

        /// <summary>
        /// Difficulty Id
        /// </summary>
        public Guid DifficultyId { get; set; }
      

        /// <summary>
        /// RegionId
        /// </summary>
        public Guid RegionId { get; set; }
   
    }
}
