using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface ICommentDAO
    {
        void AddComment(int userId, int photoId, string contents);
    }
}
