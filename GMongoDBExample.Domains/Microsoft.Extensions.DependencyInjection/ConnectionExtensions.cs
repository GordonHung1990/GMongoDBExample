using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMongoDBExample.Domains.ConfigurationSettings.MongoDB;
using GMongoDBExample.Domains.Connections.MongoDB;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConnectionExtensions
    {
        /// <summary>
        /// Adds the mongo database connection.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="mongoDBConfigurationSetting">The mongo database configuration setting.</param>
        /// <returns></returns>
        public static IServiceCollection AddMongoDBConnection(this IServiceCollection services, Action<MongoDBConfigurationSetting, IServiceProvider> mongoDBConfigurationSetting)
        {
            return services
            .AddOptions<MongoDBConfigurationSetting>()
            .Configure(mongoDBConfigurationSetting)
            .Services
            .AddSingleton<IMongoDBConnection, MongoDBConnection>();
        }
    }
}
