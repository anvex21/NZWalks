namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

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
        /// Difficulty (navigation property)
        /// </summary>
        public Difficulty Difficulty { get; set; }

        /// <summary>
        /// RegionId
        /// </summary>
        public Guid RegiondId { get; set; }

        /// <summary>
        /// Region (navigation property)
        /// </summary>
        public Region Region { get; set; }


    }
}
