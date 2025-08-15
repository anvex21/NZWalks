using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Models.Entities;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadFile(ImageUploadDto dto)
        {
            ValidateFileUpload(dto);
            if (ModelState.IsValid)
            {
                Image imageEntity = new Image
                {
                    File = dto.File,
                    FileExtension = Path.GetExtension(dto.File.FileName),
                    FileSizeInBytes = dto.File.Length,
                    FileName = dto.FileName,
                    FileDescription = dto.FileDescription
                };
                await imageRepository.Upload(imageEntity);
                return Ok(imageEntity);
            }
            return BadRequest(ModelState);
        }
        private void ValidateFileUpload(ImageUploadDto dto)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowedExtensions.Contains(Path.GetExtension(dto.File.FileName))){
                ModelState.AddModelError("file", "unsupported file extension");
            }
            // 10mb
            if(dto.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "file size more than 10mb");
            }
        }
    }
}
