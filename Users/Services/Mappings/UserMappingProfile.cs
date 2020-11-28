using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Users.Domain;
using Users.Services.Dto;

namespace Users.Services.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>()
               .ForMember(dst => dst.Password, opt => opt.Ignore());

            CreateMap<UserDto, User>();

        }
    }
}
