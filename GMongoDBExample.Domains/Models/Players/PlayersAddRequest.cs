using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GMongoDBExample.Domains.Models.Players
{
    public record PlayersAddRequest
    {
        /// <summary>
        /// The account
        /// </summary>
        [JsonPropertyName("account")]
        public string Account { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The nick name
        /// </summary>
        [JsonPropertyName("nickName")]
        public string NickName { get; set; }
    }
}
