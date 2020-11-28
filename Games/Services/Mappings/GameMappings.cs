using AutoMapper;
using Core.Infrastructure;
using Games.Domain;
using Games.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Services.Mappings
{
    public class GameMappinngProfile : Profile
    {
        public GameMappinngProfile()
        {
            CreateMap<Game, GameDto>();

            CreateMap<GameDto, Game>()
                .ForMember(dst => dst.GameCategories, opt => opt.Ignore());
            
            CreateMap<GameCategory, GameCategoryDto>();

            CreateMap<GameCategoryDto, GameCategory>()
                .ForMember(dst => dst.Category, opt => opt.Ignore())
                .ForMember(dst => dst.Game, opt => opt.Ignore());

            CreateMap<Category, CategoryDto>()
                .ReverseMap();

        }
    }
}
