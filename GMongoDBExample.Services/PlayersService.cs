using System;
using System.Threading.Tasks;
using GMongoDBExample.Domains.Models.Players;
using GMongoDBExample.Repositories;
using GMongoDBExample.Repositories.Models;

namespace GMongoDBExample.Services
{
    internal sealed class PlayersService : IPlayersService
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

        public async Task AddAsync(PlayersAddRequest source)
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

        public async Task EditNameAsync(PlayersEditNameRequest source)
        {
            var player = await _playersRepository.GetAsync(source.Account).ConfigureAwait(false);
            if (player == null)
            {
                throw new("Player does not exist");
            }
            player.Name = source.Name;
            await _playersRepository.EditNameAsync(player).ConfigureAwait(false);
        }

        public async Task EditNickNameAsync(PlayersEditNickNameRequest source)
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

        public async Task<PlayersGetResponse> GetAsync(string account)
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

        public async Task DeleteAsync(string account)
        {
            var player = await _playersRepository.GetAsync(account).ConfigureAwait(false);
            if (player == null)
            {
                throw new("Player does not exist");
            }
            var taskPlayer = _playersRepository.DeleteAsync(account);
            var taskPlayerInfo = _playerInfosRepository.DeleteAsync(player.Id);

            Task.WaitAll(new Task[] { taskPlayer, taskPlayerInfo });
        }
    }
}
