using JsonClient.Attributes;
using System.ComponentModel.DataAnnotations;

namespace JsonClient.Entities
{
    public class Post : EntityBase
    {
        [Skip]
        [Display(Name = "User Name")]
        public int UserId { get; set; }

        [Skip]
        public int Id { get; set; }

        public string Title { get; set; }

        [Display(Name = "Content")]
        public string Body { get; set; }
    }
}