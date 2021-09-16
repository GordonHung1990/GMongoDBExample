using System;
using System.Threading.Tasks;
using GMongoDBExample.Repositories.Models;
using MongoDB.Driver;

namespace GMongoDBExample.Repositories
{
    public interface IPlayerInfosRepository
    {
        Task AddAsync(PlayerInfos source);
        Task<UpdateResult> EditNickNameAsync(PlayerInfos source);
        Task<DeleteResult> DeleteAsync(Guid playerId);
        Task<PlayerInfos> GetAsync(Guid playerId);
    }
}
