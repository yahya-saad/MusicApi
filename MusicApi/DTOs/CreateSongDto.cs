namespace MusicApi.DTOs
{
    public class CreateSongDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string Duration { get; set; }
        public string? ArtistId { get; set; }
        public string? AlbumId { get; set; }
        [AllowedExtentions(Constants.AllowedExtensions)]
        [MaxFileSize(Constants.MaxAllowedSizeInBytes)]
        public IFormFile? Image { get; set; }
    }
}
