using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        protected string UserName
        {
            get
            {
                return User?.Identity?.Name;
            }
        }


        protected int UserId
        {
            get
            {
                int userId = 0;
                Claim subjectClaim = User?.Claims?.Where(cl => cl.Type == "sub").FirstOrDefault();
                if (subjectClaim != null)
                {
                    int.TryParse(subjectClaim.Value, out userId);
                }
                return userId;
            }
        }


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

        [HttpGet("page/{number}")]
        public IActionResult GetPartitionedPhotos(int number)
        {
            //get the page number from the route
            int pageNumber = number; 
            //Create a list of Photos
            List<Photo> Photos = new List<Photo>();
            //Populate that list of photos with the DAO
            Photos = photoDAO.GetAllPhotos();
            //Divide photos into sets, (Ultimately 20 photos per page)
            List<Photo> requestedPhotos = new List<Photo>();
            int endIndex = pageNumber * 5;
            int startIndex = endIndex - 5;

            int remainingValue = ((Photos.Count - (pageNumber * 5)) +5);

            //after dividing by the page number
            //check that the remaining value is or is not greater than 5
            
            if (remainingValue < 5)
            {
                for (int i = (remainingValue + ((pageNumber-1) * 5)); i <= Photos.Count; i++)
                {
                    requestedPhotos.Add(Photos[i-1]);
                }
            }
            else {
                for (int i = startIndex; i < endIndex; i++)
                {
                    requestedPhotos.Add(Photos[i]);
                }
            }

            return Ok(requestedPhotos);
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
        [HttpDelete("{photoId}")]
        [Authorize]
        public IActionResult DeletePhoto(int photoId)
        {
            photoDAO.DeletePhoto(photoId, UserId);
            return Ok();

        }



        /// <summary>
        ///  Get a single Photo including all information 
        ///  required for a detail view.
        ///  path of /photo/detail/(photoId)
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet("detail/{photoId}")]
        public IActionResult GetDetailPhoto(int photoId)
        {
            Photo photo = new Photo();
            photo = photoDAO.GetDetailPhoto(photoId);
            return Ok(photo);
        }


    }




}