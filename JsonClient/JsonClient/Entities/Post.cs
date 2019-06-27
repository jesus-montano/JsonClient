using JsonClient.Attributes;
using System.ComponentModel.DataAnnotations;
namespace JsonClient.Entities
{
    public class Post
    {
        
        [Skip]
        public int UserId {get; set;}
        
        [Skip]
        public int Id {get; set;}
        
        public string Title {get; set;}

        [Display(Name = "Content")]        
        public string Body {get; set;}

        public Post(){ } 
        
        public Post(int UserId, int Id, string Title, string Body)
        {
            this.UserId =UserId;
            this.Id = Id;
            this.Title =Title;
            this.Body =Body;
        }
        

    }
}