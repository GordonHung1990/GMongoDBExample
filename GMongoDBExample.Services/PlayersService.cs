using System;
using System.Threading.Tasks;
using GMongoDBExample.Domains.Models.Players;
using GMongoDBExample.Repositories;
using GMongoDBExample.Repositories.Models;

namespace GMongoDBExample.Services
{
    public record PlayersService : IPlayersService
    {
        public readonly IPlayersRepository _playersRepository;
        public readonly IPlayerInfosRepository _playerInfosRepository;

        public PlayersService(
            IPlayersRepository playersRepository,
            IPlayerInfosRepository playerInfosRepository
            )
        {
            _playersRepository = playersRepository ?? throw new ArgumentNullException(nameof(playersRepository));
            _playerInfosRepository = playerInfosRepository ?? throw new ArgumentNullException(nameof(playerInfosRepository));
        }
        async ValueTask IPlayersService.AddAsync(PlayersAddRequest source)
        {
            var get = await _playersRepository.GetAsync(source.Account).ConfigureAwait(false);
            if (get != null)
            {
                throw new("The player already exists.");
            }

            var player = new Players()
            {
                Id = Guid.NewGuid(),
                Account = source.Account,
                Name = source.Name,
                CreationDate = DateTimeOffset.UtcNow,
                ModifiedDate = DateTimeOffset.UtcNow
            };
            await _playersRepository.AddAsync(player).ConfigureAwait(false);
            player = await _playersRepository.GetAsync(source.Account).ConfigureAwait(false);
            var playerInfo = new PlayerInfos()
            {
                Id = Guid.NewGuid(),
                PlayersId = player.Id,
                NickName = source.NickName
            };
            await _playerInfosRepository.AddAsync(playerInfo).ConfigureAwait(false);
        }
        async ValueTask IPlayersService.EditNameAsync(PlayersEditNameRequest source)
        {
            var player = await _playersRepository.GetAsync(source.Account).ConfigureAwait(false);
            if (player == null)
            {
                throw new("Player does not exist");
            }
            player.Name = source.Name;
            await _playersRepository.EditNameAsync(player).ConfigureAwait(false);
        }
        async ValueTask IPlayersService.EditNickNameAsync(PlayersEditNickNameRequest source)
        {
            var player = await _playersRepository.GetAsync(source.Account).ConfigureAwait(false);
            if (player == null)
            {
                throw new("Player does not exist");
            }
            var playerInfo = await _playerInfosRepository.GetAsync(player.Id).ConfigureAwait(false);
            playerInfo.NickName = source.NickName;
            await _playerInfosRepository.EditNickNameAsync(playerInfo).ConfigureAwait(false);
        }
        async ValueTask<PlayersGetResponse> IPlayersService.GetAsync(string account)
        {
            var player = await _playersRepository.GetAsync(account).ConfigureAwait(false);
            if (player == null)
            {
                throw new("Player does not exist");
            }
            var playerInfo = await _playerInfosRepository.GetAsync(player.Id).ConfigureAwait(false);
            return new PlayersGetResponse()
            {
                Id = player.Id,
                Account = player.Account,
                Name = player.Name,
                NickName = playerInfo?.NickName,
                CreationDate = player.CreationDate,
                ModifiedDate = player.ModifiedDate
            };
        }
        async ValueTask IPlayersService.DeleteAsync(string account)
        {
            var player = await _playersRepository.GetAsync(account).ConfigureAwait(false);
            if (player == null)
            {
                throw new("Player does not exist");
            }
            var taskPlayer = _playersRepository.DeleteAsync(account).AsTask();
            var taskPlayerInfo = _playerInfosRepository.DeleteAsync(player.Id).AsTask();

            Task.WaitAll(new Task[] { taskPlayer, taskPlayerInfo });
        }
    }
}
