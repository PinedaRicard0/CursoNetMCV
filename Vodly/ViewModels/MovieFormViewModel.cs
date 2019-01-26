using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vodly.Models;

namespace Vodly.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> MoviesGenre { get; set; }
    }
}