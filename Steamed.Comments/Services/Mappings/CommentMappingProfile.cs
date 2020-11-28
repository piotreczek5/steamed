using AutoMapper;
using Steamed.Comments.Domain;
using Steamed.Comments.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steamed.Comments.Services.Mappings
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<CommentDto, Comment>().ReverseMap();
        }
    }
}
