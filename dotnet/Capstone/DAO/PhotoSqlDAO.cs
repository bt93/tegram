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


    //TODO Add comment functionality to other Get Photo Methods

    public List<Photo> GetAllPhotos()
        {
            List<Photo> Photos = new List<Photo>();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT file_path, caption, users.user_id, users.username, (SELECT COUNT(*) from like_photo where like_photo.photo_id = photos.photo_id) as number_of_likes, photos.photo_id from photos JOIN users on users.user_id = photos.user_id ORDER BY photo_id desc", conn); 
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        string path = (Convert.ToString(reader["file_path"]));
                        string caption = (Convert.ToString(reader["caption"]));
                        int id = (Convert.ToInt32(reader["user_id"]));
                        string username = (Convert.ToString(reader["username"]));
                        int numberOfLikes = (Convert.ToInt32(reader["number_of_likes"]));
                        int photoId = (Convert.ToInt32(reader["photo_id"]));
                        
                        Photo thisPhoto = new Photo(path, caption, id, username, numberOfLikes, photoId);

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
            List<String> comments = new List<string>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT file_path, caption, users.user_id, users.username, (SELECT COUNT(*) from like_photo where like_photo.photo_id = photos.photo_id) as number_of_likes, photos.photo_id from photos JOIN users on users.user_id = photos.user_id  where users.user_id = @userid ORDER BY photo_id desc", conn);
                    
                    cmd.Parameters.AddWithValue("@userid", user);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        string path = (Convert.ToString(reader["file_path"]));
                        string caption = (Convert.ToString(reader["caption"]));
                        int id = (Convert.ToInt32(reader["user_id"]));
                        string username = (Convert.ToString(reader["username"]));
                        int numberOfLikes = (Convert.ToInt32(reader["number_of_likes"]));
                        int photoId = (Convert.ToInt32(reader["photo_id"]));

                        Photo thisPhoto = new Photo(path, caption, id, username, numberOfLikes, photoId);

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


        public void UploadPhoto(UploadPhoto uploadedPhoto)
        {
            //bool uploadSuccessful = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO photos (file_path, user_id, caption) VALUES (@filePath, @userId, @caption);", conn);
                    cmd.Parameters.AddWithValue("@filePath", uploadedPhoto.FilePath);
                    cmd.Parameters.AddWithValue("@userId", uploadedPhoto.UserID);
                    cmd.Parameters.AddWithValue("@caption", uploadedPhoto.Caption);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }


        public Photo GetDetailPhoto(int photo)
        {
            Photo assembledPhoto = new Photo();
            List<Comment> comments = new List<Comment>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                                                    
                    SqlCommand cmd = new SqlCommand("SELECT file_path, caption, users.user_id, users.username, photos.photo_id,(SELECT COUNT(*) from like_photo where like_photo.photo_id = photos.photo_id) as number_of_likes from photos JOIN users on users.user_id = photos.user_id  where photos.photo_id = @photoId", conn);

                    cmd.Parameters.AddWithValue("@photoId", photo);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string path = (Convert.ToString(reader["file_path"]));
                        string caption = (Convert.ToString(reader["caption"]));
                        int id = (Convert.ToInt32(reader["user_id"]));
                        string username = (Convert.ToString(reader["username"]));
                        int numberOfLikes = (Convert.ToInt32(reader["number_of_likes"]));
                        int photoId = (Convert.ToInt32(reader["photo_id"]));

                        assembledPhoto = new Photo(path, caption, id, username, numberOfLikes, photoId);
                    }
                    reader.Close();

                    //Gets the comments for a photo and stores them in a list within the photo object
                    cmd = new SqlCommand("SELECT contents, username, users.user_id from comments JOIN users on users.user_id = comments.user_id where photo_id = @photoId", conn);
                    cmd.Parameters.AddWithValue("@photoId", photo);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string comment = (Convert.ToString(reader["contents"]));
                        string username = (Convert.ToString(reader["username"]));
                        Comment thisComment = new Comment(photo, comment, username);
                        thisComment.UserId = (Convert.ToInt32(reader["user_id"]));



                        comments.Add(thisComment);
                    }
                    assembledPhoto.Comments = comments;

                }

            }
            catch (SqlException)
            {
                throw;
            }

            return assembledPhoto;
        }

        public List<Photo> GetAuthenticatedUserFavoritePhotos(int UserId)
        {
            List<int> authenticatedFavoritedPhotoIds = new List<int>();
            List<Photo> favoritedPhotos = new List<Photo>();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //get a list of photo ids

                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select * from favorite_photo where user_id = @user_id", conn);

                    cmd.Parameters.AddWithValue("@user_id", UserId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = (Convert.ToInt32(reader["photo_id"]));
                        authenticatedFavoritedPhotoIds.Add(id);
                                             
                    }
                    reader.Close();

                    //for each ID

                    foreach (int id in authenticatedFavoritedPhotoIds)
                    {
                        favoritedPhotos.Add(GetDetailPhoto(id));
                    }

                }

            }
            catch (SqlException)
            {
                throw;
            }

            return favoritedPhotos;


        }
        public void DeletePhoto(int photoId, int userId)
        {
            Photo photo = GetDetailPhoto(photoId);
            if (userId == photo.UserID)
            {
                try
                {

                    //deletePhoto includes four sql delete statements that removes from like_photo ,favorite_photo ,comments and photos
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmdFav = new SqlCommand("EXEC deletePhoto @photo_id = @photoId", conn);
                        cmdFav.Parameters.AddWithValue("@photoId", photoId);
                        cmdFav.ExecuteNonQuery();

                    }
                }
                catch (SqlException)
                {
                    throw;
                }
            }
            
        }
        public List<Photo> GetPartitionedPhotos(int pageNumber, int RowsPerPage)
        {
            List<Photo> Photos = new List<Photo>();
            RowsPerPage = 15;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("EXEC photosByPage @PageNumber = @Page_Number, @RowsPerPage = @Rows_Per_Page", conn);
                    cmd.Parameters.AddWithValue("@Page_Number", pageNumber);
                    cmd.Parameters.AddWithValue("@Rows_Per_Page", RowsPerPage);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        string path = (Convert.ToString(reader["file_path"]));
                        string caption = (Convert.ToString(reader["caption"]));
                        int id = (Convert.ToInt32(reader["user_id"]));
                        string username = (Convert.ToString(reader["username"]));
                        int numberOfLikes = (Convert.ToInt32(reader["number_of_likes"]));
                        int photoId = (Convert.ToInt32(reader["photo_id"]));

                        Photo thisPhoto = new Photo(path, caption, id, username, numberOfLikes, photoId);

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


