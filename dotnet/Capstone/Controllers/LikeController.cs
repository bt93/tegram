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
    public class LikeController : ControllerBase
    {
        private readonly ILikeDAO likeDAO;
        public LikeController(ILikeDAO _likeDAO)
        {
            likeDAO = _likeDAO;
        }

        [HttpPut("")]
        public IActionResult LikePhoto(int userId, int photoId)
        {
            likeDAO.LikePhoto(userId, photoId);
            return Ok();
        }
    }
}