using EFCore_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_DataAccess.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            modelBuilder.HasKey(u => u.BookId);
            modelBuilder.Property(u => u.Price).HasPrecision(10, 5);
            modelBuilder.Property(u => u.ISBN).IsRequired().HasMaxLength(20);
            modelBuilder.Ignore(u => u.PriceRange);
            modelBuilder.HasOne(u => u.Publisher).WithMany(u => u.Books)
                .HasForeignKey(u => u.Publisher_Id);
        }
    }
}
