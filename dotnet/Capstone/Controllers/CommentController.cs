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
    public class CommentController : ControllerBase
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
         private readonly ICommentDAO commentDAO;

        public CommentController (ICommentDAO _commentDAO)
        {
            commentDAO = _commentDAO;
        }

        [HttpPost("")]
        [Authorize]
        public IActionResult AddComment(Comment comment)
        {   
            commentDAO.AddComment(UserId, comment.PhotoId, comment.Contents);
            return Ok();
        }
    }
}