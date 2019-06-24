public class Album{
    public Album(){

    }

    public Album (int userId, int id, string title){

    this.userId = userId;
    this.id =id;
    this.title = title;
    }
    public int userId {get; set;}
    public int id {get; set;}
    public string title {get; set;}
}