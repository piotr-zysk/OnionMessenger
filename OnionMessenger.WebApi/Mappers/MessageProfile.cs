using AutoMapper;
using OnionMessenger.Domains;
using OnionMessenger.Logic.DTO;
using OnionMessenger.WebApi.ViewModels;


namespace OnionMessenger.WebApi.Mappers
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageInput, MessageDTO>().ReverseMap();
            CreateMap<MessageDTO, Message>().ReverseMap();

        }
    }
}