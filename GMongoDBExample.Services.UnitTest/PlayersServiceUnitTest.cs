using System;
using System.Threading.Tasks;
using GMongoDBExample.Domains.Models.Players;
using GMongoDBExample.Repositories;
using GMongoDBExample.Repositories.Models;
using NSubstitute;
using NUnit.Framework;

namespace GMongoDBExample.Services.UnitTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public async Task AddAsync()
        {
            var fakePlayersRepository = Substitute.For<IPlayersRepository>();
            var fakePlayerInfosRepository = Substitute.For<IPlayerInfosRepository>();


            var service = Substitute.For<IPlayersService>();

            var request = new PlayersAddRequest
            {
                Account = "test",
                Name = "test",
                NickName = "test"
            };

            var data = new Players()
            {
                Id = Guid.NewGuid(),
                Account = "test",
                Name = "test",
                CreationDate = DateTimeOffset.UtcNow,
                ModifiedDate = DateTimeOffset.UtcNow
            };

            _ = service.AddAsync(request);

            await service.AddAsync(request).ConfigureAwait(false);

            _ = fakePlayersRepository.AddAsync(Arg.Any<Players>());

            _ = fakePlayersRepository.GetAsync(Arg.Any<string>());

            _ = fakePlayerInfosRepository.AddAsync(Arg.Any<PlayerInfos>());

        }
    }
}