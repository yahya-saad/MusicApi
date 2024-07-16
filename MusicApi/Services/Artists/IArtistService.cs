namespace MusicApi.Services.Artists
{
    public interface IArtistService
    {
        Task<(IQueryable<object> Data, object PaginationMetadata)> GetArtistsAsync(int page, int limit);
        Task<object> GetArtistByIdAsync(int id);
        Task<Artist> CreateArtistAsync(CreateArtistDto req);
        Task<Artist> UpdateArtistAsync(int id, UpdateArtistDto req);
        Task<bool> DeleteArtistAsync(int id);
    }
}
