using AutoMapper;
using Core.Generics;
using Games.Context;
using Games.Domain;
using Games.Services.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Services
{
    public class GameService : BaseDbContextCrudService<Game, GameDto>, IGameService
    {
        public GameService(GameContext context, IMapper mapper) : base(context,mapper)
        {
        }
    }
}
