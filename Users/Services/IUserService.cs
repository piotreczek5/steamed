using Core.Generics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Users.Services.Dto;

namespace Users.Services
{
    public interface IUserService : IBaseCrudService <UserDto>
    {   
    }
}
