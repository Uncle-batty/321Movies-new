using System.ComponentModel.DataAnnotations;

namespace _321MoviesAPI.Modle
{
    public class Directors
    {
        public int ID { get; set; }
        [Required]
        public string? Fname { get; set; }
        public string? LName { get; set; }
    }
}
