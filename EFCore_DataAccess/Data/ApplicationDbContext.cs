using EFCore_DataAccess.FluentConfig;
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
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());
            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());

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
