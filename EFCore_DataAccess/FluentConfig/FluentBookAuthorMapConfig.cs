using EFCore_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_DataAccess.FluentConfig
{
    public class FluentBookAuthorMapConfig : IEntityTypeConfiguration<Fluent_BookAuthorMap>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthorMap> modelBuilder)
        {
            modelBuilder.HasKey(u => new { u.Author_Id, u.BookId });
            modelBuilder.HasOne(u => u.Book).WithMany(u => u.BookAuthorMap)
                .HasForeignKey(u => u.BookId);
            modelBuilder.HasOne(u => u.Author).WithMany(u => u.BookAuthorMap)
                .HasForeignKey(u => u.Author_Id);
        }
    }
}
