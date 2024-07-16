namespace MusicApi.DTOs
{
    public class UpdateSongDto
    {
        public string? Name { get; set; }

        public string? Language { get; set; }

        public string? Duration { get; set; }

        [AllowedExtentions(Constants.AllowedExtensions)]
        [MaxFileSize(Constants.MaxAllowedSizeInBytes)]
        public int? AlbumId { get; set; }
        public int? ArtistId { get; set; }
        public IFormFile? Image { get; set; }
    }
}
