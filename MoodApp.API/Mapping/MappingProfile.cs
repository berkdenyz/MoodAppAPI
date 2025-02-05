using AutoMapper;
using MoodApp.API.DTOs;
using MoodApp.DAL.Entities;

namespace MoodApp.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDto, AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateProfileDto, AppUser>();
            CreateMap<AppUser, ProfileResponseDto>();

            CreateMap<MoodEntry, MoodEntryDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.UserName));
            CreateMap<CreateMoodEntryDto, MoodEntry>();
            CreateMap<UpdateMoodEntryDto, MoodEntry>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
} 