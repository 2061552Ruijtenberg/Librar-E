using Microsoft.EntityFrameworkCore;
using LibraryCollectionWebApplication.Models;
using System.Reflection.Emit;

namespace LibraryCollectionWebApplication.Data
{
    public class LibraryWebAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Book> Books { get; set; }

        public LibraryWebAppContext(DbContextOptions<LibraryWebAppContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().Property(p => p.Price).HasPrecision(10, 2);
            modelBuilder.Entity<Book>().Property(p => p.Worth).HasPrecision(10, 2);
        }



    }
}
