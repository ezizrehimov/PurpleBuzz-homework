namespace PurpleBuzz_homework.Models
{
    public class WorkCategories
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<WorkCategoryValues> CategoryValues { get; set; }

    }
}
