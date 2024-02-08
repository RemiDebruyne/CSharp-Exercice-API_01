using AutoMapper;
using Exercice_API_01.DTOs;
using Exercice_API_01.Models;

namespace Exercice_API_01.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Contact, ContactDTO>().ReverseMap();
        }
    }
}
