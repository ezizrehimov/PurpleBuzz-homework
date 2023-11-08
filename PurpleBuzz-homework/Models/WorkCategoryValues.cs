namespace PurpleBuzz_homework.Models
{
    public class WorkCategoryValues
    {
        public int Id { get; set; }

        public int workCategoriesId { get; set; }

        public WorkCategories workCategories { get; set; }

        public int workValuesId { get; set; }

        public WorkValues workValues { get; set; }

    }
}
