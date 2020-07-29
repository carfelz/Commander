using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    public class CommandProfiles : Profile
    {
        public CommandProfiles()
        {
            CreateMap<Command, ReadDtos>();
            CreateMap<CreateDto, Command>();
            CreateMap<UpdateDto, Command>();
        }
    }
}
