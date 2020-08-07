using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Capstone.Security;
using System.Security.Claims;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
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


        private readonly IFavoriteDAO favoriteDAO;

        public FavoriteController(IFavoriteDAO _favoriteDAO)
        {
            favoriteDAO = _favoriteDAO;
        }


        // Method to get the list of users favorites




        //Method to enter a favorite into the table
        /// <summary>
        /// Creates an entry in favorite_photo reflecting
        /// the authorized user and the specified photo.
        /// </summary>
        /// <param name="photoId"></param>
        /// <returns></returns>
        [HttpPost("{photoId}")]
        [Authorize]
        public IActionResult FavoritePhoto(int photoId)
        {
            favoriteDAO.FavoritePhoto(UserId, photoId);
                        
            return Ok();
        }


        //Method to delete a favorite from the table

        /// <summary>
        ///  Deletes all instances of favorites matching
        ///  the authorized user and the specified photo.
        /// </summary>
        /// <param name="photoId"></param>
        /// <returns></returns>
        [HttpDelete("{photoId}")] 
        [Authorize]
        public IActionResult UnfavoritePhoto(int photoId)
        {
            favoriteDAO.UnfavoritePhoto(UserId, photoId);

            return Ok();
        }
    }
}