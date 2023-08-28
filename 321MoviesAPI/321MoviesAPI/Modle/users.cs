using System.ComponentModel.DataAnnotations;

namespace _321MoviesAPI.Modle
{
    public class users
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string user_type { get; set; }
        

    }
}
