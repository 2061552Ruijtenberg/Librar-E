namespace LibraryCollectionWebApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<BookCollection>? BookCollection { get; set; }
    }
}
