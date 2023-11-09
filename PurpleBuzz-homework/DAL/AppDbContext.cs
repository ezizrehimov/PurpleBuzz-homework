using Microsoft.EntityFrameworkCore;
using PurpleBuzz_homework.Models;

namespace PurpleBuzz_homework.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {


        }

        public DbSet<Services> Services { get; set; }
        public DbSet<WorkCategories> WorkCategories { get; set; }
        public DbSet<WorkValues> WorkValues { get; set; }
        public DbSet<RecentWork> RecentWorks { get; set; }
        public DbSet<WorkCategoryValues> CategoryValues { get; set; }

    }
}
