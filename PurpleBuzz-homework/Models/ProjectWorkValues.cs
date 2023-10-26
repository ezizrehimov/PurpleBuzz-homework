namespace PurpleBuzz_homework.Models
{
    public class ProjectWorkValues
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public ProjectWorkValues(int id, string title, string description, string imagePath)
        {
            Id = id;
            Title = title;
            Description = description;
            ImagePath = imagePath;
        }
    }
}
