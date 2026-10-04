using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCore_Model.Models
{
    //[PrimaryKey(nameof(BookId), nameof(Author_Id))]
    public class Fluent_BookAuthorMap
    {
        //[ForeignKey("Book")]
        public int BookId { get; set; }
        //[ForeignKey("Author")]
        public int Author_Id { get; set; }
        public Fluent_Book Book { get; set; }
        public Fluent_Author Author { get; set; }
    }
}
