using Microsoft.EntityFrameworkCore;
using LibraryCollectionWebApplication.Models;
using Microsoft.Extensions.Hosting;
using LibraryCollectionWebApplication.Models.ViewModels;

namespace LibraryCollectionWebApplication.Data
{
    public class LibraryWebAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books {get; set;}    
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Tag> TagList {  get; set; }    

        public LibraryWebAppContext(DbContextOptions<LibraryWebAppContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(p => p.Price).HasPrecision(10, 2);
            modelBuilder.Entity<Book>().Property(p => p.Worth).HasPrecision(10, 2);
            modelBuilder.Entity<Book>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Books)
                .UsingEntity(
                    "BookTag", 
                    b => b.HasOne(typeof(Book)).WithMany().HasForeignKey("BooksId").HasPrincipalKey(nameof(Book.Id)),
                    r => r.HasOne(typeof(Tag)).WithMany().HasForeignKey("TagsId").HasPrincipalKey(nameof(Tag.Id)),
                    j => j.HasKey("BooksId", "TagsId")
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LibraryCollectionWebApplication.Models.ViewModels.BookUpdateViewModel> BookUpdateViewModel { get; set; } = default!;
    }
}
