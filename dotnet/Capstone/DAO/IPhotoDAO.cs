﻿using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IPhotoDAO
    {
        List<Photo> GetAllPhotos();
        List<Photo> GetUserPhotos(int user);
        void UploadPhoto(UploadPhoto uploadedPhoto);
        Photo GetDetailPhoto(int photoId);
        List<Photo> GetAuthenticatedUserFavoritePhotos(int UserId);
        void DeletePhoto(int photoId, int userId);
        List<Photo> GetPartitionedPhotos(int pageNumber, int RowsPerPage);
    }

}
