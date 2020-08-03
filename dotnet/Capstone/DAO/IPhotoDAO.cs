using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IPhotoDAO
    {
        List<string> GetAllPhotos();
        List<string> GetUserPhotos(int user);
    }
}
