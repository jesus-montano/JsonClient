public class Address
{
    public string street {get; set;}
    public string suite {get; set;}
    public string city {get; set;}
    public string zipcode {get; set;}
    [IsClass]
    public Geo Geo {get; set;}     
}