using Auction.Domain;
using Framework.CompositeSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Auction
{
    public class NegotiableAuction : Specification<Auctions>
    {
        public override bool IsSatisfied(Auctions value)
        {
            return value.IsOpen;
        }
    }
}
