using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryCollectionWebApplication.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string? Description { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public float Price { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public float Worth { get; set; }
        public string Category { get; set; } = null!;
        public virtual ICollection<Tag>? Tags { get; set; }
        public virtual ICollection<BookCollection>? Collections { get; set; }

    }
}
