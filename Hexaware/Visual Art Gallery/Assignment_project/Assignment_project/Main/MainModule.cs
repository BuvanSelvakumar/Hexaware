using System;
using System.Collections.Generic;
using VirtualArtGallery.DAO;
using VirtualArtGallery.Entity;

namespace VirtualArtGallery.Main
{
    class MainModule
    {
        static void Main(string[] args)
        {
            string dbFilePath = @"db.properties";
            IVirtualArtGalleryDAO dao = new VirtualArtGalleryDAOImpl(dbFilePath);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n===== Virtual Art Gallery Menu =====");
                Console.WriteLine("1. Add Artwork");
                Console.WriteLine("2. View Artwork by ID");
                Console.WriteLine("3. Update Artwork");
                Console.WriteLine("4. Delete Artwork");
                Console.WriteLine("5. Search Artworks");
                Console.WriteLine("6. Add to Favorites");
                Console.WriteLine("7. Remove from Favorites");
                Console.WriteLine("8. View User's Favorite Artworks");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Artwork art = new Artwork();
                        Console.Write("Title: ");
                        art.Title = Console.ReadLine();
                        Console.Write("Description: ");
                        art.Description = Console.ReadLine();
                        Console.Write("Creation Date (yyyy-mm-dd): ");
                        art.CreationDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Medium: ");
                        art.Medium = Console.ReadLine();
                        Console.Write("Image URL: ");
                        art.ImageURL = Console.ReadLine();
                        Console.Write("Artist ID: ");
                        art.ArtistID = int.Parse(Console.ReadLine());
                        Console.WriteLine(dao.AddArtwork(art) ? "Artwork added." : "Failed to add artwork.");
                        break;

                    case "2":
                        Console.Write("Enter Artwork ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Artwork found = dao.GetArtworkById(id);
                        if (found != null)
                        {
                            Console.WriteLine($"Title: {found.Title}\nDescription: {found.Description}\nCreated On: {found.CreationDate}\nMedium: {found.Medium}");
                        }
                        else
                        {
                            Console.WriteLine("Artwork not found.");
                        }
                        break;

                    case "3":
                        Console.Write("Enter Artwork ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Artwork existing = dao.GetArtworkById(updateId);
                        if (existing != null)
                        {
                            Console.Write("New Title: ");
                            existing.Title = Console.ReadLine();
                            Console.Write("New Description: ");
                            existing.Description = Console.ReadLine();
                            Console.Write("New Creation Date (yyyy-mm-dd): ");
                            existing.CreationDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("New Medium: ");
                            existing.Medium = Console.ReadLine();
                            Console.Write("New Image URL: ");
                            existing.ImageURL = Console.ReadLine();
                            Console.Write("New Artist ID: ");
                            existing.ArtistID = int.Parse(Console.ReadLine());

                            Console.WriteLine(dao.UpdateArtwork(existing) ? "Artwork updated." : "Failed to update artwork.");
                        }
                        else
                        {
                            Console.WriteLine("Artwork not found.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter Artwork ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        Console.WriteLine(dao.RemoveArtwork(deleteId) ? "Artwork deleted." : "Failed to delete artwork.");
                        break;

                    case "5":
                        Console.Write("Enter keyword to search: ");
                        string keyword = Console.ReadLine();
                        List<Artwork> results = dao.SearchArtworks(keyword);
                        foreach (var a in results)
                        {
                            Console.WriteLine($"#{a.ArtworkID} - {a.Title} ({a.Medium})");
                        }
                        break;

                    case "6":
                        Console.Write("User ID: ");
                        int userId = int.Parse(Console.ReadLine());
                        Console.Write("Artwork ID: ");
                        int favId = int.Parse(Console.ReadLine());
                        Console.WriteLine(dao.AddArtworkToFavorite(userId, favId) ? "Added to favorites." : "Failed to add.");
                        break;

                    case "7":
                        Console.Write("User ID: ");
                        int rUser = int.Parse(Console.ReadLine());
                        Console.Write("Artwork ID: ");
                        int rArt = int.Parse(Console.ReadLine());
                        Console.WriteLine(dao.RemoveArtworkFromFavorite(rUser, rArt) ? "Removed from favorites." : "Failed to remove.");
                        break;

                    case "8":
                        Console.Write("Enter User ID: ");
                        int favUserId = int.Parse(Console.ReadLine());
                        List<Artwork> favs = dao.GetUserFavoriteArtworks(favUserId);
                        Console.WriteLine("Favorite Artworks:");
                        foreach (var f in favs)
                        {
                            Console.WriteLine($"{f.ArtworkID} - {f.Title}");
                        }
                        break;

                    case "9":
                        exit = true;
                        Console.WriteLine("Exiting. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
