using AutoMapper;
using OnionMessenger.Domains;
using OnionMessenger.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnionMessenger.WebApi.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap< User, UserRegistered > ()
                .ForMember(dest=>dest.Title, opt=>opt.MapFrom<string>(src => "User registered successfully"));
        }
    }
}