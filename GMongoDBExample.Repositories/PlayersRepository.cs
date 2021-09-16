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

        public Task AddAsync(Players source)
            => _connection.GetMongoCollection<Players>().InsertOneAsync(source);

        public async Task<UpdateResult> EditNameAsync(Players source)
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

        public Task<DeleteResult> DeleteAsync(string account)
             => _connection.GetMongoCollection<Players>().DeleteOneAsync(a => a.Account == account);

        public async Task<Players> GetAsync(string account)
        {
            var cursor = await _connection.GetMongoCollection<Players>().FindAsync(a => a.Account == account).ConfigureAwait(false);
            return cursor.FirstOrDefault();
        }

    }
}
