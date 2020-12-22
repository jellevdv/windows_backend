using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using windows_backend.Models;

namespace windows_backend.Data
{
    public class Context : IdentityDbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ItemTask> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
