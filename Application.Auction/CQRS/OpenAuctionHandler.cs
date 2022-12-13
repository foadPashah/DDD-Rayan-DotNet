using Application.Contracts.Auction;
using Framework.CQRS;

namespace Application.Auction.CQRS
{
    public class OpenAuctionHandler : ICommandHandler<OpenAuctionCommand>
    {
        public async Task Handle(OpenAuctionCommand command)
        {
            /// 
            Console.WriteLine("Open Auction Handle executed ....");
            ///
            ///***
            /// do somethings
            ///    ****
            ///

            await Task.CompletedTask;
        }
    }
}
