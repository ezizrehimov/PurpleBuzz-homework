namespace PurpleBuzz_homework.Models
{
    public class ProjectContactInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Icon { get; set; }

        public ProjectContactInfo(int id, string name, string position, string phoneNumber, string icon)
        {
            Id = id;
            Name = name;
            Position = position;
            PhoneNumber = phoneNumber;
            Icon = icon;
        }
    }
}
