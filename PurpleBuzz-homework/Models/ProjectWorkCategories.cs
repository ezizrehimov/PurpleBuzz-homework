namespace PurpleBuzz_homework.Models
{
    public class ProjectWorkCategories
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<ProjectWorkValues> WorkValues { get; set; }

    }
}
