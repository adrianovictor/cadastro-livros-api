﻿// <auto-generated />
using System;
using BookStoreManagerService.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreManagerService.Infrastructure.Migrations
{
    [DbContext(typeof(BookStoreDbContext))]
    [Migration("20241028023632_AddColumnStatusOnTableBook")]
    partial class AddColumnStatusOnTableBook
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStoreManagerService.Domain.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodAu");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCriacao");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Nome");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAtualizacao");

                    b.HasKey("Id");

                    b.ToTable("Autor", (string)null);
                });

            modelBuilder.Entity("BookStoreManagerService.Domain.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Codl");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCriacao");

                    b.Property<int>("Edition")
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("Edicao");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Editora");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Situacao");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Titulo");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAtualizacao");

                    b.Property<string>("YearOfPublication")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AnoPublicacao");

                    b.HasKey("Id");

                    b.ToTable("Livro", (string)null);
                });

            modelBuilder.Entity("BookStoreManagerService.Domain.Model.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodAs");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCriacao");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Descricao");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAtualizacao");

                    b.HasKey("Id");

                    b.ToTable("Assunto", (string)null);
                });

            modelBuilder.Entity("Livro_Assunto", b =>
                {
                    b.Property<int>("Livro_Codl")
                        .HasColumnType("int");

                    b.Property<int>("Assunto_CodAs")
                        .HasColumnType("int");

                    b.HasKey("Livro_Codl", "Assunto_CodAs");

                    b.HasIndex("Assunto_CodAs");

                    b.ToTable("Livro_Assunto", (string)null);
                });

            modelBuilder.Entity("Livro_Autor", b =>
                {
                    b.Property<int>("Livro_Codl")
                        .HasColumnType("int");

                    b.Property<int>("Autor_CodAu")
                        .HasColumnType("int");

                    b.HasKey("Livro_Codl", "Autor_CodAu");

                    b.HasIndex("Autor_CodAu");

                    b.ToTable("Livro_Autor", (string)null);
                });

            modelBuilder.Entity("Livro_Assunto", b =>
                {
                    b.HasOne("BookStoreManagerService.Domain.Model.Subject", null)
                        .WithMany()
                        .HasForeignKey("Assunto_CodAs")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreManagerService.Domain.Model.Book", null)
                        .WithMany()
                        .HasForeignKey("Livro_Codl")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Livro_Autor", b =>
                {
                    b.HasOne("BookStoreManagerService.Domain.Model.Author", null)
                        .WithMany()
                        .HasForeignKey("Autor_CodAu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreManagerService.Domain.Model.Book", null)
                        .WithMany()
                        .HasForeignKey("Livro_Codl")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}