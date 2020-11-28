using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Steamed.Comments.Domain;
using Steamed.Comments.Infrastructure;
using Steamed.Comments.Infrastructure.Exceptions;
using Steamed.Comments.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steamed.Comments.Extensions
{
    public static class Extensions
    {
        public static void AddCommentsModule(this IServiceCollection serviceCollection, IConfiguration configuration)
        {            
            var mongoConnectionSection = configuration.GetSection(nameof(MongoConnection)).Get<MongoConnection>();

            if(mongoConnectionSection == null)
            {
                throw new SettingsNotConfiguredException($"Configuration for {nameof(MongoConnection)} has not been configured.");
            }

            var client = new MongoClient(mongoConnectionSection.ConnectionString);
            var database = client.GetDatabase(mongoConnectionSection.DatabaseName);
            var commentsCollection = database.GetCollection<Comment>(nameof(Comment));

            serviceCollection.AddSingleton<IMongoCollection<Comment>>(commentsCollection);
            serviceCollection.AddScoped<ICommentService,CommentService>();

        }
    }
}
