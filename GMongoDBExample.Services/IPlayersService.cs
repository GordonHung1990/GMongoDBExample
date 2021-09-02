using System.Threading.Tasks;
using GMongoDBExample.Domains.Models.Players;

namespace GMongoDBExample.Services
{
    public interface IPlayersService
    {
        ValueTask AddAsync(PlayersAddRequest source);
        ValueTask EditNameAsync(PlayersEditNameRequest source);
        ValueTask EditNickNameAsync(PlayersEditNickNameRequest source);
        ValueTask<PlayersGetResponse> GetAsync(string account);
        ValueTask DeleteAsync(string account);
    }
}
