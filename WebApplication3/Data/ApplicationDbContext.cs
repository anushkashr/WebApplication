﻿using Microsoft.EntityFrameworkCore;
using WebApplication3.Properties.Models;

namespace WebApplication3.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }


    }
}
