using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Core.Generics;
using Games.Context;
using Games.Domain;
using Games.Services.Dto;
using Microsoft.EntityFrameworkCore;

namespace Games.Services
{
    public class CategoryService : BaseDbContextCrudService<Category, CategoryDto>, ICategoryService
    {
        public CategoryService(GameContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
