using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Comment
    {
        public int UserId { get; set; }
        public int PhotoId { get; set; }
        public string Contents { get; set; }
        public string UserName { get; set; }

        public Comment(int passedPhotoId, string contents, string username)
        {
            PhotoId = passedPhotoId;
            Contents = contents;
            UserName = username;
        }
    }
}
