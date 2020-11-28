using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Generics;
using Games.Services.Dto;

namespace Games.Services
{
    public interface IGameService : IBaseCrudService<GameDto>
    {
    }
}
