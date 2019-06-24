public class Todo{

    public Todo(){

    }
    public Todo(int userId, int id, string title, bool completed){
        this.userId = userId;
        this.id = id;
        this.title = title;
        this.completed = completed;

    }
    public int userId;
    public int id;
    public string title;
    public bool completed;
}