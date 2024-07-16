namespace MusicApi.Models
{
    public class Base
    {
        public Base()
        {
            DateTime now = DateTime.UtcNow;
            CreatedAt = now;
            UpdatedAt = now;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
