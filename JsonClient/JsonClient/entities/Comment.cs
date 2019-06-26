
public class Comment{

    public Comment(){
        
    }
    public Comment (int PostId, int Id, string Name, string Email, string Body){
        this.PostId =PostId;
        this.Id = Id;
        this.Name = Name;
        this.Email =Email;
        this.Body = Body;
    }
    [Skip]
    public int PostId {get; set;}
    [Skip]
    public int Id {get; set;}
            
    public string Name {get; set;}

    public string Email {get; set;}
        
    public string Body {get; set;}
    
}
