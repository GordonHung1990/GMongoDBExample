using System;
using System.Linq;
using System.Threading.Tasks;
using GMongoDBExample.Domains.Connections.MongoDB;
using GMongoDBExample.Repositories.Models;
using MongoDB.Driver;

namespace GMongoDBExample.Repositories
{
    internal class PlayersRepository : IPlayersRepository
    {
        private readonly IMongoDBConnection _connection;

        public PlayersRepository(IMongoDBConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public async ValueTask AddAsync(Players source)
            => await _connection.GetMongoCollection<Players>().InsertOneAsync(source).ConfigureAwait(false);

        public async ValueTask<UpdateResult> EditNameAsync(Players source)
        {
            var collection = _connection.GetMongoCollection<Players>();
            var filter = Builders<Players>.Filter.Eq(a => a.Id, source.Id);
            // 設定新的值
            var update = Builders<Players>.Update
                .Set(a => a.Name, source.Name)
                .Set(a => a.ModifiedDate, DateTimeOffset.UtcNow);
            //將過濾條件與設定值傳入 collection 進行更新
            return await collection.UpdateOneAsync(filter, update).ConfigureAwait(false);
        }

        public async ValueTask<DeleteResult> DeleteAsync(string account)
             => await _connection.GetMongoCollection<Players>().DeleteOneAsync(a => a.Account == account).ConfigureAwait(false);

        public async ValueTask<Players> GetAsync(string account)
        {
            var cursor = await _connection.GetMongoCollection<Players>().FindAsync(a => a.Account == account).ConfigureAwait(false);
            return cursor.FirstOrDefault();
        }

    }
}
