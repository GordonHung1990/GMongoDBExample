using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMongoDBExample.Domains.Attributes;
using GMongoDBExample.Domains.ConfigurationSettings.MongoDB;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GMongoDBExample.Domains.Connections.MongoDB
{
    internal sealed class MongoDBConnection : IMongoDBConnection
    {
        private readonly MongoDBConfigurationSetting _setting;
        private readonly MongoClient _client;

        public MongoDBConnection(IOptions<MongoDBConfigurationSetting> setting)
        {
            _setting = setting.Value;
            var connString = $"mongodb://{_setting.User}:{_setting.Password}@{_setting.Url}:{_setting.Port}";
            _client = new MongoClient(connString);
        }

        MongoClient IMongoDBConnection.MongoClient => _client;

        IMongoDatabase IMongoDBConnection.GetMongoDB(string dbName)
           => _client.GetDatabase(dbName);

        IMongoCollection<TDocument> IMongoDBConnection.GetMongoCollection<TDocument>(string dbName, string collectionName)
           => _client.GetDatabase(dbName).GetCollection<TDocument>(collectionName);
        IMongoCollection<TDocument> IMongoDBConnection.GetMongoCollection<TDocument>()
            => _client
            .GetDatabase((typeof(TDocument).GetCustomAttributes(typeof(DataBaseAttribute), false).FirstOrDefault() as DataBaseAttribute).Name)
            .GetCollection<TDocument>((typeof(TDocument).GetCustomAttributes(typeof(TableAttribute), false).FirstOrDefault() as TableAttribute).Name);
    }
}
