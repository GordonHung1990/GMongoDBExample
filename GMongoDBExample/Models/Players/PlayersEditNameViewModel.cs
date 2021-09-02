using System.Text.Json.Serialization;

namespace GMongoDBExample.Models.Players
{
    public class PlayersEditNameViewModel
    {
        /// <summary>
        /// The name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; init; }
    }
}
