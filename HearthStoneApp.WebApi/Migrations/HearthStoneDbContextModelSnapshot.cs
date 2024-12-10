﻿// <auto-generated />
using System;
using HearthStoneApp.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HearthStoneApp.WebApi.Migrations
{
    [DbContext(typeof(HearthStoneDbContext))]
    partial class HearthStoneDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HearthStoneApp.Domain.Entities.Artist", b =>
                {
                    b.Property<long>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ArtistId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("HearthStoneApp.Domain.Entities.Card", b =>
                {
                    b.Property<long>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CardId"));

                    b.Property<long?>("ArtistId")
                        .HasColumnType("bigint");

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<long?>("CardSetId")
                        .HasColumnType("bigint");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Flavor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PlayerClassId")
                        .HasColumnType("bigint");

                    b.Property<long?>("RarityId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardId");

                    b.HasIndex("ArtistId");

                    b.HasIndex("CardSetId");

                    b.HasIndex("PlayerClassId");

                    b.HasIndex("RarityId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("HearthStoneApp.Domain.Entities.CardSet", b =>
                {
                    b.Property<long>("CardSetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CardSetId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardSetId");

                    b.ToTable("CardSet");
                });

            modelBuilder.Entity("HearthStoneApp.Domain.Entities.PlayerClass", b =>
                {
                    b.Property<long>("PlayerClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PlayerClassId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerClassId");

                    b.ToTable("PlayerClass");
                });

            modelBuilder.Entity("HearthStoneApp.Domain.Entities.Rarity", b =>
                {
                    b.Property<long>("RarityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("RarityId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RarityId");

                    b.ToTable("Rarity");
                });

            modelBuilder.Entity("HearthStoneApp.Domain.Entities.Card", b =>
                {
                    b.HasOne("HearthStoneApp.Domain.Entities.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId");

                    b.HasOne("HearthStoneApp.Domain.Entities.CardSet", "CardSet")
                        .WithMany()
                        .HasForeignKey("CardSetId");

                    b.HasOne("HearthStoneApp.Domain.Entities.PlayerClass", "PlayerClass")
                        .WithMany()
                        .HasForeignKey("PlayerClassId");

                    b.HasOne("HearthStoneApp.Domain.Entities.Rarity", "Rarity")
                        .WithMany()
                        .HasForeignKey("RarityId");

                    b.Navigation("Artist");

                    b.Navigation("CardSet");

                    b.Navigation("PlayerClass");

                    b.Navigation("Rarity");
                });
#pragma warning restore 612, 618
        }
    }
}
