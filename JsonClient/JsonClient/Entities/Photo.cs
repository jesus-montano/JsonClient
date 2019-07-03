using JsonClient.Attributes;

namespace JsonClient.Entities
{
    public class Photo : EntityBase
    {
        [Skip]
        public int AlbumId { get; set; }

        [Skip]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string ThumbnailUrl { get; set; }
    }
}
