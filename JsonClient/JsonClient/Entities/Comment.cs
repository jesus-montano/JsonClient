using JsonClient.Attributes;
using System.ComponentModel.DataAnnotations;

namespace JsonClient.Entities
{
    public class Comment : EntityBase
    {
        [Skip]

        public int PostId { get; set; }

        [Skip]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [Display(Name = "User Name")]
        public string UserName{get;set;}

        [Display(Name = "Content")]
        public string Body { get; set; }
    }
}