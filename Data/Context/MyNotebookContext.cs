using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Context
{
    public class MyNotebookContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public string DbPath { get; }
        public MyNotebookContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "customers.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");

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
        }
    }
}
