using System.Threading.Tasks;
using GMongoDBExample.Repositories.Models;
using MongoDB.Driver;

namespace GMongoDBExample.Repositories
{
    public interface IPlayersRepository
    {
        ValueTask AddAsync(Players source);
        ValueTask<UpdateResult> EditNameAsync(Players source);
        ValueTask<DeleteResult> DeleteAsync(string account);
        ValueTask<Players> GetAsync(string account);
    }
}
