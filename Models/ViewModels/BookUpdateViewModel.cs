using LibraryCollectionWebApplication.Data;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
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
        public virtual Category? Category { get; set; }
        public int CategoryId {  get; set; }
        public virtual ICollection<AssignedTagData>? Tags { get; set; }


    }
}
