namespace MusicApi.Services.Artists
{
    public class ArtistService : IArtistService
    {
        private readonly ApplicationDbContext _context;
        private readonly CloudinaryUtility _cloudinary;
        private readonly PaginationService _paginationService;


        public ArtistService(ApplicationDbContext context, CloudinaryUtility cloudinary, PaginationService paginationService)
        {
            _context = context;
            _cloudinary = cloudinary;
            _paginationService = paginationService;
        }

        public async Task<(IQueryable<object>, object)> GetArtistsAsync(int page, int limit)
        {
            var query = _context.Artists
                .Select(x => new { x.Id, x.Name, x.ImageUrl, x.CreatedAt, x.UpdatedAt });
            Console.WriteLine($"Fetching artists with page: {page}, limit: {limit}");

            return await _paginationService.PaginateAsync(query, page, limit);
        }

        public async Task<object> GetArtistByIdAsync(int id)
        {
            var artist = await _context.Artists
                .Include(a => a.Songs)
                .Where(a => a.Id == id)
                .Select(a => new
                {
                    ArtistId = a.Id,
                    ArtistName = a.Name,
                    ImageUrl = a.ImageUrl,
                    Songs = a.Songs.Select(s => new
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Language = s.Language,
                        Duration = s.Duration,
                        AlbumId = s.AlbumId,
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (artist == null)
                throw new ArgumentException("Artist not found");

            return artist;
        }

        public async Task<Artist> CreateArtistAsync(CreateArtistDto req)
        {
            var newArtist = new Artist()
            {
                Name = req.Name,
                Gender = req.Gender,
            };

            if (req.Image != null)
                newArtist.ImageUrl = await _cloudinary.UploadImageAsync(req.Image, "artists");

            await _context.Artists.AddAsync(newArtist);
            await _context.SaveChangesAsync();

            return newArtist;
        }

        public async Task<Artist> UpdateArtistAsync(int id, UpdateArtistDto req)
        {
            var existingArtist = await _context.Artists.FindAsync(id);
            if (existingArtist == null)
                throw new ArgumentException("Artist not found");

            if (!string.IsNullOrEmpty(req.Name))
                existingArtist.Name = req.Name;

            if (req.Image != null)
                // TODO: remove existing image
                existingArtist.ImageUrl = await _cloudinary.UploadImageAsync(req.Image, "artists");

            await _context.SaveChangesAsync();

            return existingArtist;
        }

        public async Task<bool> DeleteArtistAsync(int id)
        {
            var existingArtist = await _context.Artists.FindAsync(id);
            if (existingArtist == null)
                throw new ArgumentException("Artist not found");

            _context.Artists.Remove(existingArtist);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
