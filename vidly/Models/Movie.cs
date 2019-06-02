using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class Movie
    { 
        public int Id { get; set; }

        [Required]
        public String  Name { get; set; }


        [Display(Name="Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }


        [Range(1,20)]
        [Display(Name="Number In Stock")]
        [Required]
        public int NumberInStock { get; set; }



        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }


    }
}