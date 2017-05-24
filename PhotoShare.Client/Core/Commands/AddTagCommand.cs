namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Models;
    using Utilities;
    using PhotoShare.Data;


    public class AddTagCommand
    {
        // AddTag <tag>
        public string Execute(string[] data)
        {
            string tag = data[1].ValidateOrTransform();

            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Tags.Add(new Tag
                {
                    Name = tag
                });

                context.SaveChanges();
            }

            return tag + " was added successfully to database!";
        }
    }
}
