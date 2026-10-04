using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Model.Models
{
    public class Fluent_Book
    {
        //[Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        //[MaxLength(20)]
        //[Required]
        public string ISBN { get; set; }
        //[Precision(10, 5)]
        public decimal Price { get; set; }
        //[NotMapped]
        public string PriceRange { get; set; }
        
        public Fluent_BookDetail BookDetail { get; set; }
        //[ForeignKey("Publisher")]
        public int Publisher_Id { get; set; }
        public Fluent_Publisher Publisher { get; set; }
        //public List<Fluent_Author> Authors { get; set; }
        public List<Fluent_BookAuthorMap> BookAuthorMap { get; set; }

    }
}
