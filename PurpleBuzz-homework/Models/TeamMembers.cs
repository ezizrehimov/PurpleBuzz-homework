namespace PurpleBuzz_homework.Models
{
    public class TeamMembers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string ImagePath { get; set; }

     
        public TeamMembers(int id, string name, string description, string imagePath)
        {
            Id = id;
            Name = name;
            Description = description;
            ImagePath = imagePath;
        }
    }
}
