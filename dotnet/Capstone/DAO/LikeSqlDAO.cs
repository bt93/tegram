using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class LikeSqlDAO : ILikeDAO
    {
        private readonly string connectionString;

        public LikeSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public void LikePhoto(int userId, int photoId)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO like_photo (user_id, photo_id) VALUES (@user_id, @photo_id);", conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@photo_id", photoId);
                    cmd.ExecuteNonQuery();

                    
                }
            }
            catch (SqlException)
            {
                throw;
            }

        }
    }
}
