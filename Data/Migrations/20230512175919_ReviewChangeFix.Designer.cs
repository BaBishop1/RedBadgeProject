﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapi.webapi.Data;

#nullable disable

namespace webapi.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230512175919_ReviewChangeFix")]
    partial class ReviewChangeFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webapi.Data.Entities.CreatorEntity", b =>
                {
                    b.Property<int>("CreatorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CreatorId"));

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CreatorId");

                    b.ToTable("Creators");
                });

            modelBuilder.Entity("webapi.Data.Entities.GameEntity", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"));

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DateUploaded")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("GameDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GameTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlayerEntityPLayerId")
                        .HasColumnType("int");

                    b.HasKey("GameId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("PlayerEntityPLayerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("webapi.Data.Entities.GenreEntity", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<int?>("GameEntityGameId")
                        .HasColumnType("int");

                    b.Property<string>("GenreDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.HasIndex("GameEntityGameId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("webapi.Data.Entities.LoginEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoginType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logins");

                    b.HasDiscriminator<string>("LoginType").HasValue("LoginEntity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("webapi.Data.Entities.PlayerEntity", b =>
                {
                    b.Property<int>("PLayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PLayerId"));

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PLayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("webapi.Data.Entities.ReviewEntity", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<double>("GameScore")
                        .HasColumnType("float");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewId");

                    b.HasIndex("GameId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("webapi.Data.Entities.AdminEntity", b =>
                {
                    b.HasBaseType("webapi.Data.Entities.LoginEntity");

                    b.HasDiscriminator().HasValue("AdminEntity");
                });

            modelBuilder.Entity("webapi.Data.Entities.UserEntity", b =>
                {
                    b.HasBaseType("webapi.Data.Entities.LoginEntity");

                    b.HasDiscriminator().HasValue("UserEntity");
                });

            modelBuilder.Entity("webapi.Data.Entities.GameEntity", b =>
                {
                    b.HasOne("webapi.Data.Entities.CreatorEntity", "Creator")
                        .WithMany("CreatedGames")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Data.Entities.PlayerEntity", null)
                        .WithMany("FavoriteGames")
                        .HasForeignKey("PlayerEntityPLayerId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("webapi.Data.Entities.GenreEntity", b =>
                {
                    b.HasOne("webapi.Data.Entities.GameEntity", null)
                        .WithMany("Genres")
                        .HasForeignKey("GameEntityGameId");
                });

            modelBuilder.Entity("webapi.Data.Entities.ReviewEntity", b =>
                {
                    b.HasOne("webapi.Data.Entities.GameEntity", "Game")
                        .WithMany("Reviews")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("webapi.Data.Entities.CreatorEntity", b =>
                {
                    b.Navigation("CreatedGames");
                });

            modelBuilder.Entity("webapi.Data.Entities.GameEntity", b =>
                {
                    b.Navigation("Genres");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("webapi.Data.Entities.PlayerEntity", b =>
                {
                    b.Navigation("FavoriteGames");
                });
#pragma warning restore 612, 618
        }
    }
}
