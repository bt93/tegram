using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IFavoriteDAO
    {
       void FavoritePhoto(int userId, int photoId);

        void UnfavoritePhoto(int userId, int photoId);

       
    }
}
