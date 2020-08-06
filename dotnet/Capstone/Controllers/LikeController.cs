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
    public class LikeController : ControllerBase
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


        private readonly ILikeDAO likeDAO;

        public LikeController(ILikeDAO _likeDAO)
        {
            likeDAO = _likeDAO;
        }



        [HttpPut("{photoId}")]
        [Authorize]
        public IActionResult LikePhoto(int photoId)
        {

            likeDAO.LikePhoto(UserId, photoId);
            return Ok();
        }




        [HttpGet("{photoId}")]
        [Authorize]
        public IActionResult GetLikeState(int photoId) //user id and photo id

        {
            bool isLiked = likeDAO.GetLikeState(UserId, photoId);
            return Ok(isLiked);
        }

        // make the like exist put post
    }
}