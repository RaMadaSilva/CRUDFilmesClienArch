﻿// <auto-generated />
using CadastroFilmes.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CadastroFilmes.Infra.Migrations
{
    [DbContext(typeof(CadastroFilmesDbContext))]
    [Migration("20230818170528_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("CadastroFilmes.Domain.Entities.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DurationsInMinute")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Filme", (string)null);
                });

            modelBuilder.Entity("CadastroFilmes.Domain.Entities.Realizador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Realizador", (string)null);
                });

            modelBuilder.Entity("FilmeRealizador", b =>
                {
                    b.Property<int>("FilmeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RealizadorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FilmeId", "RealizadorId");

                    b.HasIndex("RealizadorId");

                    b.ToTable("FilmeRealizador");
                });

            modelBuilder.Entity("FilmeRealizador", b =>
                {
                    b.HasOne("CadastroFilmes.Domain.Entities.Filme", null)
                        .WithMany()
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CadastroFilmes.Domain.Entities.Realizador", null)
                        .WithMany()
                        .HasForeignKey("RealizadorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
