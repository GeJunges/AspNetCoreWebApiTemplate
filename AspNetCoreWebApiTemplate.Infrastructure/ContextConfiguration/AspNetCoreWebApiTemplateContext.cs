using AspNetCoreWebApiTemplate.Domain.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApiTemplate.Infrastructure.ContextConfiguration
{
    public class AspNetCoreWebApiTemplateContext : DbContext
    {
        public AspNetCoreWebApiTemplateContext(DbContextOptions<AspNetCoreWebApiTemplateContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>();
        }
    }
}
