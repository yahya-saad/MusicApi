using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicApi.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "user")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: true),
                    AlbumId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Songs_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "CreatedAt", "Gender", "ImageUrl", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2712), "Male", "https://example.com/mounir.jpg", "Mohamed Mounir", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2712) },
                    { 2, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2715), "Female", "https://example.com/nancy.jpg", "Nancy Ajram", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2715) },
                    { 3, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2717), "Male", "https://example.com/amr.jpg", "Amr Diab", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2717) },
                    { 4, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2718), "Male", "https://example.com/tamer.jpg", "Tamer Hosny", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2718) },
                    { 5, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2719), "Female", "https://example.com/elissa.jpg", "Elissa", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2719) }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "ArtistId", "CreatedAt", "ImageUrl", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2850), "https://example.com/album1.jpg", "The King", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2850) },
                    { 2, 2, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2851), "https://example.com/album2.jpg", "Super Nancy", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2851) },
                    { 3, 3, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2852), "https://example.com/album3.jpg", "Sahar El Layali", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2852) },
                    { 4, 4, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2854), "https://example.com/album4.jpg", "3esh Besho2ak", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2854) },
                    { 5, 5, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2855), "https://example.com/album5.jpg", "Aghla El Ehsas", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2855) }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "AlbumId", "ArtistId", "CreatedAt", "Duration", "ImageUrl", "IsFeatured", "Language", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2878), "5:12", "https://example.com/song1.jpg", true, "Arabic", "Shababeek", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2878) },
                    { 2, 1, 1, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2881), "4:50", "https://example.com/song2.jpg", false, "Arabic", "Ezay", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2881) },
                    { 3, 2, 2, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2883), "3:40", "https://example.com/song3.jpg", true, "Arabic", "Akhasmak Ah", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2883) },
                    { 4, 2, 2, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2885), "3:20", "https://example.com/song4.jpg", false, "Arabic", "Ya Salam", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2885) },
                    { 5, 3, 3, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2887), "4:30", "https://example.com/song5.jpg", true, "Arabic", "Tamally Maak", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2887) },
                    { 6, 3, 3, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2889), "5:00", "https://example.com/song6.jpg", false, "Arabic", "Nour El Ein", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2889) },
                    { 7, 4, 4, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2891), "3:50", "https://example.com/song7.jpg", true, "Arabic", "Bahebbak Enta", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2891) },
                    { 8, 4, 4, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2921), "4:10", "https://example.com/song8.jpg", false, "Arabic", "Koll Marra", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2921) },
                    { 9, 5, 5, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2922), "4:45", "https://example.com/song9.jpg", true, "Arabic", "Bastanak", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2922) },
                    { 10, 5, 5, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2924), "5:30", "https://example.com/song10.jpg", false, "Arabic", "Halet Hob", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2924) },
                    { 11, 1, 1, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2925), "3:53", "https://example.com/song11.jpg", true, "English", "Shape of You", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2925) },
                    { 12, 1, 1, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2927), "4:23", "https://example.com/song12.jpg", false, "English", "Perfect", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2927) },
                    { 13, 2, 2, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2928), "3:36", "https://example.com/song13.jpg", true, "English", "Havana", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2928) },
                    { 14, 2, 2, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2930), "3:11", "https://example.com/song14.jpg", false, "English", "Senorita", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2930) },
                    { 15, 3, 3, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2932), "3:20", "https://example.com/song15.jpg", true, "English", "Blinding Lights", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2932) },
                    { 16, 3, 3, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2933), "3:35", "https://example.com/song16.jpg", false, "English", "Save Your Tears", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2933) },
                    { 17, 4, 4, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2935), "4:45", "https://example.com/song17.jpg", true, "English", "Someone Like You", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2935) },
                    { 18, 4, 4, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2936), "3:48", "https://example.com/song18.jpg", false, "English", "Rolling in the Deep", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2936) },
                    { 19, 5, 5, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2938), "3:36", "https://example.com/song19.jpg", true, "English", "Shallow", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2938) },
                    { 20, 5, 5, new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2939), "3:30", "https://example.com/song20.jpg", false, "English", "Always Remember Us This Way", new DateTime(2024, 7, 15, 19, 50, 12, 893, DateTimeKind.Utc).AddTicks(2939) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
