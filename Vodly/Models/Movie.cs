using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vodly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Required]
        [Display(Name = "Stock Quantity")]
        public int StockQuantity { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
    }
}