﻿using Microsoft.EntityFrameworkCore;
using PurpleBuzz_homework.Models;

namespace PurpleBuzz_homework.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {


        }
      
        public DbSet<ProjectComponents> ProjectComponents { get; set; }

    }
}
