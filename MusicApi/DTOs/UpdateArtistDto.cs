namespace MusicApi.DTOs
{
    public class UpdateArtistDto
    {
        public string? Name { get; set; }
        [AllowedExtentions(Constants.AllowedExtensions)]
        [MaxFileSize(Constants.MaxAllowedSizeInBytes)]
        public IFormFile? Image { get; set; }
    }
}
