using GMongoDBExample.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceConfigurationExtensions
    {
        /// <summary>
        /// Adds the repositories.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddTransient<IPlayersService, PlayersService>();
        }
    }
}
