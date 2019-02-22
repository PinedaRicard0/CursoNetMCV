using AutoMapper;
using System;
using System.Data.Entity;
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

        public IHttpActionResult GetMovies()
        {
            var moviesDto =  _context.Movies
                .Include(g => g.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return Ok(moviesDto);
        }

        public IHttpActionResult GetMovie(int id)
        {
            Movie MovieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (MovieInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(MovieInDb));
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Authorize(Roles = RoleName.CanManageMovies)]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var MovieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (MovieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, MovieInDb);
            _context.SaveChanges();
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Authorize(Roles = RoleName.CanManageMovies)]
        public void DeleteCustomer(int id)
        {
            var MovieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (MovieInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(MovieInDB);
            _context.SaveChanges();
        }

    }
}
