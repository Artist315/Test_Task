using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Extensions
{
    public static class DatabaseExtension
    {
        /// <summary> Add Entity Framework Core DbContext </summary>
        /// <typeparam name="TContext">Child of DbContext</typeparam>
        /// <param name="configuration">According to the class AddDbExtensionOptions</param>
        public static IServiceCollection AddDb<TContext>(this IServiceCollection services, IConfiguration configuration)
                                        where TContext : DbContext
        {
            var configs = configuration.Get<AddDbExtensionOptions>();

            services.AddDbContext<TContext>(options =>
            {
                options.EnableSensitiveDataLogging();

                options.UseNpgsql(configs.PostgresConnectionString);

                options.EnableDetailedErrors();
                options.ConfigureWarnings(b => b.Log((CoreEventId.QueryIterationFailed, LogLevel.Information)));
            });

            var context = services.BuildServiceProvider()
                          .GetRequiredService<TContext>();

            if (configs.AutoDatabaseUpdate)
            {
                if (configs.MigrationsCommandTimeoutInSeconds.HasValue)
                {
                    context.Database.SetCommandTimeout(configs.MigrationsCommandTimeoutInSeconds.Value);
                }

                context.Database.Migrate();

            }

            context.Database.SetCommandTimeout(configs.CommandTimeoutInSec);


            return services;
        }
    }
}
