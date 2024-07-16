
namespace MusicApi.Services.Songs
{
    public interface ISongService
    {
        Task<(IQueryable<object> Data, object PaginationMetadata)> GetPaginatedSongs(int page, int limit);
        Task<object> GetSongById(int id);
        Task<(IQueryable<object> Data, object PaginationMetadata)> GetFeaturedSongs(int page, int limit);
        Task<(IQueryable<object> Data, object PaginationMetadata)> GetLatestSongs(int page, int limit);
        Task<object> CreateSong(CreateSongDto req);
        Task<object> UpdateSong(int id, UpdateSongDto req);
        Task<object> ToggleFeaturedSong(int id);
        Task<bool> DeleteSong(int id);
    }
}
