namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using PhotoShare.Data;
    using System;
    using System.Linq;

    public class AddTownCommand
    {
        // AddTown <townName> <countryName>
        public string Execute(string[] data)
        {
            string townName = data[0];
            string country = data[1];

            using (PhotoShareContext context = new PhotoShareContext())
            {
                //start my changes
                if (context.Towns.Any(t => t.Name == townName))
                {
                    throw new ArgumentException("Town" + townName + "was already added!");
                }
                //end my changes

                Town town = new Town
                {
                    Name = townName,
                    Country = country
                };

                context.Towns.Add(town);
                context.SaveChanges();

                return "Town" + townName + " was added successfully!";
            }
        }
    }
}