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

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("",conn); //needs query 
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
        

        public void UnfavoritePhoto(int userId, int photoId)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("", conn); //needs query
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
