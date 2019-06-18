public class Todo{

    public Todo(){

    }
    public Todo(int userId, string title, bool completed){
        this.userId = userId;
        this.title = title;
        this.completed = completed;

    }
    public int userId;
    public int id;
    public string title;
    public bool completed;
}