using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Users.Domain;

namespace Users.Context
{
    public class UserContext : DbContext, IUserContext
    {
        protected UserContext()
        {
            Database.Migrate();
        }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.Migrate();
        }
        
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
