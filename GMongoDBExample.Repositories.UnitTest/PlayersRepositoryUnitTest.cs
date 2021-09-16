using System;
using System.Threading.Tasks;
using GMongoDBExample.Repositories.Models;
using MongoDB.Driver;
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
            var updateResult = Substitute.For<UpdateResult>();
            var data = new Players()
            {
                Account = "test",
                Name = "test",
                CreationDate = DateTimeOffset.UtcNow,
                ModifiedDate = DateTimeOffset.UtcNow
            };

            var _repository = Substitute.For<IPlayersRepository>();
            _ = _repository.EditNameAsync(data).Returns(updateResult);
            var actual = await _repository.EditNameAsync(data).ConfigureAwait(false);
            Assert.AreEqual(updateResult, actual);
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
            var deleteResult = Substitute.For<DeleteResult>();
            var _repository = Substitute.For<IPlayersRepository>();
            _ = _repository.DeleteAsync("test").Returns(Task.FromResult(deleteResult));
            var actual = await _repository.DeleteAsync("test").ConfigureAwait(false);
            Assert.AreEqual(deleteResult, actual);
        }
    }
}