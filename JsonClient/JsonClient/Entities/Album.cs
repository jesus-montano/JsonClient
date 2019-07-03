using JsonClient.Attributes;

namespace JsonClient.Entities
{
    public class Album : EntityBase
    {
        [Skip]
        public int UserId { get; set; }

        [Skip]

        public int Id { get; set; }
        public string Title { get; set; }
    }
}