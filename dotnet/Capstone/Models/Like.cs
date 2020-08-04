using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Like
    {

        public int UserId { get; set; }
        public int PhotoId { get; set; }

        public Like(int passedUserId, int passedPhotoId)
        {
            UserId = passedPhotoId;
            PhotoId = passedPhotoId;

        }
    }
}
