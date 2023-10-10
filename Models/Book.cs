﻿using LibraryCollectionWebApplication.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.CodeAnalysis.Options;



namespace LibraryCollectionWebApplication.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string? Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Worth { get; set; }
        public virtual Category Category { get; set; } = null!;
        public int CategoryId { get; set; }
        public virtual User User { get; set; } = null!;
        public int UserId { get; set; }

        public decimal? profit()
        {
            return Worth - Price;
        }

    }
}
