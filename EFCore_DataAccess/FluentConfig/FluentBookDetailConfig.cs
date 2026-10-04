using EFCore_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_DataAccess.FluentConfig
{
    public class FluentBookDetailConfig : IEntityTypeConfiguration<Fluent_BookDetail>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
        {
            //name of table
            modelBuilder.ToTable("Fluent_BookDetails");

            //name of column
            modelBuilder.Property(u => u.NumberOfChapters).HasColumnName("NoOfChapters");

            //primary key
            modelBuilder.HasKey(u => u.BookDetail_Id);

            //other validations
            modelBuilder.Property(u => u.NumberOfChapters).IsRequired();

            //relationships
            modelBuilder.HasOne(b => b.Book).WithOne(b => b.BookDetail)
                .HasForeignKey<Fluent_BookDetail>(b => b.BookId);
        }
    }
}
