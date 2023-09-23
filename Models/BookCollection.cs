namespace LibraryCollectionWebApplication.Models
{
    public class BookCollection
    {
        public int Id { get; set; }

        public virtual ICollection<Book>? Books { get; set; }

        public virtual User? User { get; set; } = null!;

        public int? UserId { get; set; }
    }
}
