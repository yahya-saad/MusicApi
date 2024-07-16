﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicApi.Data;

#nullable disable

namespace MusicApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240715195013_IntialCreate")]
    partial class IntialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MusicApi.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArtistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArtistId = 1,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2850),
                            ImageUrl = "https://example.com/album1.jpg",
                            Name = "The King",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2850)
                        },
                        new
                        {
                            Id = 2,
                            ArtistId = 2,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2851),
                            ImageUrl = "https://example.com/album2.jpg",
                            Name = "Super Nancy",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2851)
                        },
                        new
                        {
                            Id = 3,
                            ArtistId = 3,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2852),
                            ImageUrl = "https://example.com/album3.jpg",
                            Name = "Sahar El Layali",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2852)
                        },
                        new
                        {
                            Id = 4,
                            ArtistId = 4,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2854),
                            ImageUrl = "https://example.com/album4.jpg",
                            Name = "3esh Besho2ak",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2854)
                        },
                        new
                        {
                            Id = 5,
                            ArtistId = 5,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2855),
                            ImageUrl = "https://example.com/album5.jpg",
                            Name = "Aghla El Ehsas",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2855)
                        });
                });

            modelBuilder.Entity("MusicApi.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2712),
                            Gender = "Male",
                            ImageUrl = "https://example.com/mounir.jpg",
                            Name = "Mohamed Mounir",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2712)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2715),
                            Gender = "Female",
                            ImageUrl = "https://example.com/nancy.jpg",
                            Name = "Nancy Ajram",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2715)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2717),
                            Gender = "Male",
                            ImageUrl = "https://example.com/amr.jpg",
                            Name = "Amr Diab",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2717)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2718),
                            Gender = "Male",
                            ImageUrl = "https://example.com/tamer.jpg",
                            Name = "Tamer Hosny",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2718)
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2719),
                            Gender = "Female",
                            ImageUrl = "https://example.com/elissa.jpg",
                            Name = "Elissa",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2719)
                        });
                });

            modelBuilder.Entity("MusicApi.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int?>("ArtistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlbumId = 1,
                            ArtistId = 1,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2878),
                            Duration = "5:12",
                            ImageUrl = "https://example.com/song1.jpg",
                            IsFeatured = true,
                            Language = "Arabic",
                            Name = "Shababeek",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2878)
                        },
                        new
                        {
                            Id = 2,
                            AlbumId = 1,
                            ArtistId = 1,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2881),
                            Duration = "4:50",
                            ImageUrl = "https://example.com/song2.jpg",
                            IsFeatured = false,
                            Language = "Arabic",
                            Name = "Ezay",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2881)
                        },
                        new
                        {
                            Id = 3,
                            AlbumId = 2,
                            ArtistId = 2,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2883),
                            Duration = "3:40",
                            ImageUrl = "https://example.com/song3.jpg",
                            IsFeatured = true,
                            Language = "Arabic",
                            Name = "Akhasmak Ah",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2883)
                        },
                        new
                        {
                            Id = 4,
                            AlbumId = 2,
                            ArtistId = 2,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2885),
                            Duration = "3:20",
                            ImageUrl = "https://example.com/song4.jpg",
                            IsFeatured = false,
                            Language = "Arabic",
                            Name = "Ya Salam",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2885)
                        },
                        new
                        {
                            Id = 5,
                            AlbumId = 3,
                            ArtistId = 3,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2887),
                            Duration = "4:30",
                            ImageUrl = "https://example.com/song5.jpg",
                            IsFeatured = true,
                            Language = "Arabic",
                            Name = "Tamally Maak",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2887)
                        },
                        new
                        {
                            Id = 6,
                            AlbumId = 3,
                            ArtistId = 3,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2889),
                            Duration = "5:00",
                            ImageUrl = "https://example.com/song6.jpg",
                            IsFeatured = false,
                            Language = "Arabic",
                            Name = "Nour El Ein",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2889)
                        },
                        new
                        {
                            Id = 7,
                            AlbumId = 4,
                            ArtistId = 4,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2891),
                            Duration = "3:50",
                            ImageUrl = "https://example.com/song7.jpg",
                            IsFeatured = true,
                            Language = "Arabic",
                            Name = "Bahebbak Enta",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2891)
                        },
                        new
                        {
                            Id = 8,
                            AlbumId = 4,
                            ArtistId = 4,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2921),
                            Duration = "4:10",
                            ImageUrl = "https://example.com/song8.jpg",
                            IsFeatured = false,
                            Language = "Arabic",
                            Name = "Koll Marra",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2921)
                        },
                        new
                        {
                            Id = 9,
                            AlbumId = 5,
                            ArtistId = 5,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2922),
                            Duration = "4:45",
                            ImageUrl = "https://example.com/song9.jpg",
                            IsFeatured = true,
                            Language = "Arabic",
                            Name = "Bastanak",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2922)
                        },
                        new
                        {
                            Id = 10,
                            AlbumId = 5,
                            ArtistId = 5,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2924),
                            Duration = "5:30",
                            ImageUrl = "https://example.com/song10.jpg",
                            IsFeatured = false,
                            Language = "Arabic",
                            Name = "Halet Hob",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2924)
                        },
                        new
                        {
                            Id = 11,
                            AlbumId = 1,
                            ArtistId = 1,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2925),
                            Duration = "3:53",
                            ImageUrl = "https://example.com/song11.jpg",
                            IsFeatured = true,
                            Language = "English",
                            Name = "Shape of You",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2925)
                        },
                        new
                        {
                            Id = 12,
                            AlbumId = 1,
                            ArtistId = 1,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2927),
                            Duration = "4:23",
                            ImageUrl = "https://example.com/song12.jpg",
                            IsFeatured = false,
                            Language = "English",
                            Name = "Perfect",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2927)
                        },
                        new
                        {
                            Id = 13,
                            AlbumId = 2,
                            ArtistId = 2,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2928),
                            Duration = "3:36",
                            ImageUrl = "https://example.com/song13.jpg",
                            IsFeatured = true,
                            Language = "English",
                            Name = "Havana",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2928)
                        },
                        new
                        {
                            Id = 14,
                            AlbumId = 2,
                            ArtistId = 2,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2930),
                            Duration = "3:11",
                            ImageUrl = "https://example.com/song14.jpg",
                            IsFeatured = false,
                            Language = "English",
                            Name = "Senorita",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2930)
                        },
                        new
                        {
                            Id = 15,
                            AlbumId = 3,
                            ArtistId = 3,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2932),
                            Duration = "3:20",
                            ImageUrl = "https://example.com/song15.jpg",
                            IsFeatured = true,
                            Language = "English",
                            Name = "Blinding Lights",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2932)
                        },
                        new
                        {
                            Id = 16,
                            AlbumId = 3,
                            ArtistId = 3,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2933),
                            Duration = "3:35",
                            ImageUrl = "https://example.com/song16.jpg",
                            IsFeatured = false,
                            Language = "English",
                            Name = "Save Your Tears",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2933)
                        },
                        new
                        {
                            Id = 17,
                            AlbumId = 4,
                            ArtistId = 4,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2935),
                            Duration = "4:45",
                            ImageUrl = "https://example.com/song17.jpg",
                            IsFeatured = true,
                            Language = "English",
                            Name = "Someone Like You",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2935)
                        },
                        new
                        {
                            Id = 18,
                            AlbumId = 4,
                            ArtistId = 4,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2936),
                            Duration = "3:48",
                            ImageUrl = "https://example.com/song18.jpg",
                            IsFeatured = false,
                            Language = "English",
                            Name = "Rolling in the Deep",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2936)
                        },
                        new
                        {
                            Id = 19,
                            AlbumId = 5,
                            ArtistId = 5,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2938),
                            Duration = "3:36",
                            ImageUrl = "https://example.com/song19.jpg",
                            IsFeatured = true,
                            Language = "English",
                            Name = "Shallow",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2938)
                        },
                        new
                        {
                            Id = 20,
                            AlbumId = 5,
                            ArtistId = 5,
                            CreatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2939),
                            Duration = "3:30",
                            ImageUrl = "https://example.com/song20.jpg",
                            IsFeatured = false,
                            Language = "English",
                            Name = "Always Remember Us This Way",
                            UpdatedAt = new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2939)
                        });
                });

            modelBuilder.Entity("MusicApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("user");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MusicApi.Models.Album", b =>
                {
                    b.HasOne("MusicApi.Models.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("MusicApi.Models.Song", b =>
                {
                    b.HasOne("MusicApi.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("MusicApi.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Album");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("MusicApi.Models.Album", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("MusicApi.Models.Artist", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
