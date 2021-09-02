using System;
using System.Threading.Tasks;
using GMongoDBExample.Repositories.Models;
using MongoDB.Driver;

namespace GMongoDBExample.Repositories
{
    public interface IPlayerInfosRepository
    {
        ValueTask AddAsync(PlayerInfos source);
        ValueTask<UpdateResult> EditNickNameAsync(PlayerInfos source);
        ValueTask<DeleteResult> DeleteAsync(Guid playerId);
        ValueTask<PlayerInfos> GetAsync(Guid playerId);
    }
}
