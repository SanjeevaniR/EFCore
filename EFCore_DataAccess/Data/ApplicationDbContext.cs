using EFCore_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EFCore_DataAccess.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<Fluent_BookDetail> BookDetails_fluent{ get; set; }
        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EFCoreDB;Trusted_Connection=True;TrustServerCertificate=true;");
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fluent_BookDetail>().ToTable("Fluent_BookDetails");
            modelBuilder.Entity<Fluent_BookDetail>().Property(u => u.NumberOfChapters).HasColumnName("NoOfChapters");
            modelBuilder.Entity<Fluent_BookDetail>().Property(u => u.NumberOfChapters).IsRequired();
            modelBuilder.Entity<Fluent_BookDetail>().HasKey(u => u.BookDetail_Id);
            modelBuilder.Entity<Fluent_BookDetail>().HasOne(b => b.Book).WithOne(b=>b.BookDetail)
                .HasForeignKey<Fluent_BookDetail>(b => b.BookId);

            modelBuilder.Entity<Fluent_Book>().HasKey(u => u.BookId);
            modelBuilder.Entity<Fluent_Book>().Property(u => u.Price).HasPrecision(10, 5);
            modelBuilder.Entity<Fluent_Book>().Property(u => u.ISBN).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Fluent_Book>().Ignore(u => u.PriceRange);
            modelBuilder.Entity<Fluent_Book>().HasOne(u =>u.Publisher).WithMany(u => u.Books)
                .HasForeignKey(u => u.Publisher_Id);

            modelBuilder.Entity<Fluent_Author>().HasKey(u => u.Author_Id);
            modelBuilder.Entity<Fluent_Author>().Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Fluent_Author>().Property(u => u.LastName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Ignore(u => u.FullName);

            modelBuilder.Entity<Fluent_Publisher>().HasKey(u => u.Publisher_Id);
            modelBuilder.Entity<Fluent_Publisher>().Property(u => u.Name).IsRequired();

            modelBuilder.Entity<Fluent_BookAuthorMap>().HasKey(u => new { u.Author_Id, u.BookId});
            modelBuilder.Entity<Fluent_BookAuthorMap>().HasOne(u => u.Book).WithMany(u => u.BookAuthorMap)
                .HasForeignKey(u => u.BookId);
            modelBuilder.Entity<Fluent_BookAuthorMap>().HasOne(u => u.Author).WithMany(u => u.BookAuthorMap)
                .HasForeignKey(u => u.Author_Id);



            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Spider Without Duty", ISBN = "123B12", Price = 10.99m, Publisher_Id = 1 },
                new Book { BookId = 2, Title = "Fortune Of Time", ISBN = "12123B12", Price = 11.99m , Publisher_Id = 1 },
                new Book { BookId = 3, Title = "Fake Sunday", ISBN = "77652", Price = 20.99m, Publisher_Id = 2 },
                new Book { BookId = 4, Title = "Cookie Jar", ISBN = "CC12B12", Price = 25.99m, Publisher_Id = 3 },
                new Book { BookId = 5, Title = "Cloudy Forest", ISBN = "90392B33", Price = 40.99m, Publisher_Id = 3 }
            );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id = 1, Name = "Penguin Random House", Location = "Chicago, USA" },
                new Publisher { Publisher_Id = 2, Name = "HarperCollins", Location = "New York, USA" },
                new Publisher { Publisher_Id = 3, Name = "Simon & Schuster", Location = "Washington, USA" }
            );
        }
    }
} 
