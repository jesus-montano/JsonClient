public class User{
    public User(){}
    User(int id,string name,string username,string email, Address address){
        this.id= id;
        this.name = name;
        this.username =username;
        this.email = email;
        this.address = address;

    }
    public int id { get; set; }
    public string name { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public Address address { get; set; }
}