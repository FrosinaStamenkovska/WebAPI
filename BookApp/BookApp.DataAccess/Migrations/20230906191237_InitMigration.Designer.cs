﻿// <auto-generated />
using BookApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookApp.DataAccess.Migrations
{
    [DbContext(typeof(BookAppDbContext))]
    [Migration("20230906191237_InitMigration")]
    partial class InitMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookApp.Domain.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id")
                        .HasName("PrimaryKey_Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "William Shakespeare",
                            Title = "Hamlet"
                        },
                        new
                        {
                            Id = 2,
                            Author = "J. K. Rowling",
                            Title = "Harry Potter"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Leo Tolstoy",
                            Title = "War and Peace"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Paulo Coelho",
                            Title = "The Alchemist"
                        },
                        new
                        {
                            Id = 5,
                            Author = "George R. R. Martin",
                            Title = "Game of Thrones"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Paulo Coelho",
                            Title = "Eleven minutes"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Herbert George Wells",
                            Title = "The War of the Worlds"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
