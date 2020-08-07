using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class FavoriteSqlDAO : IFavoriteDAO
    {
        private readonly string connectionString;

        public FavoriteSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public void FavoritePhoto(int userId, int photoId)
        {

            bool favoriteExists = GetPhotoFavoriteState(userId, photoId);

            if (!favoriteExists)
            {

                try
                {

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("INSERT into favorite_photo (user_id, photo_id) VALUES (@user_id, @photo_id);", conn);
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
        

        public void UnfavoritePhoto(int userId, int photoId)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE from favorite_photo where user_id = @user_id and photo_id = @photo_id", conn);
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

        //Implement check favorite method for error handling, to stop the user from being able to enter multiple favorites in the database


        public bool GetPhotoFavoriteState(int userId, int photoId)
        {

            bool favoriteExists = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select * from favorite_photo where user_id = 1 and photo_id = 5", conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@photo_id", photoId);
                    int returnedScalar = (Convert.ToInt32(cmd.ExecuteScalar()));

                    if (returnedScalar > 0)
                    {
                        favoriteExists = true;
                    }

                }
            }
            catch (SqlException)
            {
                throw;
            }

            return favoriteExists;

        }


    }
}
