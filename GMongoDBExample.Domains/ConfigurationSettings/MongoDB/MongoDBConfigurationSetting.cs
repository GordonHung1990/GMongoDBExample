using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMongoDBExample.Domains.ConfigurationSettings.MongoDB
{
    public record MongoDBConfigurationSetting
    {
        /// <summary>
        /// The URL
        /// </summary>
        public string Url { get; init; }
        /// <summary>
        /// The port
        /// </summary>
        public string Port { get; init; }
        /// <summary>
        /// The user
        /// </summary>
        public string User { get; init; }
        /// <summary>
        /// The password
        /// </summary>
        public string Password { get; init; }
    }
}
