using Framework.CQRS;

namespace Application.Auction.CQRS 
{
    public class PlaceBidCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
