using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vodly.Dtos
{
    public class MovieDto
    {

        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Required]

        [Range(1, 100, ErrorMessage = "Enter a value between 0 and 100")]
        public int StockQuantity { get; set; }
        public GenreDto Genre { get; set; }
        public int GenreId { get; set; }
    }
}