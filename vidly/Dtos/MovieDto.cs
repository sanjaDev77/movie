using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.Dtos
{
    public class MovieDto
    {

        public int Id { get; set; }

        [Required]
        public String Name { get; set; }


        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }


        [Range(1, 20)]
        [Required]
        public int NumberInStock { get; set; }

        [Required]
        public int GenreId { get; set; }

        public GenreDto Genre { get; set; }
    }
}