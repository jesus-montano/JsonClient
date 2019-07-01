using JsonClient.Attributes;

namespace JsonClient.Entities
{
        
    public class Album : AbstractManageObject
    {
        [Skip]
        public int UserId {get; set;}
        
        [Skip]
        
        public int Id {get; set;}
        public string Title {get; set;}
        
        public Album(){ }

        public Album (int UserId, int Id, string Title)
        {
            this.UserId = UserId;
            this.Id =Id;
            this.Title = Title;
        }
        
    }
}