using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
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
            List<Photo> Photos = new List<Photo>();
            Photos = photoDAO.GetAllPhotos();
            return Ok(Photos);
        }

        [HttpGet("{user}")]
        public IActionResult GetUserPhotos(int user)
        {
            List<Photo> Photos = new List<Photo>();
            Photos = photoDAO.GetUserPhotos(user);
            return Ok(Photos);
        }

        [HttpPost("upload")]
        [Authorize]
        public IActionResult UploadPhoto(UploadPhoto uploadedPhoto)
        {
            photoDAO.UploadPhoto(uploadedPhoto);
            return Ok();
        }

    }




}