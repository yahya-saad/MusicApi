namespace MusicApi.Services.Songs
{
    public class SongService : ISongService
    {
        private readonly ApplicationDbContext _context;
        private readonly CloudinaryUtility _cloudinary;
        private readonly PaginationService _paginationService;

        public SongService(ApplicationDbContext context, CloudinaryUtility cloudinary, PaginationService paginationService)
        {
            _context = context;
            _cloudinary = cloudinary;
            _paginationService = paginationService;
        }

        public async Task<(IQueryable<object>, object)> GetPaginatedSongs(int page, int limit)
        {
            var query = _context.Songs
                .Select(s => new
                {
                    SongId = s.Id,
                    SongName = s.Name,
                    Language = s.Language,
                    Duration = s.Duration,
                    Album = s.Album != null ? new
                    {
                        Id = s.Album.Id,
                        Name = s.Album.Name,
                        ImageUrl = s.Album.ImageUrl
                    } : null,
                    Artist = s.Artist != null ? new
                    {
                        Id = s.Artist.Id,
                        Name = s.Artist.Name,
                        ImageUrl = s.Artist.ImageUrl
                    } : null,
                });

            return await _paginationService.PaginateAsync(query, page, limit);
        }

        public async Task<object> GetSongById(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            return song;
        }

        public async Task<(IQueryable<object>, object)> GetFeaturedSongs(int page, int limit)
        {
            var query = _context.Songs.Where(s => s.IsFeatured)
                .Select(s => new { s.Id, s.Name, s.Language, s.Duration, s.ImageUrl });

            return await _paginationService.PaginateAsync(query, page, limit);
        }

        public async Task<(IQueryable<object>, object)> GetLatestSongs(int page, int limit)
        {
            var query = _context.Songs
                .OrderByDescending(s => s.CreatedAt)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.Language,
                    s.Duration,
                    s.ImageUrl
                });

            return await _paginationService.PaginateAsync(query, page, limit);
        }

        public async Task<object> CreateSong(CreateSongDto req)
        {
            var newSong = new Song
            {
                Name = req.Name,
                Language = req.Language,
                Duration = req.Duration,
            };

            if (!string.IsNullOrEmpty(req.ArtistId) && int.TryParse(req.ArtistId, out int artistId))
            {
                var artist = await _context.Artists.FindAsync(artistId);
                if (artist != null)
                    newSong.ArtistId = artistId;
            }

            if (!string.IsNullOrEmpty(req.AlbumId) && int.TryParse(req.AlbumId, out int albumId))
            {
                var album = await _context.Albums.FindAsync(albumId);
                if (album != null)
                    newSong.AlbumId = albumId;
            }

            if (req.Image != null)
                newSong.ImageUrl = await _cloudinary.UploadImageAsync(req.Image, "songs");

            await _context.Songs.AddAsync(newSong);
            await _context.SaveChangesAsync();
            return newSong;
        }

        public async Task<object> UpdateSong(int id, UpdateSongDto req)
        {
            var existingSong = await _context.Songs.FindAsync(id);
            if (existingSong == null)
                return null;

            if (!string.IsNullOrEmpty(req.Name))
                existingSong.Name = req.Name;

            if (!string.IsNullOrEmpty(req.Language))
                existingSong.Language = req.Language;

            if (!string.IsNullOrEmpty(req.Duration))
                existingSong.Duration = req.Duration;

            if (req.AlbumId.HasValue)
            {
                var album = await _context.Albums.FindAsync(req.AlbumId);
                if (album == null)
                    throw new ArgumentException("Album not found");

                existingSong.AlbumId = req.AlbumId;
            }

            if (req.ArtistId.HasValue)
            {
                var album = await _context.Albums.FindAsync(req.ArtistId);
                if (album == null)
                    throw new ArgumentException("Artist not found");

                existingSong.ArtistId = req.ArtistId;
            }

            if (req.Image != null)
                // TODO: remove existing image
                existingSong.ImageUrl = await _cloudinary.UploadImageAsync(req.Image, "songs");

            await _context.SaveChangesAsync();
            return existingSong;
        }

        public async Task<object> ToggleFeaturedSong(int id)
        {
            var existingSong = await _context.Songs.FindAsync(id);
            if (existingSong == null)
                return null;

            existingSong.IsFeatured = !existingSong.IsFeatured;
            await _context.SaveChangesAsync();
            return existingSong;
        }

        public async Task<bool> DeleteSong(int id)
        {
            var existingSong = await _context.Songs.FindAsync(id);
            if (existingSong == null)
                return false;

            _context.Songs.Remove(existingSong);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
