using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz_homework.Models;

namespace PurpleBuzz_homework.DAL
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {


        }

        public DbSet<Services> Services { get; set; }
        public DbSet<WorkCategories> WorkCategories { get; set; }
        public DbSet<WorkValues> WorkValues { get; set; }
        public DbSet<RecentWork> RecentWorks { get; set; }
        public DbSet<WorkCategoryValues> CategoryValues { get; set; }
        public DbSet<ObjectiveComponent> ObjectiveComponents { get; set; }

        public DbSet<TeamMembers> TeamMembers { get; set; }
        public DbSet<FeaturedWork> FeaturedWorks { get; set; }
        public DbSet<FeaturedWorkPhoto> FeaturedWorkPhotos { get; set; }
    }
}
