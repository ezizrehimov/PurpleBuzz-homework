namespace PurpleBuzz_homework.Models
{
    public class WorkCategoryValues
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public WorkCategories workCategories { get; set; }

        public int ValuesId { get; set; }

        public WorkValues workValues { get; set; }

    }
}
