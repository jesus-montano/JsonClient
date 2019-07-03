using JsonClient.Attributes;
namespace JsonClient.Entities
{

    public class User : EntityBase
    {
        [Skip]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        [IsClass]
        public Address address { get; set; }
    }
}
