namespace MusicApi.Services.Albums
{
    public interface IAlbumService
    {
        Task<(IQueryable<object> Data, object PaginationMetadata)> GetAllAlbumsAsync(int page, int limit);
        Task<object> GetAlbumByIdAsync(int id);
        Task<object> CreateAlbumAsync(CreateAlbumDto req);
        Task<object> UpdateAlbumAsync(int id, UpdateAlbumDto req);
        Task<bool> DeleteAlbumAsync(int id);
    }
}
