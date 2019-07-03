using System.ComponentModel.DataAnnotations;

namespace JsonClient.Entities
{
    public class Geo : EntityBase
    {
        [Display(Name = "Latitude")]
        public decimal Latitude { get; set; }

        [Display(Name = "Longitude")]
        public decimal Longitude { get; set; }
    }
}