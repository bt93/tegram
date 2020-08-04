﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Capstone.Models;


namespace Capstone.DAO
{
    public class PhotoSqlDAO : IPhotoDAO
    {
        private readonly string connectionString;

        public PhotoSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }



        public List<string> GetAllPhotos()
        {
            List<string> filePaths = new List<string> ();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT TOP 5 file_path FROM photos ORDER BY photo_id desc", conn); //Select every single file path stored in the photos table
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        filePaths.Add(Convert.ToString(reader["file_path"]));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return filePaths;
        }




        public List<string> GetUserPhotos(int user)
        {
            List<string> filePaths = new List<string>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT file_path from photos JOIN users on users.user_id = photos.user_id where users.user_id = @userid ORDER BY photo_id desc", conn);
                    cmd.Parameters.AddWithValue("@userid", user);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        filePaths.Add(Convert.ToString(reader["file_path"]));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return filePaths;
        }

    }
}


