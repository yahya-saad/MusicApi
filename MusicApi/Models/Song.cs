using System.Text.Json.Serialization;

namespace MusicApi.Models
{
    public class Song : Base
    {
        public string Language { get; set; }
        public string Duration { get; set; }
        public bool IsFeatured { get; set; }

        public int? ArtistId { get; set; }
        [JsonIgnore]
        public Artist Artist { get; set; }

        public int? AlbumId { get; set; }
        [JsonIgnore]
        public Album Album { get; set; }
    }
}
