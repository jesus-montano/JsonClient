using System.ComponentModel.DataAnnotations;
namespace JsonClient.Entities{
    public class Geo
    {

        [Display(Name = "latitude")]
        public decimal lat {get; set;}
        
        [Display(Name = "Longitude")]
        public decimal lng {get; set;}
    }
}