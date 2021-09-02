using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GMongoDBExample.Domains.Models.Players
{
    public record PlayersEditNickNameRequest
    {
        /// <summary>
        /// The account
        /// </summary>
        [JsonPropertyName("account")]
        public string Account { get; set; }
        /// <summary>
        /// The nick name
        /// </summary>
        [JsonPropertyName("nickName")]
        public string NickName { get; set; }
    }
}
