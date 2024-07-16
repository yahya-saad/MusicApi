namespace MusicApi.Data
{
    public static class DataSeeder
    {
        public static void SeedArtists(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData(
                new Artist { Id = 1, Name = "Mohamed Mounir", Gender = "Male", ImageUrl = "https://example.com/mounir.jpg" },
                new Artist { Id = 2, Name = "Nancy Ajram", Gender = "Female", ImageUrl = "https://example.com/nancy.jpg" },
                new Artist { Id = 3, Name = "Amr Diab", Gender = "Male", ImageUrl = "https://example.com/amr.jpg" },
                new Artist { Id = 4, Name = "Tamer Hosny", Gender = "Male", ImageUrl = "https://example.com/tamer.jpg" },
                new Artist { Id = 5, Name = "Elissa", Gender = "Female", ImageUrl = "https://example.com/elissa.jpg" }
            );
        }

        public static void SeedAlbums(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().HasData(
                new Album { Id = 1, Name = "The King", ArtistId = 1, ImageUrl = "https://example.com/album1.jpg" },
                new Album { Id = 2, Name = "Super Nancy", ArtistId = 2, ImageUrl = "https://example.com/album2.jpg" },
                new Album { Id = 3, Name = "Sahar El Layali", ArtistId = 3, ImageUrl = "https://example.com/album3.jpg" },
                new Album { Id = 4, Name = "3esh Besho2ak", ArtistId = 4, ImageUrl = "https://example.com/album4.jpg" },
                new Album { Id = 5, Name = "Aghla El Ehsas", ArtistId = 5, ImageUrl = "https://example.com/album5.jpg" }
            );
        }

        public static void SeedSongs(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasData(
                new Song { Id = 1, Name = "Shababeek", Language = "Arabic", Duration = "5:12", IsFeatured = true, ArtistId = 1, AlbumId = 1, ImageUrl = "https://example.com/song1.jpg" },
                new Song { Id = 2, Name = "Ezay", Language = "Arabic", Duration = "4:50", IsFeatured = false, ArtistId = 1, AlbumId = 1, ImageUrl = "https://example.com/song2.jpg" },
                new Song { Id = 3, Name = "Akhasmak Ah", Language = "Arabic", Duration = "3:40", IsFeatured = true, ArtistId = 2, AlbumId = 2, ImageUrl = "https://example.com/song3.jpg" },
                new Song { Id = 4, Name = "Ya Salam", Language = "Arabic", Duration = "3:20", IsFeatured = false, ArtistId = 2, AlbumId = 2, ImageUrl = "https://example.com/song4.jpg" },
                new Song { Id = 5, Name = "Tamally Maak", Language = "Arabic", Duration = "4:30", IsFeatured = true, ArtistId = 3, AlbumId = 3, ImageUrl = "https://example.com/song5.jpg" },
                new Song { Id = 6, Name = "Nour El Ein", Language = "Arabic", Duration = "5:00", IsFeatured = false, ArtistId = 3, AlbumId = 3, ImageUrl = "https://example.com/song6.jpg" },
                new Song { Id = 7, Name = "Bahebbak Enta", Language = "Arabic", Duration = "3:50", IsFeatured = true, ArtistId = 4, AlbumId = 4, ImageUrl = "https://example.com/song7.jpg" },
                new Song { Id = 8, Name = "Koll Marra", Language = "Arabic", Duration = "4:10", IsFeatured = false, ArtistId = 4, AlbumId = 4, ImageUrl = "https://example.com/song8.jpg" },
                new Song { Id = 9, Name = "Bastanak", Language = "Arabic", Duration = "4:45", IsFeatured = true, ArtistId = 5, AlbumId = 5, ImageUrl = "https://example.com/song9.jpg" },
                new Song { Id = 10, Name = "Halet Hob", Language = "Arabic", Duration = "5:30", IsFeatured = false, ArtistId = 5, AlbumId = 5, ImageUrl = "https://example.com/song10.jpg" },
                new Song { Id = 11, Name = "Shape of You", Language = "English", Duration = "3:53", IsFeatured = true, ArtistId = 1, AlbumId = 1, ImageUrl = "https://example.com/song11.jpg" },
                new Song { Id = 12, Name = "Perfect", Language = "English", Duration = "4:23", IsFeatured = false, ArtistId = 1, AlbumId = 1, ImageUrl = "https://example.com/song12.jpg" },
                new Song { Id = 13, Name = "Havana", Language = "English", Duration = "3:36", IsFeatured = true, ArtistId = 2, AlbumId = 2, ImageUrl = "https://example.com/song13.jpg" },
                new Song { Id = 14, Name = "Senorita", Language = "English", Duration = "3:11", IsFeatured = false, ArtistId = 2, AlbumId = 2, ImageUrl = "https://example.com/song14.jpg" },
                new Song { Id = 15, Name = "Blinding Lights", Language = "English", Duration = "3:20", IsFeatured = true, ArtistId = 3, AlbumId = 3, ImageUrl = "https://example.com/song15.jpg" },
                new Song { Id = 16, Name = "Save Your Tears", Language = "English", Duration = "3:35", IsFeatured = false, ArtistId = 3, AlbumId = 3, ImageUrl = "https://example.com/song16.jpg" },
                new Song { Id = 17, Name = "Someone Like You", Language = "English", Duration = "4:45", IsFeatured = true, ArtistId = 4, AlbumId = 4, ImageUrl = "https://example.com/song17.jpg" },
                new Song { Id = 18, Name = "Rolling in the Deep", Language = "English", Duration = "3:48", IsFeatured = false, ArtistId = 4, AlbumId = 4, ImageUrl = "https://example.com/song18.jpg" },
                new Song { Id = 19, Name = "Shallow", Language = "English", Duration = "3:36", IsFeatured = true, ArtistId = 5, AlbumId = 5, ImageUrl = "https://example.com/song19.jpg" },
                new Song { Id = 20, Name = "Always Remember Us This Way", Language = "English", Duration = "3:30", IsFeatured = false, ArtistId = 5, AlbumId = 5, ImageUrl = "https://example.com/song20.jpg" }
            );
        }
    }

}


