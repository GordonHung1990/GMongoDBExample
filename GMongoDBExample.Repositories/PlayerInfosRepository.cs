using System;
using System.Linq;
using System.Threading.Tasks;
using GMongoDBExample.Domains.Connections.MongoDB;
using GMongoDBExample.Repositories.Models;
using MongoDB.Driver;

namespace GMongoDBExample.Repositories
{
    internal class PlayerInfosRepository : IPlayerInfosRepository
    {
        private readonly IMongoDBConnection _connection;

        public PlayerInfosRepository(IMongoDBConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public Task AddAsync(PlayerInfos source)
             => _connection.GetMongoCollection<PlayerInfos>().InsertOneAsync(source);
        public Task<DeleteResult> DeleteAsync(Guid playerId)
               => _connection.GetMongoCollection<PlayerInfos>().DeleteOneAsync(a => a.PlayersId == playerId);

        public async Task<UpdateResult> EditNickNameAsync(PlayerInfos source)
        {
            var collection = _connection.GetMongoCollection<PlayerInfos>();
            var filter = Builders<PlayerInfos>.Filter.Eq(a => a.Id, source.Id);

            var update = Builders<PlayerInfos>.Update
                .Set(a => a.NickName, source.NickName);

            return await collection.UpdateOneAsync(filter, update).ConfigureAwait(false);
        }

        public async Task<PlayerInfos> GetAsync(Guid playerId)
        {
            var cursor = await _connection.GetMongoCollection<PlayerInfos>().FindAsync(a => a.PlayersId == playerId).ConfigureAwait(false);
            return cursor.FirstOrDefault();
        }
    }
}
