public class Album{
    public Album(){

    }

    public Album (int UserId, int Id, string Title){

    this.UserId = UserId;
    this.Id =Id;
    this.Title = Title;
    }
    public int UserId {get; set;}
    public int Id {get; set;}
    public string Title {get; set;}
}