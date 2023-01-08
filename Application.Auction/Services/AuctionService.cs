using Application.Contracts.Auction;
using Application.Contracts.Auction.Dto_s;

namespace Application.Auction.Services
{
    public class AuctionService : IAuctionService
    {
        public async Task OpenAuction(AuctionViewModel model)
        {
            Console.WriteLine($"Open the Auction : fee is {model.Fee} and product is {model.Product}");

            if (model.Fee > 100)
                ///******
                ///
            await Task.CompletedTask;
        }


        public async Task PlaceBid(AuctionViewModel model)
        {
            Console.WriteLine($"place new bid : fee is {model.Fee} and product is {model.Product}");
            await Task.CompletedTask;
        }
    }
}
