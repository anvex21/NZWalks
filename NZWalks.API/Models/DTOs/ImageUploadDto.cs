using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTOs
{
    public class ImageUploadDto
    {
        /// <summary>
        /// File
        /// </summary>
        [Required]
        public IFormFile File { get; set; }

        /// <summary>
        /// FileName
        /// </summary>
        [Required]
        public string FileName { get; set; }

        public string? FileDescription { get; set; }

    }
}
