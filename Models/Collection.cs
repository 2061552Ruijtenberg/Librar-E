namespace LibraryCollectionWebApplication.Models
{
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual User? User { get; set; }
        public int UserID { get; set; }
        public virtual Book? Book { get; set; }
        public int BookID { get; set; }
    }
}
