namespace PurpleBuzz_homework.Models
{
    public class WorkValues
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public List<WorkCategoryValues> CategoryValues { get; set; }

    }
}
