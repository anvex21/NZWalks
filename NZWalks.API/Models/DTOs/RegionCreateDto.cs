namespace NZWalks.API.Models.DTOs
{
    public class RegionCreateDto
    {
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
