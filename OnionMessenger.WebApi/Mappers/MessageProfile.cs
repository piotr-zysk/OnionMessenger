using AutoMapper;
using OnionMessenger.Domains;
using OnionMessenger.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnionMessenger.WebApi.Mappers
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageInput, Message>().ReverseMap();
                
        }
    }
}