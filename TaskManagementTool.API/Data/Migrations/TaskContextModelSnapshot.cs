﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace TaskManagementTool.Api.Data.Migrations
{
    [DbContext(typeof(TaskContext))]
    partial class TaskContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("TaskManagementTool.Api.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Work"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Personal Development"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Health & Fitness"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Social"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Home & Family"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Finance"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Leisure"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Errands"
                        });
                });

            modelBuilder.Entity("TaskManagementTool.Api.Entities.TodoTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDone")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan?>("TimeSpent")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskManagementTool.Api.Entities.TodoTask", b =>
                {
                    b.HasOne("TaskManagementTool.Api.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
