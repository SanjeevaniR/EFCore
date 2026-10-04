using EFCore_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_DataAccess.FluentConfig
{
    public class FluentAuthorConfig : IEntityTypeConfiguration<Fluent_Author>
    {
        public void Configure(EntityTypeBuilder<Fluent_Author> modelBuilder)
        {
            modelBuilder.HasKey(u => u.Author_Id);
            modelBuilder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Property(u => u.LastName).IsRequired();
            modelBuilder.Ignore(u => u.FullName);
        }
    }
}
