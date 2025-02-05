using AutoMapper;
using MoodApp.API.DTOs;
using MoodApp.API.Models;

namespace MoodApp.API.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, RegisterDto>().ReverseMap();
            
            CreateMap<MoodEntry, MoodEntryDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.UserName));
            
            CreateMap<CreateMoodEntryDto, MoodEntry>();
            CreateMap<UpdateMoodEntryDto, MoodEntry>();
        }
    }
} 