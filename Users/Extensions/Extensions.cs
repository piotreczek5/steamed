using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Users.Context;
using Users.Services;
using Users.Services.Mappings;

namespace Users.Extensions
{
    public static class Extensions
    {
        public static void AddUsersModule(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<UserContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("Default")));

            serviceCollection.AddScoped<IUserService, UserService>();
        }
    }
}
