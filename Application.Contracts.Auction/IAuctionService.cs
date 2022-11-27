using Application.Contracts.Auction.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Auction
{
    public interface IAuctionService
    {
        Task OpenAuction(AuctionViewModel model);
        Task PlaceBid(AuctionViewModel model);
    }
}
