using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace _321MoviesAPI.Modle
{
    public class Movies
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string runtime { get; set; }
        public string releaseyear { get; set; }
        public string trailerlink { get; set; }
        public string image { get; set; }
        public int agerateing { get; set; }
        public double rateing { get; set; }
        public int views { get; set; }
        public int directorID { get; set; }
        public int catagoryID { get; set; }


    }
}
