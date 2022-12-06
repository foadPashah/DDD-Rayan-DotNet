using Application.Auction.Services;
using Application.Contracts.Auction;
using Application.Contracts.Auction.Dto_s;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddScoped<IAuctionService, AuctionService>();

    }).UseConsoleLifetime().Build();

var service = host.Services.GetService<IAuctionService>();
var model1 = new AuctionViewModel()
{
    Product = "AAA",
    Fee = 10
};

var model2 = new AuctionViewModel()
{
    Product = "BBB",
    Fee = 25
};

await service.OpenAuction(model1);
await service.PlaceBid(model2);

Console.ReadLine();


