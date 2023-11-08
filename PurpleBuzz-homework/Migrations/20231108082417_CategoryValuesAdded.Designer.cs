﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PurpleBuzz_homework.DAL;

#nullable disable

namespace PurpleBuzz_homework.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231108082417_CategoryValuesAdded")]
    partial class CategoryValuesAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PurpleBuzz_homework.Models.ProjectComponents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProjectComponents");
                });

            modelBuilder.Entity("PurpleBuzz_homework.Models.ProjectRecentWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("projectRecentWorks");
                });

            modelBuilder.Entity("PurpleBuzz_homework.Models.ProjectWorkCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProjectWorkCategories");
                });

            modelBuilder.Entity("PurpleBuzz_homework.Models.ProjectWorkCategoryValues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ValuesId")
                        .HasColumnType("int");

                    b.Property<int>("workCategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("workValuesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("workCategoriesId");

                    b.HasIndex("workValuesId");

                    b.ToTable("CategoryValues");
                });

            modelBuilder.Entity("PurpleBuzz_homework.Models.ProjectWorkValues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProjectWorkValues");
                });

            modelBuilder.Entity("PurpleBuzz_homework.Models.ProjectWorkCategoryValues", b =>
                {
                    b.HasOne("PurpleBuzz_homework.Models.ProjectWorkCategories", "workCategories")
                        .WithMany("CategoryValues")
                        .HasForeignKey("workCategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PurpleBuzz_homework.Models.ProjectWorkValues", "workValues")
                        .WithMany("CategoryValues")
                        .HasForeignKey("workValuesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("workCategories");

                    b.Navigation("workValues");
                });

            modelBuilder.Entity("PurpleBuzz_homework.Models.ProjectWorkCategories", b =>
                {
                    b.Navigation("CategoryValues");
                });

            modelBuilder.Entity("PurpleBuzz_homework.Models.ProjectWorkValues", b =>
                {
                    b.Navigation("CategoryValues");
                });
#pragma warning restore 612, 618
        }
    }
}
