namespace PhotoShare.Client.Core.Commands
{
    using Services;
    using System;

    public class RegisterUserCommand
    {
        private readonly UserService service;

        public RegisterUserCommand(UserService service)
        {
            this.service = service;
        }

        // RegisterUser <username> <password> <repeat-password> <email>
        public string Execute(string[] data)
        {
            string username = data[0];
            string password = data[1];
            string repeatPassword = data[2];
            string email = data[3];

            if (password != repeatPassword)
            {
                throw new ArgumentException("Passwords do not match!");
            }

            this.service.AddUser(username, password, email);

            return "User " + username + " was registered successfully!";
        }
    }
}