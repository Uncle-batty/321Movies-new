using System.ComponentModel.DataAnnotations;

namespace _321MoviesAPI.Modle
{
    public class Subscription_levels
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public double price { get; set; }
        
    }
}
