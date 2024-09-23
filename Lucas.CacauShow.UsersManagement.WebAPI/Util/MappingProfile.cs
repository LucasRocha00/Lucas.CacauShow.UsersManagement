using AutoMapper;
using Lucas.CacauShow.UsersManagement.Domain;
using Lucas.CacauShow.UsersManagement.Domain.Entities;
using Lucas.CacauShow.UsersManagement.Models.Requests;
using Lucas.CacauShow.UsersManagement.Models.Responses;

namespace Lucas.CacauShow.UsersManagement.WebAPI.Util
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, UserRequest>().ReverseMap();
        }
    }
}
