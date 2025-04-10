using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VirtualArtGallery.Entity;
using VirtualArtGallery.Util;
using VirtualArtGallery.Exceptions;

namespace VirtualArtGallery.DAO
{
    public class VirtualArtGalleryDAOImpl : IVirtualArtGalleryDAO
    {
        private SqlConnection connection;

        public VirtualArtGalleryDAOImpl(string dbFilePath)
        {
            connection = DBConnUtil.GetConnection(dbFilePath);
        }

        private void SafeOpen()
        {
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();
        }

        private void SafeClose()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
                connection.Close();
        }

        private Artwork MapArtwork(SqlDataReader reader)
        {
            return new Artwork
            {
                ArtworkID = (int)reader["ArtworkID"],
                Title = reader["Title"].ToString(),
                Description = reader["Description"].ToString(),
                CreationDate = (DateTime)reader["CreationDate"],
                Medium = reader["Medium"].ToString(),
                ImageURL = reader["ImageURL"].ToString(),
                ArtistID = (int)reader["ArtistID"]
            };
        }

        public bool AddArtwork(Artwork art)
        {
            string query = "INSERT INTO Artwork (Title, Description, CreationDate, Medium, ImageURL, ArtistID) " +
                           "VALUES (@Title, @Description, @CreationDate, @Medium, @ImageURL, @ArtistID)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Title", art.Title);
                cmd.Parameters.AddWithValue("@Description", art.Description);
                cmd.Parameters.AddWithValue("@CreationDate", art.CreationDate);
                cmd.Parameters.AddWithValue("@Medium", art.Medium);
                cmd.Parameters.AddWithValue("@ImageURL", art.ImageURL);
                cmd.Parameters.AddWithValue("@ArtistID", art.ArtistID);

                try
                {
                    SafeOpen();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("AddArtwork Error: " + ex.Message);
                    return false;
                }
                finally { SafeClose(); }
            }
        }

        public bool UpdateArtwork(Artwork art)
        {
            string query = "UPDATE Artwork SET Title=@Title, Description=@Description, CreationDate=@CreationDate, Medium=@Medium, ImageURL=@ImageURL, ArtistID=@ArtistID WHERE ArtworkID=@ArtworkID";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Title", art.Title);
                cmd.Parameters.AddWithValue("@Description", art.Description);
                cmd.Parameters.AddWithValue("@CreationDate", art.CreationDate);
                cmd.Parameters.AddWithValue("@Medium", art.Medium);
                cmd.Parameters.AddWithValue("@ImageURL", art.ImageURL);
                cmd.Parameters.AddWithValue("@ArtistID", art.ArtistID);
                cmd.Parameters.AddWithValue("@ArtworkID", art.ArtworkID);

                try
                {
                    SafeOpen();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("UpdateArtwork Error: " + ex.Message);
                    return false;
                }
                finally { SafeClose(); }
            }
        }

        public bool RemoveArtwork(int artworkId)
        {
            string query = "DELETE FROM Artwork WHERE ArtworkID=@ArtworkID";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ArtworkID", artworkId);

                try
                {
                    SafeOpen();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("RemoveArtwork Error: " + ex.Message);
                    return false;
                }
                finally { SafeClose(); }
            }
        }

        public Artwork GetArtworkById(int artworkId)
        {
            Artwork artwork = null;

            try
            {
                string query = "SELECT * FROM Artwork WHERE ArtworkID=@ArtworkID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ArtworkID", artworkId);
                    SafeOpen();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        artwork = MapArtwork(reader);
                    }
                    else
                    {
                        throw new ArtworkNotFoundException($"Artwork with ID {artworkId} not found.");
                    }

                    reader.Close();
                }
            }
            catch (ArtworkNotFoundException ex)
            {
                Console.WriteLine("Custom Exception: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }
            finally { SafeClose(); }

            return artwork;
        }

        public List<Artwork> SearchArtworks(string keyword)
        {
            List<Artwork> list = new List<Artwork>();
            string query = "SELECT * FROM Artwork WHERE Title LIKE @Keyword OR Description LIKE @Keyword";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                try
                {
                    SafeOpen();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                        list.Add(MapArtwork(reader));

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SearchArtworks Error: " + ex.Message);
                }
                finally { SafeClose(); }
            }

            return list;
        }

        public bool AddArtworkToFavorite(int userId, int artworkId)
        {
            string query = "INSERT INTO User_Favorite_Artwork (UserID, ArtworkID) VALUES (@UserID, @ArtworkID)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ArtworkID", artworkId);

                try
                {
                    SafeOpen();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("AddArtworkToFavorite Error: " + ex.Message);
                    return false;
                }
                finally { SafeClose(); }
            }
        }

        public bool RemoveArtworkFromFavorite(int userId, int artworkId)
        {
            string query = "DELETE FROM User_Favorite_Artwork WHERE UserID=@UserID AND ArtworkID=@ArtworkID";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ArtworkID", artworkId);

                try
                {
                    SafeOpen();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("RemoveArtworkFromFavorite Error: " + ex.Message);
                    return false;
                }
                finally { SafeClose(); }
            }
        }

        public List<Artwork> GetUserFavoriteArtworks(int userId)
        {
            List<Artwork> list = new List<Artwork>();
            string query = "SELECT A.* FROM Artwork A INNER JOIN User_Favorite_Artwork UFA ON A.ArtworkID = UFA.ArtworkID WHERE UFA.UserID = @UserID";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);

                try
                {
                    SafeOpen();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                        list.Add(MapArtwork(reader));

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("GetUserFavoriteArtworks Error: " + ex.Message);
                }
                finally { SafeClose(); }
            }

            return list;
        }
    }
}
