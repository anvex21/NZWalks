using NZWalks.API.Data;
using NZWalks.API.Models.Entities;

namespace NZWalks.API.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHost;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly NZWalksDbContext context;

        public ImageRepository(IWebHostEnvironment webHost, IHttpContextAccessor contextAccessor, NZWalksDbContext context)
        {
            this.webHost = webHost;
            this.contextAccessor = contextAccessor;
            this.context = context;
        }
        /// <summary>
        /// Upload image logic
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public async Task<Image> Upload(Image image)
        {
            string localFilePath = Path.Combine(webHost.ContentRootPath, "Images", $"{image.FileName}{image.FileExtension}");
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);
            string urlFilePath = $"{contextAccessor.HttpContext.Request.Scheme}://{contextAccessor.HttpContext.Request.Host}{contextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";
            image.FilePath = urlFilePath;
            await context.Images.AddAsync(image);
            await context.SaveChangesAsync();
            return image;



        }
    }
}
