public class Album{
    public Album(){

    }

    public Album (int UserId, int Id, string Title){
        this.UserId = UserId;
        this.Id =Id;
        this.Title = Title;
    }
    [Skip]
    public int UserId {get; set;}
    [Skip]
    public int Id {get; set;}
    public string Title {get; set;}
}