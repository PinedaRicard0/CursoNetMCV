using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vodly.Dtos;
using Vodly.Models;

namespace Vodly.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRentalDto)
        {
            if (ModelState.IsValid)
            {
                Customer customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);
                DateTime RentedDate =  DateTime.Now;
                foreach (int id in newRentalDto.MovieIds)
                {
                    var movie = _context.Movies.Single(m => m.Id == id);
                    var rental = new Rental
                    {
                        Customer = customer,
                        Movie = movie,
                        DateRented = RentedDate
                    };
                    _context.Rentals.Add(rental);
                }
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
