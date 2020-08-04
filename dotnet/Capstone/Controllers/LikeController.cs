using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeDAO likeDAO;
        public LikeController(ILikeDAO _likeDAO)
        {
            likeDAO = _likeDAO;
        }


        [HttpPut("")]
        public IActionResult LikePhoto(Like like)
        {

            likeDAO.LikePhoto(like.UserId, like.PhotoId);
            return Ok();
        }
    }
}