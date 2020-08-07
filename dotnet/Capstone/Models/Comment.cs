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

        public Comment(int passedPhotoId, string contents)
        {
            PhotoId = passedPhotoId;
            Contents = contents;
        }
    }
}
