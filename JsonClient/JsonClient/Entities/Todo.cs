using JsonClient.Attributes;
namespace JsonClient.Entities
{
    public class Todo : AbstractManageObject
    {
        
        [Skip]
        public int UserId {get; set;}
        
        [Skip]
        public int Id {get; set;}
        
        public string Title {get; set;}
        
        public bool Completed {get; set;}

        public Todo(){ }
        
        public Todo(int UserId, int Id, string Title, bool Completed){
            this.UserId = UserId;
            this.Id = Id;
            this.Title = Title;
            this.Completed = Completed;
        }
    }
}
