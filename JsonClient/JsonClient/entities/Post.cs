public class Post{

    public Post(){

    }
    public Post(int UserId, int Id, string Title, string Body){
        this.UserId =UserId;
        this.Id = Id;
        this.Title =Title;
        this.Body =Body;
    }
    [Skip]
    public int UserId {get; set;}
    [Skip]
    public int Id {get; set;}
    public string Title {get; set;}
    public string Body {get; set;}

}