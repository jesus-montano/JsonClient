public class Address
{
    public string street {get; set;}
    public string suite {get; set;}
    public string city {get; set;}
    public string zipcode {get; set;}
    [IsClass(msg = "this property is a Class")]
    public Geo Geo {get; set;}     
}