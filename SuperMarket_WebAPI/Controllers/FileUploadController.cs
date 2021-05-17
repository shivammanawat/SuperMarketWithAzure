using Supermarket_WebAPI.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Supermarket_WebAPI.Models;

namespace Supermarket_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileUploadController : Controller
    {
        private IFileManager _ifileManager;
       public FileUploadController(IFileManager ifileManager)
        {
            _ifileManager = ifileManager;
        }
        [HttpPost("UploadFile")]
        public async Task<IActionResult> Upload([FromForm] FileModel model)
        {
            if (model.ImageFile != null)
            {
                await _ifileManager.Upload(model);
                return Ok("File uploaded sucessfully");
            }
            return BadRequest("Invaild file");
        }
    }
}
