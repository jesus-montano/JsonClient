using JsonClient.Attributes;

namespace JsonClient.Entities
{
    public class Todo : EntityBase
    {
        [Skip]
        public int UserId { get; set; }

        [Skip]
        public int Id { get; set; }

        public string Title { get; set; }

        public bool Completed { get; set; }
    }
}
