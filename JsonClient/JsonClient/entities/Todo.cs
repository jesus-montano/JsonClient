public class Todo{

    public Todo(){

    }
    public Todo(int UserId, int Id, string Title, bool Completed){
        this.UserId = UserId;
        this.Id = Id;
        this.Title = Title;
        this.Completed = Completed;

    }
    public int UserId;
    public int Id;
    public string Title;
    public bool Completed;
}