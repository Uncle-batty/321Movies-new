using System.ComponentModel.DataAnnotations;

namespace _321MoviesAPI.Modles
{
    public class Catagory
    {
        public int ID { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]

        public string? Discription { get; set; }
    }
}
