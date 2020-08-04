using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Photo
    {
        public string FilePath { get; set; }
        public string Caption { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int LikeCount { get; set; }

        public Photo(string passedPath, string passedCaption, int passedUserID, string passedUserName, int passedNumberOfLikes)
        {
            FilePath = passedPath;
            Caption = passedCaption;
            UserID = passedUserID;
            UserName = passedUserName;
            LikeCount = passedNumberOfLikes;
        } 
    }

}
