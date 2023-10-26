namespace PurpleBuzz_homework.Models
{
    public class ProjectComponents
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string ImagePath { get; set; }


        public ProjectComponents(int id, string title, string description, string imagePath)
        {
            Id = id;
            Title = title;
            Description = description;
            ImagePath = imagePath;
        }
    }
}
