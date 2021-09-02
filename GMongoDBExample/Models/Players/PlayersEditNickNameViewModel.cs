using System.Text.Json.Serialization;

namespace GMongoDBExample.Models.Players
{
    public record PlayersEditNickNameViewModel
    {
        /// <summary>
        /// The nick name
        /// </summary>
        [JsonPropertyName("nickName")]
        public string NickName { get; init; }
    }
}
