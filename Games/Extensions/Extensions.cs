using AutoMapper;
using Games.Context;
using Games.Services;
using Games.Services.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Games
{
    public static class Extensions
    {
        public static void AddGamesModule(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<GameContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("Default")));

            serviceCollection.AddScoped<IGameService, GameService>();
            serviceCollection.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
