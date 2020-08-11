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

            bool likeExists = GetLikeState(userId, photoId);

            if (!likeExists)
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
        // get the count of number of likes "select COUNT(*) as number_of_likes from like_photo where photo_id = @photo_id and user_id = @user_id"

        public void UnlikePhoto(int userId, int photoId)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE from like_photo where user_id = @user_id AND photo_id = @photo_id", conn);
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


        public bool GetLikeState(int userId, int photoId) //given a user id (the one logged in) and a photo id, check if an entry exists in the like table
        {
            bool likeState = false;
            int value = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select COUNT(*) as number_of_likes from like_photo where photo_id = @photo_id and user_id = @user_id", conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@photo_id", photoId);
                    value = Convert.ToInt32(cmd.ExecuteScalar());

                    if (value == 1)
                    {
                        likeState = true;                        
                    }

                }
            }
            catch (SqlException)
            {
                throw;
            }

            return likeState;
        }
    }
}
