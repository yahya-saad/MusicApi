namespace MusicApi.Models
{
    public class Artist : Base
    {
        public string Gender { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
