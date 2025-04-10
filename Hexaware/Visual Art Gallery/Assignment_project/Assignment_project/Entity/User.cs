namespace VirtualArtGallery.Entity
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }  // Renamed from Password
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfilePicture { get; set; }

        public User() { }

        public User(int userID, string username, string userPassword, string email, string firstName, string lastName, DateTime dateOfBirth, string profilePicture)
        {
            UserID = userID;
            Username = username;
            UserPassword = userPassword;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            ProfilePicture = profilePicture;
        }
    }
}
