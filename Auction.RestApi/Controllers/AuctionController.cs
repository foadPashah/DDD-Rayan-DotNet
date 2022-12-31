using Application.Contracts.Auction;
using Framework.CQRS;
using Microsoft.AspNetCore.Mvc;

namespace Auction.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly ICommandBus _bus;

        public AuctionController(ICommandBus bus)
        {
            _bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> Get(OpenAuctionCommand command)
        { 
            await _bus.Dispatch(command);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(OpenAuctionCommand command)
        {
            await _bus.Dispatch(command);
            return Ok();
        }
    }
}
