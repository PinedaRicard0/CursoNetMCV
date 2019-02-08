using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Vodly.Dtos;
using Vodly.Models;

namespace Vodly.Controllers.Api
{
    public class MoviesController : ApiController
    {

        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        public IHttpActionResult GetMovie(int MovieId)
        {
            Movie MovieInDb = _context.Movies.SingleOrDefault(m => m.Id == MovieId);
            if (MovieInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(MovieInDb));
        }
    }
}
