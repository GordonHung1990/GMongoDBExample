using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace GMongoDBExample.Domains.Connections.MongoDB
{
    public interface IMongoDBConnection
    {
        MongoClient MongoClient { get; }
        IMongoDatabase GetMongoDB(string dbName);
        IMongoCollection<TDocument> GetMongoCollection<TDocument>(string dbName, string collectionName);
        IMongoCollection<TDocument> GetMongoCollection<TDocument>();
    }
}
