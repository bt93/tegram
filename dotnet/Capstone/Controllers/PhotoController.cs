using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoDAO photoDAO;

        public PhotoController (IPhotoDAO _photoDAO)
        {
            photoDAO = _photoDAO;
        }

        [HttpGet("")]
        public IActionResult GetPhotos()
        {
            List<string> paths = new List<string>();
            paths = photoDAO.GetAllPhotos();
            return Ok(paths);

        }
    }
}