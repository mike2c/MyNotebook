using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Context
{
    public class MyNotebookContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public string DbPath { get; }
        public MyNotebookContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "notes.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlite($"Data Source={DbPath}");
            //options.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .ToTable("Note")
                .HasKey(a => a.NoteId);

            modelBuilder.Entity<Note>()
                .Property(a => a.Body)
                .HasColumnType("text");

            modelBuilder.Entity<Note>()
                .Property(a => a.Title)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired(true);

            modelBuilder.Entity<Note>()
                .Property(a => a.CreatedDate)
                .IsRequired(true);

            modelBuilder.Entity<Note>()
                .Property(a => a.LastModifiedDate)
                .IsRequired(false);

            modelBuilder.Entity<Topic>()
              .ToTable("Topic")
              .HasKey(a => a.TopicId);

            modelBuilder.Entity<Topic>()
                .Property(a => a.TopicName)
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired(true);

            modelBuilder.Entity<Note>()
                .HasOne(a => a.Topic)
                .WithMany(b => b.Notes);

            modelBuilder.Entity<Topic>()
                .HasData(
                    new Topic(1, "Math"),
                    new Topic(2, "Social Studies"),
                    new Topic(3, "Geography"),
                    new Topic(4, "English"),
                    new Topic(5, "Art"),
                    new Topic(6, "Algebra"),
                    new Topic(7, "Geometry"),
                    new Topic(8, "Health"),
                    new Topic(9, "Spanish"),
                    new Topic(10, "Speech"),
                    new Topic(11, "History")                    
                );
        }
    }
}
