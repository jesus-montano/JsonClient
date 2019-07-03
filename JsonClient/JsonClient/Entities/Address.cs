using JsonClient.Attributes;
using System.ComponentModel.DataAnnotations;

namespace JsonClient.Entities
{
    public class Address : EntityBase
    {
        public string Street { get; set; }

        public string Suite { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }

        [IsClass]
        [Display(Name = "Location")]
        public Geo Geo { get; set; }
    }
}