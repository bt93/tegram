using System;
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



        public List<Photo> GetAllPhotos()
        {
            List<Photo> Photos = new List<Photo>();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT file_path, caption, users.user_id, users.username, (SELECT COUNT(*) from like_photo where like_photo.photo_id = photos.photo_id) as number_of_likes from photos JOIN users on users.user_id = photos.user_id ORDER BY photo_id desc", conn); 
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        string path = (Convert.ToString(reader["file_path"]));
                        string caption = (Convert.ToString(reader["caption"]));
                        int id = (Convert.ToInt32(reader["user_id"]));
                        string username = (Convert.ToString(reader["username"]));
                        int numberOfLikes = (Convert.ToInt32(reader["number_of_likes"]));

                        Photo thisPhoto = new Photo(path, caption, id, username , numberOfLikes); 

                        Photos.Add(thisPhoto);

                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return Photos;
        }

               
        public List<Photo> GetUserPhotos(int user)
        {
            List<Photo> Photos = new List<Photo>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT file_path, caption, users.user_id, users.username, (SELECT COUNT(*) from like_photo where like_photo.photo_id = photos.photo_id) as number_of_likes from photos JOIN users on users.user_id = photos.user_id  where users.user_id = @userid ORDER BY photo_id desc", conn);
                    
                    cmd.Parameters.AddWithValue("@userid", user);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        string path = (Convert.ToString(reader["file_path"]));
                        string caption = (Convert.ToString(reader["caption"]));
                        int id = (Convert.ToInt32(reader["user_id"]));
                        string username = (Convert.ToString(reader["username"]));
                        int numberOfLikes = (Convert.ToInt32(reader["number_of_likes"]));

                        Photo thisPhoto = new Photo(path, caption, id, username, numberOfLikes);

                        Photos.Add(thisPhoto);

                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return Photos;
        }

    }
}


