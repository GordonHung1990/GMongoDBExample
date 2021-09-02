using System;
using System.ComponentModel.DataAnnotations.Schema;
using GMongoDBExample.Domains.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GMongoDBExample.Repositories.Models
{
    [DataBase("main")]
    [Table("players")]
    public record Players
    {
        /// <summary>
        /// The identifier
        /// </summary>
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }

        /// <summary>
        /// The account
        /// </summary>
        [BsonElement("account")]
        public string Account { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        [BsonElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// The creation date
        /// </summary>
        [BsonElement("creationDate")]
        public DateTimeOffset CreationDate { get; set; }

        /// <summary>
        /// The modified date
        /// </summary>
        [BsonElement("modifiedDate")]
        public DateTimeOffset ModifiedDate { get; set; }
    }
}
