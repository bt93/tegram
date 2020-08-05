using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IPhotoDAO
    {
        List<Photo> GetAllPhotos();
        List<Photo> GetUserPhotos(int user);
        void UploadPhoto(UploadPhoto uploadedPhoto);

    }

}
