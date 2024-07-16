namespace MusicApi.Services
{
    public class PaginationService
    {
        public async Task<(IQueryable<T> Data, object PaginationMetadata)> PaginateAsync<T>(IQueryable<T> query, int page, int limit)
        {
            int currentPage = Math.Max(page, 1);
            int currentLimit = Math.Max(limit, 1);

            int totalCount = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(totalCount / (double)currentLimit);

            var paginatedData = query.Skip((currentPage - 1) * currentLimit).Take(currentLimit);

            var paginationMetadata = new
            {
                TotalRecords = totalCount,
                CurrentPage = currentPage,
                TotalPages = totalPages,
                NextPage = currentPage < totalPages ? currentPage + 1 : (int?)null,
                PrevPage = currentPage > 1 ? currentPage - 1 : (int?)null
            };

            return (paginatedData, paginationMetadata);
        }
    }
}

