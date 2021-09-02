using GMongoDBExample.Domains.Models.Players;
using GMongoDBExample.Models.Players;
using GMongoDBExample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GMongoDBExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly ILogger<PlayersController> _logger;

        public PlayersController(ILogger<PlayersController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the specified service.
        /// </summary>
        /// <remarks>
        ///  
        ///     Get /api/Players/test
        /// 
        /// </remarks>
        /// <param name="service">The service.</param>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        [HttpGet("{account}")]
        public ValueTask<PlayersGetResponse> GetAsync(
            [FromServices] IPlayersService service,
            string account
            )
            => service.GetAsync(account);

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <remarks>
        ///  
        ///     POST /api/Players
        ///     {
        ///        "account": "test",
        ///        "name": "test",
        ///        "nickName": "test"
        ///     }
        /// 
        /// </remarks>
        /// <param name="service">The service.</param>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        [HttpPost]
        public ValueTask AddAsync(
            [FromServices] IPlayersService service,
            [FromBody] PlayersAddRequest source
            )
            => service.AddAsync(source);

        /// <summary>
        /// Edits the name asynchronous.
        /// </summary>
        /// <remarks>
        ///  
        ///     Put /api/Players/test/EditName
        ///     {
        ///        "name": "test2"
        ///     }
        /// 
        /// </remarks>
        /// <param name="service">The service.</param>
        /// <param name="account">The account.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut("{account}/EditName")]
        public ValueTask EditNameAsync(
            [FromServices] IPlayersService service,
            string account,
            [FromBody] PlayersEditNameViewModel model
            )
            => service.EditNameAsync(new PlayersEditNameRequest()
            {
                Account = account,
                Name = model.Name
            });

        /// <summary>
        /// Edits the nick name asynchronous.
        /// </summary>
        /// <remarks>
        ///  
        ///     Put /api/Players/test/EditNickName
        ///     {
        ///        "nickName": "test2"
        ///     }
        /// 
        /// </remarks>
        /// <param name="service">The service.</param>
        /// <param name="account">The account.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut("{account}/EditNickName")]
        public ValueTask EditNickNameAsync(
            [FromServices] IPlayersService service,
            string account,
            [FromBody] PlayersEditNickNameViewModel model
            )
            => service.EditNickNameAsync(new PlayersEditNickNameRequest()
            {
                Account = account,
                NickName = model.NickName
            });

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <remarks>
        ///  
        ///     Delete /api/Players/test
        /// 
        /// </remarks>
        /// <param name="service">The service.</param>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        [HttpDelete("{account}")]
        public ValueTask DeleteAsync(
            [FromServices] IPlayersService service,
            string account
            )
            => service.DeleteAsync(account);


    }
}
