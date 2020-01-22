using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace CofeeMug.Infrastructure.Mongo
{
    public static class Extensions
    {
        public static void AddMongoDb(this IServiceCollection serviceCollection, Action<MongoOptions> opt) 
        {
            serviceCollection.Configure<MongoOptions>(opt);
        
            serviceCollection.AddScoped<MongoDB.Driver.IMongoDatabase>(c =>
            {
                var options = c.GetService<IOptions<MongoOptions>>();
                var client = c.GetService<MongoDB.Driver.MongoClient>();

                return client.GetDatabase(options.Value.Database);
            });

            serviceCollection.AddSingleton<MongoDB.Driver.MongoClient>(c =>
            {
                var options = c.GetService<IOptions<MongoOptions>>();
                return new MongoDB.Driver.MongoClient(options.Value.ConnectionString);
            });
        }
    }
}
