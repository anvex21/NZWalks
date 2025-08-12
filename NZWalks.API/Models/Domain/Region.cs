namespace NZWalks.API.Models.Domain
{
    public class Region
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
