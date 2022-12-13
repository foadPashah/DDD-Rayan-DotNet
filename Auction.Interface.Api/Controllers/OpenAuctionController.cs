using Application.Contracts.Auction;
using Framework.CQRS;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Interface.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAuctionController : Controller
    {
        private readonly ICommandBus _bus;

        public OpenAuctionController(ICommandBus bus)
        {
            _bus = bus;
        }


        [HttpPost]
        public async Task<IActionResult> Post(OpenAuctionCommand command)
        {
            await _bus.Dispatch(command);
            return Ok();
        }
    }
}
