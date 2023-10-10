using System.ComponentModel.DataAnnotations;

namespace LibraryCollectionWebApplication.Models.ViewModels
{
    public class BookUpdateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string? Description { get; set; }
        [DataType(DataType.Currency)]
        public string? Price { get; set; }
        [DataType(DataType.Currency)]
        public string? Worth { get; set; }
        public virtual Category Category { get; set; } = null!;
        public int CategoryId {  get; set; }
        public virtual User User { get; set; } = null!;
        public int UserId { get; set; }
    }
}
