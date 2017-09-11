namespace PhotoShare.Services
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class UserService
    {
        public void AddUser(string username, string password, string email)
        {
            User user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };

            using (PhotoShareContext context = new PhotoShareContext())
            {
                //start my changes
                if (context.Users.Any(u => u.Username == user.Username))
                {
                    throw new InvalidOperationException("Username" + user.Username + "is already taken!");
                }
                //end my changes
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}