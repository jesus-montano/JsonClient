using JsonClient.Attributes;
using System.ComponentModel.DataAnnotations;
namespace JsonClient.Entities
{
    public class Comment : AbstractManageObject
    {
        
        [Skip]
        public int PostId {get; set;}
        
        [Skip]
        public int Id {get; set;}
                
        public string Name {get; set;}

        public string Email {get; set;}
            
        [Display (Name = "Content")]
        public string Body {get; set;}

        public Comment(){ }

        public Comment (int PostId, int Id, string Name, string Email, string Body)
        {
            this.PostId =PostId;
            this.Id = Id;
            this.Name = Name;
            this.Email =Email;
            this.Body = Body;
        }     
    }
}