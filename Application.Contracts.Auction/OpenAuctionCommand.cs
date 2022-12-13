using Framework.CQRS;

namespace Application.Contracts.Auction
{
    public class OpenAuctionCommand : ICommand
    {
        public string Product { get; set; }

        public int StartingPrice { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}
