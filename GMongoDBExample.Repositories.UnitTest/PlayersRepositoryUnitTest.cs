using System;
using System.Threading.Tasks;
using GMongoDBExample.Repositories.Models;
using NSubstitute;
using NUnit.Framework;

namespace GMongoDBExample.Repositories.UnitTest
{
    [TestFixture]
    public class PlayersRepositoryUnitTest
    {
        [Test]
        public async Task AddAsync()
        {
            var data = new Players()
            {
                Account = "test",
                Name = "test",
                CreationDate = DateTimeOffset.UtcNow,
                ModifiedDate = DateTimeOffset.UtcNow
            };
            var _repository = Substitute.For<IPlayersRepository>();
            _ = _repository.AddAsync(data);
            await _repository.AddAsync(data).ConfigureAwait(false);
        }
        [Test]
        public async Task EditNameAsync()
        {
            var data = new Players()
            {
                Account = "test",
                Name = "test",
                CreationDate = DateTimeOffset.UtcNow,
                ModifiedDate = DateTimeOffset.UtcNow
            };

            var _repository = Substitute.For<IPlayersRepository>();
            _ = _repository.EditNameAsync(data);
            var actual = await _repository.EditNameAsync(data).ConfigureAwait(false);
        }
        [Test]
        public async Task GetAsync()
        {
            var data = new Players()
            {
                Account = "test",
                Name = "test",
                CreationDate = DateTimeOffset.UtcNow,
                ModifiedDate = DateTimeOffset.UtcNow
            };

            var _repository = Substitute.For<IPlayersRepository>();
            _ = _repository.GetAsync("test").Returns(await Task.FromResult(data));
            var actual = await _repository.GetAsync("test").ConfigureAwait(false);
            Assert.AreEqual(data, actual);
        }
        [Test]
        public async Task DeleteAsync()
        {

            var _repository = Substitute.For<IPlayersRepository>();
            _ = _repository.DeleteAsync("test");
            var actual = await _repository.DeleteAsync("test").ConfigureAwait(false);
            Assert.AreEqual(null, actual);
        }
    }
}