using Context.models;
using Context.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public class AssigmentContext : IdentityDbContext<User>
    {
        public AssigmentContext(DbContextOptions<AssigmentContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
}