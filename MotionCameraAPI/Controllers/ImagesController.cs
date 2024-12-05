using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MotionCameraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private ImageEntityDbContext _context;

        public ImagesController(ImageEntityDbContext context)
        {
            _context = context;
        }

        [HttpGet("image/{id}")]
        public IActionResult GetImage(int id)
        {
            var image = _context.Images.FirstOrDefault(i => i.Id == id);
            if (image == null || image.ImageData == null)
            {
                return NotFound("Image not found.");
            }

            // Convert image data to Base64
            var base64Image = Convert.ToBase64String(image.ImageData);
            var imageUrl = $"data:image/jpeg;base64,{base64Image}";

            return Ok(new { imageUrl });
        }
    }
}
