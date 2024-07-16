namespace MusicApi.DTOs
{
    public class CreateAlbumDto
    {
        [Required]
        public string Name { get; set; }
        public int? ArtistId { get; set; }
        [AllowedExtentions(Constants.AllowedExtensions)]
        [MaxFileSize(Constants.MaxAllowedSizeInBytes)]
        public IFormFile? Image { get; set; }

    }
}
