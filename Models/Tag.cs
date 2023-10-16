﻿namespace LibraryCollectionWebApplication.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Book>? Books { get; set; }
    }
}
