using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace VirtualArtGallery.Util
{
    public class DBConnUtil
    {
        private static SqlConnection connection;

        public static SqlConnection GetConnection(string filePath)
        {
            if (connection == null)
            {
                Dictionary<string, string> props = DBPropertyUtil.GetConnectionProperties(filePath);

                string connectionString = $"Server={props["server"]}; Database={props["database"]}; Trusted_Connection=True; TrustServerCertificate=True;";
                connection = new SqlConnection(connectionString);
            }

            return connection;
        }
    }
}
