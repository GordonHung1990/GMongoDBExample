using System.Threading.Tasks;
using GMongoDBExample.Repositories.Models;
using MongoDB.Driver;

namespace GMongoDBExample.Repositories
{
    public interface IPlayersRepository
    {
        Task AddAsync(Players source);
        Task<UpdateResult> EditNameAsync(Players source);
        Task<DeleteResult> DeleteAsync(string account);
        Task<Players> GetAsync(string account);
    }
}
