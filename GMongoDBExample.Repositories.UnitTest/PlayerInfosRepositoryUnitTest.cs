using System;
using System.Threading.Tasks;
using GMongoDBExample.Repositories.Models;
using MongoDB.Driver;
using NSubstitute;
using NUnit.Framework;

namespace GMongoDBExample.Repositories.UnitTest
{
    [TestFixture]
    public class PlayerInfosRepositoryUnitTest
    {
        [Test]
        public async Task AddAsync()
        {
            var data = new PlayerInfos()
            {
                Id = Guid.NewGuid(),
                PlayersId = Guid.NewGuid(),
                NickName = "test"
            };
            var _repository = Substitute.For<IPlayerInfosRepository>();
            _ = _repository.AddAsync(data);
            await _repository.AddAsync(data).ConfigureAwait(false);
        }
        [Test]
        public async Task EditNickNameAsync()
        {
            var updateResult = Substitute.For<UpdateResult>();
            var data = new PlayerInfos()
            {
                Id = Guid.NewGuid(),
                PlayersId = Guid.NewGuid(),
                NickName = "test"
            };

            var _repository = Substitute.For<IPlayerInfosRepository>();
            _ = _repository.EditNickNameAsync(data).Returns(updateResult);
            var actual = await _repository.EditNickNameAsync(data).ConfigureAwait(false);
            Assert.AreEqual(updateResult, actual);
        }
        [Test]
        public async Task GetAsync()
        {
            var data = new PlayerInfos()
            {
                Id = Guid.NewGuid(),
                PlayersId = Guid.NewGuid(),
                NickName = "test"
            };

            var _repository = Substitute.For<IPlayerInfosRepository>();
            _ = _repository.GetAsync(data.PlayersId).Returns(Task.FromResult(data));
            var actual = await _repository.GetAsync(data.PlayersId).ConfigureAwait(false);
            Assert.AreEqual(data, actual);
        }
        [Test]
        public async Task DeleteAsync()
        {
            var deleteResult = Substitute.For<DeleteResult>();
            var data = Guid.NewGuid();
            var _repository = Substitute.For<IPlayerInfosRepository>();
            _ = _repository.DeleteAsync(data).Returns(Task.FromResult(deleteResult));
            var actual = await _repository.DeleteAsync(data).ConfigureAwait(false);
            Assert.AreEqual(deleteResult, actual);
        }
    }
}
