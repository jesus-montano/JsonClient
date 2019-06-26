
public class User{
    public User(){}
    User(int Id,string Name,string Username,string Email, Address address){
        this.Id= Id;
        this.Name = Name;
        this.Username =Username;
        this.Email = Email;
        this.address = address;

    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    [IsClass(msg ="this property is a Class")]
    public Address address { get; set; }
}

    
