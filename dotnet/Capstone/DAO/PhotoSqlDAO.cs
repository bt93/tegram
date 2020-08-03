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

        public List<string> GetAllPhotos()
        {
            List<string> filePaths = new List<string> ();
            
            // Hardcoded Values for Testing
            filePaths.Add(@"C:\Users\Student\git\c-final-capstone-te-gram\dotnet\Capstone\photos\3408.jpg");
            filePaths.Add(@"C:\Users\Student\git\c-final-capstone-te-gram\dotnet\Capstone\photos\dogs_1280p_0.jpg");
            filePaths.Add(@"C:\Users\Student\git\c-final-capstone-te-gram\dotnet\Capstone\photos\dog-tales-img.jpg");
            filePaths.Add(@"C:\Users\Student\git\c-final-capstone-te-gram\dotnet\Capstone\photos\pearl_16x9.jpg");
            // End of Hardcoded Values for Testing


/*            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT file_path FROM photos", conn); //Select every single file path stored in the photos table
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
            }*/

            return filePaths;
        }

    }
}


