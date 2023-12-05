﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WriteMoreAPI.DAL.Context;

#nullable disable

namespace WriteMoreAPI.Migrations
{
    [DbContext(typeof(WriteMoreContext))]
    [Migration("20231205213544_CreatingMovieTable")]
    partial class CreatingMovieTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WriteMoreAPI.Model.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Author");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int>("Pages")
                        .HasColumnType("int")
                        .HasColumnName("Pages");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Publisher");

                    b.Property<string>("Synopisis")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Synopisis");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Year");

                    b.HasKey("ID");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("WriteMoreAPI.Model.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Cast")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Cast");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Director");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Duration");

                    b.Property<double>("IMDBRating")
                        .HasColumnType("float")
                        .HasColumnName("IMDBRating");

                    b.Property<string>("Synopisis")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Synopisis");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Title");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasColumnName("Year");

                    b.HasKey("ID");

                    b.ToTable("Movie");
                });
#pragma warning restore 612, 618
        }
    }
}
