Virtual Art Gallery - Console Application

A console-based C# application that simulates a virtual art gallery system, built using ADO.NET and SQL Server. The project allows users to manage artworks, mark favorites, and perform various CRUD operations.

Features

- Add new artworks
- Update or delete existing artworks
- View artwork details by ID
- Search artworks by keyword
- Add/remove artwork to/from favorites
- View a user's favorite artworks

Technologies Used

- C# (.NET 8)
- Visual Studio 2022
- SQL Server (SSMS)
- ADO.NET (manual DB connection)
- Layered architecture (Entity, DAO, Util, Main)

Project Structure

├── Entity │ ├── Artwork.cs │ ├── Artist.cs │ ├── User.cs │ └── Gallery.cs │ ├── DAO │ ├── IVirtualArtGalleryDAO.cs │ └── VirtualArtGalleryDAOImpl.cs │ ├── Util │ ├── DBConnUtil.cs │ └── DBPropertyUtil.cs │ ├── Main │ └── MainModule.cs │ ├── db.properties

How to Run

1. Open the project in **Visual Studio 2022**
2. Set the connection in `db.properties`:
server=BUVAN\SQLEXPRESS database=VirtualArtGalleryDB trusted_connection=true
3. Right-click `db.properties` → Properties → **Copy to Output Directory → Copy if newer**
4. Press `Ctrl + Shift + B` to build
5. Press `Ctrl + F5` to run the application

Sample Data

Artist Table

INSERT INTO Artist (Name, Biography, BirthDate, Nationality, Website, ContactInfo)
VALUES 
('Vincent van Gogh', 'Dutch painter', '1853-03-30', 'Dutch', 'www.vangogh.com', 'vg@art.com'),
('Pablo Picasso', 'Spanish painter', '1881-10-25', 'Spanish', 'www.picasso.com', 'pp@art.com');

User Table

INSERT INTO [User] (Username, UserPassword, Email, FirstName, LastName, DateOfBirth, ProfilePicture)
VALUES 
('artlover', '1234', 'artlover@mail.com', 'Aarthi', 'V', '2000-01-01', 'profile1.jpg');

Artwork Table

INSERT INTO Artwork (Title, Description, CreationDate, Medium, ImageURL, ArtistID)
VALUES 
('Starry Night', 'Famous night sky painting', '1889-06-01', 'Oil on canvas', 'starry.jpg', 1),
('Guernica', 'Anti-war painting', '1937-05-01', 'Oil on canvas', 'guernica.jpg', 2);

Favorites Table

INSERT INTO User_Favorite_Artwork (UserID, ArtworkID)
VALUES (1, 1);