namespace MusicApi.DTOs
{
    public class CreateArtistDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [AllowedExtentions(Constants.AllowedExtensions)]
        [MaxFileSize(Constants.MaxAllowedSizeInBytes)]
        public IFormFile? Image { get; set; }

    }
}
