﻿// <auto-generated />
using System;
using AutoGlass.API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoGlass.API.Migrations
{
    [DbContext(typeof(AutoGlassContext))]
    [Migration("20240116205609_BancoInicial")]
    partial class BancoInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoGlass.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CNPJFornecedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DataFabricacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DataValidade")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescricaoFornecedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdFornecedor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}
