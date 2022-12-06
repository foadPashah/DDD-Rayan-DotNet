using Framework.CQRS;

namespace Application.Auction.CQRS
{
    public class OpenAuctionCommand : ICommand
    {
        public string Product { get; set; }

        public int StartingPrice { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}
