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

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public int NumberInStock { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }




    }
}