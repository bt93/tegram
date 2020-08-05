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
        public int PhotoId { get; set; }


        public Photo(string passedPath, string passedCaption, int passedUserID, string passedUserName, int passedNumberOfLikes, int passedPhotoId)
        {
            FilePath = passedPath;
            Caption = passedCaption;
            UserID = passedUserID;
            UserName = passedUserName;
            LikeCount = passedNumberOfLikes;
            PhotoId = passedPhotoId;

        }

    }

    public class UploadPhoto
    {

        public string FilePath { get; set; }
        public string Caption { get; set; }
        public int UserID { get; set; }


        public UploadPhoto(string passedPath, string passedCaption, int passedUserID) //For use when we are uploading a photo for the first time
        {           
            FilePath = passedPath;
            Caption = passedCaption;
            UserID = passedUserID;
        }
    }
}


