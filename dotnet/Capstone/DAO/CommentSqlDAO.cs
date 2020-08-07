using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class CommentSqlDAO : ICommentDAO
    {
        private readonly string connectionString;

        public CommentSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        

        public void AddComment(int userId, int photoId, string contents)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT into comments (user_id, photo_id, contents) VALUES (@user_id, @photo_id, @contents)", conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@photo_id", photoId);
                    cmd.Parameters.AddWithValue("@contents", contents);
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
