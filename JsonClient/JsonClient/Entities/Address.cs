using JsonClient.Attributes;
using System.ComponentModel.DataAnnotations;
namespace JsonClient.Entities
{
    public class Address
    {
        public string street {get; set;}

        public string suite {get; set;}

        public string city {get; set;}

        public string zipcode {get; set;}

        [IsClass]
        [Display(Name = "Location")]
        public Geo Geo {get; set;}     
    }
}