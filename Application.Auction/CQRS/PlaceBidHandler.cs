using Application.Contracts.Auction;
using Framework.CQRS;

namespace Application.Auction.CQRS
{
    public class PlaceBidHandler : ICommandHandler<PlaceBidCommand>
    {
        public async Task Handle(PlaceBidCommand command)
        {
            Console.WriteLine("Place bid Handler excuted ... !");
            await Task.CompletedTask;
        }
    }
}
