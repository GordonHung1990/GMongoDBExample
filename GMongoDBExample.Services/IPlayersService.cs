using System.Threading.Tasks;
using GMongoDBExample.Domains.Models.Players;

namespace GMongoDBExample.Services
{
    public interface IPlayersService
    {
        Task AddAsync(PlayersAddRequest source);
        Task EditNameAsync(PlayersEditNameRequest source);
        Task EditNickNameAsync(PlayersEditNickNameRequest source);
        Task<PlayersGetResponse> GetAsync(string account);
        Task DeleteAsync(string account);
    }
}
