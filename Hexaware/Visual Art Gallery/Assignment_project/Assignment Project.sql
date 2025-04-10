CREATE DATABASE VirtualArtGalleryDB;

USE VirtualArtGalleryDB;

CREATE TABLE Artist (
    ArtistID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100),
    Biography VARCHAR(MAX),
    BirthDate DATE,
    Nationality VARCHAR(50),
    Website VARCHAR(100),
    ContactInfo VARCHAR(100)
);

CREATE TABLE [User] (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50),
    Password VARCHAR(50),
    Email VARCHAR(100),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DateOfBirth DATE,
    ProfilePicture VARCHAR(200)
);

CREATE TABLE Artwork (
    ArtworkID INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(100),
    Description VARCHAR(MAX),
    CreationDate DATE,
    Medium VARCHAR(50),
    ImageURL VARCHAR(200),
    ArtistID INT FOREIGN KEY REFERENCES Artist(ArtistID)
);

CREATE TABLE Gallery (
    GalleryID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100),
    Description VARCHAR(MAX),
    Location VARCHAR(100),
    CuratorID INT FOREIGN KEY REFERENCES Artist(ArtistID),
    OpeningHours VARCHAR(100)
);

CREATE TABLE Artwork_Gallery (
    ArtworkID INT FOREIGN KEY REFERENCES Artwork(ArtworkID),
    GalleryID INT FOREIGN KEY REFERENCES Gallery(GalleryID),
    PRIMARY KEY (ArtworkID, GalleryID)
);

CREATE TABLE User_Favorite_Artwork (
    UserID INT FOREIGN KEY REFERENCES [User](UserID),
    ArtworkID INT FOREIGN KEY REFERENCES Artwork(ArtworkID),
    PRIMARY KEY (UserID, ArtworkID)
);

INSERT INTO Artist (Name, Biography, BirthDate, Nationality, Website, ContactInfo)
VALUES 
('Vincent van Gogh', 'Dutch post-impressionist painter', '1853-03-30', 'Dutch', 'www.vangogh.com', 'contact@vangogh.com'),
('Pablo Picasso', 'Spanish painter and sculptor', '1881-10-25', 'Spanish', 'www.picasso.com', 'contact@picasso.com');

INSERT INTO [User] (Username, Password, Email, FirstName, LastName, DateOfBirth, ProfilePicture)
VALUES 
('artlover1', 'pass123', 'art1@example.com', 'Alice', 'Smith', '1998-05-10', 'profile1.jpg'),
('galleryfan', 'gallery456', 'fan@example.com', 'Bob', 'Jones', '1995-09-20', 'profile2.jpg');

INSERT INTO Artwork (Title, Description, CreationDate, Medium, ImageURL, ArtistID)
VALUES 
('Starry Night', 'Famous night sky painting', '1889-06-01', 'Oil on canvas', 'starry.jpg', 1),
('Guernica', 'Anti-war painting', '1937-05-01', 'Oil on canvas', 'guernica.jpg', 2);

INSERT INTO Gallery (Name, Description, Location, CuratorID, OpeningHours)
VALUES ('Modern Art Hall', 'Features modernist works', 'New York', 1, '10AM–6PM');

INSERT INTO Artwork_Gallery (ArtworkID, GalleryID)
VALUES (1, 1), (2, 1);

INSERT INTO User_Favorite_Artwork (UserID, ArtworkID)
VALUES (1, 1), (2, 2);

USE VirtualArtGalleryDB;


INSERT INTO Artist (Name, Biography, BirthDate, Nationality, Website, ContactInfo)
VALUES 
('Vincent van Gogh', 'Dutch painter', '1853-03-30', 'Dutch', 'www.vangogh.com', 'vg@art.com'),
('Pablo Picasso', 'Spanish painter', '1881-10-25', 'Spanish', 'www.picasso.com', 'pp@art.com');

SELECT * FROM Artwork;

USE VirtualArtGalleryDB;
GO
SELECT DB_NAME() AS CurrentDB;

DELETE FROM Artwork;
DELETE FROM Artist;

DBCC CHECKIDENT ('Artwork', RESEED, 0);
DBCC CHECKIDENT ('Artist', RESEED, 0);

INSERT INTO Artist (Name, Biography, BirthDate, Nationality, Website, ContactInfo)
VALUES 
('Vincent van Gogh', 'Dutch painter', '1853-03-30', 'Dutch', 'www.vangogh.com', 'vg@art.com'),
('Pablo Picasso', 'Spanish painter', '1881-10-25', 'Spanish', 'www.picasso.com', 'pp@art.com');

SELECT * FROM Artist;

INSERT INTO Artwork (Title, Description, CreationDate, Medium, ImageURL, ArtistID)
VALUES 
('Starry Night', 'Famous night sky painting', '1889-06-01', 'Oil on canvas', 'starry.jpg', 1),
('Guernica', 'Anti-war painting', '1937-05-01', 'Oil on canvas', 'guernica.jpg', 2);

SELECT * FROM Artwork;

INSERT INTO [User] (Username, Password, Email, FirstName, LastName, DateOfBirth, ProfilePicture)
VALUES 
('artlover', '1234', 'artlover@mail.com', 'Aarthi', 'V', '2000-01-01', 'profile1.jpg');

INSERT INTO User_Favorite_Artwork (UserID, ArtworkID)
VALUES (1, 1);

INSERT INTO Gallery (Name, Description, Location, CuratorID, OpeningHours)
VALUES ('Impressionist Gallery', 'Focuses on 19th-century art', 'Paris', 1, '10AM–5PM');

INSERT INTO Artwork_Gallery (ArtworkID, GalleryID)
VALUES (1, 1);
