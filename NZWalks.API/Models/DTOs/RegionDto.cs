namespace NZWalks.API.Models.DTOs
{
    public class RegionDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Region Code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Region Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Image url, nullable
        /// </summary>
        public string? RegionImageUrl { get; set; }
    }
}
