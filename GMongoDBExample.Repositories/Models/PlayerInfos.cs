using System;
using System.ComponentModel.DataAnnotations.Schema;
using GMongoDBExample.Domains.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GMongoDBExample.Repositories.Models
{
    [DataBase("main")]
    [Table("playerInfos")]
    public record PlayerInfos
    {
        /// <summary>
        /// The identifier
        /// </summary>
        [BsonId]
       //[BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }
        /// <summary>
        /// The players identifier
        /// </summary>
        [BsonElement("playersId")]
        public Guid PlayersId { get; set; }
        /// <summary>
        /// The nick name
        /// </summary>
        [BsonElement("nickName")]
        public string NickName { get; set; }
    }
}
