using Application.Auction.CQRS;
using Application.Auction.Decoratore;
using Application.Auction.Services;
using Application.Contracts.Auction;
using Application.Contracts.Auction.Dto_s;
using Framework.CQRS;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddScoped<IAuctionService, AuctionService>();
        services.AddSingleton<ICommandBus, CommandBus>();
        services.AddSingleton<ICommand, OpenAuctionCommand>()
                .AddScoped<ICommand, PlaceBidCommand>();
        services.AddScoped<ICommandHandler<OpenAuctionCommand>, OpenAuctionHandler>()
               .AddScoped<ICommandHandler<PlaceBidCommand>, PlaceBidHandler>();

        ///////////////////////////// Decoratore /////////////////////////////////////////////////////////
        services.AddScoped<ICommandHandler<OpenAuctionCommand>>(provider =>
        new LoggingCommandHandlerDecoratore<OpenAuctionCommand>(new OpenAuctionHandler()));

        services.AddScoped<ICommandHandler<PlaceBidCommand>>(provider =>
        new LoggingCommandHandlerDecoratore<PlaceBidCommand>(new PlaceBidHandler()));

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

//await service.OpenAuction(model1);
//await service.PlaceBid(model2);


///////// CQRS /////////////////

var openAuction = new OpenAuctionCommand()
{
    Product = "p1",
    StartingPrice = 120,
    EndDateTime = DateTime.Now.AddHours(1)
};

var plcaeBid = new PlaceBidCommand()
{
    Id = Guid.NewGuid()
};

var bus = host.Services.GetService<ICommandBus>();

await bus.Dispatch(openAuction);

await bus.Dispatch(plcaeBid);

Console.ReadLine();


