using System.Text.Json.Serialization;

namespace MusicApi.Models
{
    public class Album : Base
    {
        public int? ArtistId { get; set; }
        [JsonIgnore]
        public Artist Artist { get; set; }
        public ICollection<Song> Songs { get; set; }

    }
}
