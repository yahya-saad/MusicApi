namespace MusicApi.Services.Albums
{
    public class AlbumService : IAlbumService
    {
        private readonly ApplicationDbContext _context;
        private readonly CloudinaryUtility _cloudinary;
        private readonly PaginationService _paginationService;

        public AlbumService(ApplicationDbContext context, CloudinaryUtility cloudinary, PaginationService paginationService)
        {
            _context = context;
            _cloudinary = cloudinary;
            _paginationService = paginationService;
        }

        public async Task<(IQueryable<object>, object)> GetAllAlbumsAsync(int page, int limit)
        {
            var query = _context.Albums
                .Select(x => new { x.Id, x.Name, x.ImageUrl, x.CreatedAt, x.UpdatedAt });

            return await _paginationService.PaginateAsync(query, page, limit);
        }

        public async Task<object> GetAlbumByIdAsync(int id)
        {
            var album = await _context.Albums
                .Where(x => x.Id == id)
                .Select(x => new
                {
                    AlbumId = x.Id,
                    AlbumName = x.Name,
                    ArtistId = x.ArtistId,
                    ImageUrl = x.ImageUrl,
                    Songs = x.Songs.Select(s => new
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Language = s.Language,
                        Duration = s.Duration,
                        ArtistId = s.ArtistId,
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return album;
        }

        public async Task<object> CreateAlbumAsync(CreateAlbumDto req)
        {
            if (req.ArtistId.HasValue)
            {
                var artist = await _context.Artists.FindAsync(req.ArtistId);
                if (artist == null)
                    throw new ArgumentException("Artist not found");
            }

            var newAlbum = new Album()
            {
                Name = req.Name,
                ArtistId = req.ArtistId,
            };

            if (req.Image is not null)
                newAlbum.ImageUrl = await _cloudinary.UploadImageAsync(req.Image, "albums");

            await _context.AddAsync(newAlbum);
            await _context.SaveChangesAsync();

            return newAlbum;

        }

        public async Task<object> UpdateAlbumAsync(int id, UpdateAlbumDto req)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album == null)
                throw new ArgumentException("Album not found");

            if (!string.IsNullOrEmpty(req.Name))
                album.Name = req.Name;

            if (req.ArtistId.HasValue)
            {
                var artist = await _context.Artists.FindAsync(req.ArtistId);
                if (artist == null)
                    throw new ArgumentException("Artist not found");

                album.ArtistId = req.ArtistId;
                album.Artist = artist;
            }


            if (req.Image is not null)
            {
                // TODO: remove existing image
                album.ImageUrl = await _cloudinary.UploadImageAsync(req.Image, "albums");
            }

            await _context.SaveChangesAsync();

            album = await _context.Albums
                    .Include(a => a.Artist)
                    .FirstOrDefaultAsync(a => a.Id == id);

            var data = new
            {
                album.Id,
                album.Name,
                album.ImageUrl,
                Artist = album.Artist != null ? new
                {
                    album.Artist.Id,
                    album.Artist.Name,
                    album.Artist.ImageUrl,
                } : null
            };

            return data;
        }
        public async Task<bool> DeleteAlbumAsync(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album == null)
                throw new ArgumentException("Album not found");

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
