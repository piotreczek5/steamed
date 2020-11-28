using AutoMapper;
using Core.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Context;
using Users.Domain;
using Users.Services.Dto;

namespace Users.Services
{
    public class UserService : BaseDbContextCrudService<User, UserDto>, IUserService
    {
        public UserService(UserContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
