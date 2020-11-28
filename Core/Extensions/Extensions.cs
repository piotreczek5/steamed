using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Steamed.Core.Infrastructure.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Extensions
{
    public static class Extensions
    {
        public static void AddCoreModule(this IServiceCollection serviceCollection)
        {
            AddAutomapper(serviceCollection);
        }

        private static void AddAutomapper(IServiceCollection serviceCollection)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(s => s.GetTypes())
                            .Where(p => typeof(Profile).IsAssignableFrom(p))
                            .Select(c => c.Assembly)
                            .Where(c => c.FullName.Contains("Steamed."));

            serviceCollection.AddAutoMapper(assemblies);
        }

        public static void UsePortalExceptionHandling(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new ErrorToJsonExceptionHandler().Invoke
            });
        }
    }
}
