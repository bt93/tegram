using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class UserSqlDAO : IUserDAO
    {
        private readonly string connectionString;

        public UserSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public User GetUser(string username)
        {
            User returnUser = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT user_id, username, password_hash, salt, user_role FROM users WHERE username = @username", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        returnUser = GetUserFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnUser;
        }


        public User AddUser(string username, string password, string role)
        {
            IPasswordHasher passwordHasher = new PasswordHasher();
            PasswordHash hash = passwordHasher.ComputeHash(password);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO users (username, password_hash, salt, user_role) VALUES (@username, @password_hash, @salt, @user_role)", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password_hash", hash.Password);
                    cmd.Parameters.AddWithValue("@salt", hash.Salt);
                    cmd.Parameters.AddWithValue("@user_role", role);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return GetUser(username);
        }
        public void AddUserInfo(int userId, string bio, string photoPath)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE users SET user_bio = @passed_bio, user_photo_path = @passed_path WHERE user_id = @user_id", conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@passed_bio", bio);
                    cmd.Parameters.AddWithValue("@passed_path ", photoPath);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

        }

        private User GetUserFromReader(SqlDataReader reader)
        {
            User u = new User()
            {
                UserId = Convert.ToInt32(reader["user_id"]),
                Username = Convert.ToString(reader["username"]),
                PasswordHash = Convert.ToString(reader["password_hash"]),
                Salt = Convert.ToString(reader["salt"]),
                Role = Convert.ToString(reader["user_role"]),
            };

            return u;
        }

        public GeneralUser GetUserInfo(int id)
        {
            GeneralUser user = new GeneralUser();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from USERS WHERE user_id = @user_id", conn);
                    cmd.Parameters.AddWithValue("@user_id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        user.UserId = Convert.ToInt32(reader["user_id"]);
                        user.Username = Convert.ToString(reader["username"]);
                        user.Role = Convert.ToString(reader["user_role"]);
                        user.Bio = Convert.ToString(reader["user_bio"]);
                        user.UserPhotoPath = Convert.ToString(reader["user_photo_path"]);

                    }
                }

            }
            catch (SqlException)
            {
                throw;
            }

            return user;
        }




        public User ChangeUserPassword(int userId, string password, string username)
        {
            IPasswordHasher passwordHasher = new PasswordHasher();
            PasswordHash hash = passwordHasher.ComputeHash(password);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE users SET users.password_hash = @passwordHash, users.salt = @salt where users.user_id = @userId", conn);
                    cmd.Parameters.AddWithValue("@passwordHash", hash.Password);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@salt", hash.Salt);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return GetUser(username);
        }

        public void DeleteUser(int userId)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmdFav = new SqlCommand("DELETE FROM favorite_photo where user_id = @user_id ", conn);
                    cmdFav.Parameters.AddWithValue("@user_id", userId);
                    cmdFav.ExecuteNonQuery();
                    SqlCommand cmdLike = new SqlCommand("DELETE FROM like_photo where user_id = @user_id", conn);
                    cmdLike.Parameters.AddWithValue("@user_id", userId);
                    cmdLike.ExecuteNonQuery();
                    SqlCommand cmdComment = new SqlCommand("DELETE FROM comments where user_id = @user_id", conn);
                    cmdComment.Parameters.AddWithValue("@user_id", userId);
                    cmdComment.ExecuteNonQuery();
                    SqlCommand cmdPhoto = new SqlCommand("DELETE FROM photos where user_id = @user_id", conn);
                    cmdPhoto.Parameters.AddWithValue("@user_id", userId);
                    cmdPhoto.ExecuteNonQuery();
                    SqlCommand cmdUser = new SqlCommand("DELETE FROM users where user_id = @user_id", conn);
                    cmdUser.Parameters.AddWithValue("@user_id", userId);
                    cmdUser.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
