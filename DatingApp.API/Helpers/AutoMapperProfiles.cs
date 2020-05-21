using System.Linq;
using AutoMapper;
using DatingApp.API.DTOs;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDTO>().ForMember(a => a.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(a => a.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<User, UserForDetailedDTO>().ForMember(a => a.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(a => a.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoForDetailedDTO>();
            CreateMap<UserForUpdateDTO, User>();
            CreateMap<Photo, PhotoForReturnDTO>();
            CreateMap<PhotoForCreationDTO, Photo>();
        }
    }
}