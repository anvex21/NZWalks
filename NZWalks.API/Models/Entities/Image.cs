using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Models.Entities
{
    public class Image
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Uploaded file
        /// </summary>
        [NotMapped] // excludes the property from database mapping
        public IFormFile File { get; set; }

        /// <summary>
        /// FileName
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string? FileDescription { get; set; }


        /// <summary>
        /// Extension
        /// </summary>
        public string FileExtension { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        public long FileSizeInBytes { get; set; }

        /// <summary>
        /// Path to the file
        /// </summary>
        public string FilePath { get; set; }




    }
}
