﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyNotebookContext))]
    [Migration("20220130055018_SeedTopicTable")]
    partial class SeedTopicTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Core.Entities.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int?>("TopicId")
                        .HasColumnType("INTEGER");

                    b.HasKey("NoteId");

                    b.HasIndex("TopicId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("Core.Entities.Topic", b =>
                {
                    b.Property<int>("TopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TopicName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.HasKey("TopicId");

                    b.ToTable("Topic");

                    b.HasData(
                        new
                        {
                            TopicId = 1,
                            TopicName = "Math"
                        },
                        new
                        {
                            TopicId = 2,
                            TopicName = "Social Studies"
                        },
                        new
                        {
                            TopicId = 3,
                            TopicName = "Geography"
                        },
                        new
                        {
                            TopicId = 4,
                            TopicName = "English"
                        },
                        new
                        {
                            TopicId = 5,
                            TopicName = "Art"
                        },
                        new
                        {
                            TopicId = 6,
                            TopicName = "Algebra"
                        },
                        new
                        {
                            TopicId = 7,
                            TopicName = "Geometry"
                        },
                        new
                        {
                            TopicId = 8,
                            TopicName = "Health"
                        },
                        new
                        {
                            TopicId = 9,
                            TopicName = "Spanish"
                        },
                        new
                        {
                            TopicId = 10,
                            TopicName = "Speech"
                        },
                        new
                        {
                            TopicId = 11,
                            TopicName = "History"
                        });
                });

            modelBuilder.Entity("Core.Entities.Note", b =>
                {
                    b.HasOne("Core.Entities.Topic", "Topic")
                        .WithMany("Notes")
                        .HasForeignKey("TopicId");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("Core.Entities.Topic", b =>
                {
                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
