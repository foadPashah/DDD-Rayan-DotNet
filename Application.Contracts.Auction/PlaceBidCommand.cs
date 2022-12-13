using Framework.CQRS;

namespace Application.Contracts.Auction
{
    public class PlaceBidCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
