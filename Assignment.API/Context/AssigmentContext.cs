using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Services.models;

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

    }
}