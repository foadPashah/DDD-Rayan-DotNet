using Auction.Domain;
using Framework.CompositeSpecification;

namespace Application.Contracts.Auction
{
    public class PaintingAuction : Specification<Auctions>
    {
        public override bool IsSatisfied(Auctions value)
        {
            return value.GoodType == GoodType.Paint;
        }
    }
}
