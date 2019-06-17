
public class Comment{

    public Comment(){
        
    }
    public Comment (string name, string email, string body){
        this.name = name;
        this.email =email;
        this.body = body;
    }
    public int postId {get; set;}
    public int id {get; set;}
            
    public string name {get; set;}

    public string email {get; set;}
        
    public string body {get; set;}
    
}
