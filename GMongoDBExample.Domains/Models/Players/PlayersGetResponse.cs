using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GMongoDBExample.Domains.Models.Players
{
    public record PlayersGetResponse
    {
        /// <summary>
        /// The identifier
        /// </summary>
        [JsonPropertyName("playerId")]
        //[BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; init; }

        /// <summary>
        /// The account
        /// </summary>
        [JsonPropertyName("account")]
        public string Account { get; init; }

        /// <summary>
        /// The name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; init; }

        /// <summary>
        /// The nick name
        /// </summary>
        [JsonPropertyName("nickName")]
        public string NickName { get; init; }

        /// <summary>
        /// The creation date
        /// </summary>
        [JsonPropertyName("creationDate")]
        public DateTimeOffset CreationDate { get; init; }

        /// <summary>
        /// The modified date
        /// </summary>
        [JsonPropertyName("modifiedDate")]
        public DateTimeOffset ModifiedDate { get; init; }
    }
}
