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

        async ValueTask IPlayerInfosRepository.AddAsync(PlayerInfos source)
             => await _connection.GetMongoCollection<PlayerInfos>().InsertOneAsync(source).ConfigureAwait(false);
        async ValueTask<DeleteResult> IPlayerInfosRepository.DeleteAsync(Guid playerId)
             => await _connection.GetMongoCollection<PlayerInfos>().DeleteOneAsync(a => a.PlayersId == playerId).ConfigureAwait(false);
        async ValueTask<UpdateResult> IPlayerInfosRepository.EditNickNameAsync(PlayerInfos source)
        {
            var collection = _connection.GetMongoCollection<PlayerInfos>();
            var filter = Builders<PlayerInfos>.Filter.Eq(a => a.Id, source.Id);

            var update = Builders<PlayerInfos>.Update
                .Set(a => a.NickName, source.NickName);

            return await collection.UpdateOneAsync(filter, update).ConfigureAwait(false);
        }
        async ValueTask<PlayerInfos> IPlayerInfosRepository.GetAsync(Guid playerId)
        {
            var cursor = await _connection.GetMongoCollection<PlayerInfos>().FindAsync(a => a.PlayersId == playerId).ConfigureAwait(false);
            return cursor.FirstOrDefault();
        }
    }
}
