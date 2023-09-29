namespace LibraryCollectionWebApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Book>? Books { get; set; } = null!;
    }
}
