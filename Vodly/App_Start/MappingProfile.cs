using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vodly.Dtos;
using Vodly.Models;

namespace Vodly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MemberShipType, MemberShipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>().
                ForMember(m => m.Id, opt => opt.Ignore()); ;

           
                
        }
    }
}