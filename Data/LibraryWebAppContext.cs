using Microsoft.EntityFrameworkCore;
using LibraryCollectionWebApplication.Models;

namespace LibraryCollectionWebApplication.Data
{
    public class LibraryWebAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BookCollection> BookCollections { get; set; }
        public DbSet<Book> Books { get; set; }

        public LibraryWebAppContext(DbContextOptions<LibraryWebAppContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }



    }
}
