using Application.Auction.CQRS;
using Application.Auction.Decoratore;
using Application.Auction.Services;
using Application.Contracts.Auction;
using Application.Contracts.Auction.Dto_s;
using Auction.Domain;
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


///////// CompositeSpecification /////////////////
Console.WriteLine("--------------Composite Specification----------------");

var condition = new NegotiableAuction();
var condition2 = new NegotiableAuction().And(new PaintingAuction());
var condition3 = new NegotiableAuction().GreaterThan(1000);

var auction = new Auctions()
{
    Id = 1,
    Good = "painting",
    GoodType = GoodType.Paint,
    IsOpen = true,
    Price = new Money(100, Currency.USD),
    CreateTime = DateTime.Now.AddMinutes(-10),
    LastBidTime = DateTime.Now
};


var auction2 = new Auctions()
{
    Id = 2,
    Good = "building",
    GoodType = GoodType.Property,
    IsOpen = true,
    Price = new Money(5000, Currency.USD),
    CreateTime = DateTime.Now.AddMinutes(-3),
    LastBidTime = DateTime.Now
};

var auction3 = new Auctions()
{
    Id = 2,
    Good = "paiting",
    GoodType = GoodType.Paint,
    IsOpen = false,
    Price = new Money(10000, Currency.USD),
    CreateTime = DateTime.Now,
    LastBidTime = DateTime.Now
};

var auction4 = new Auctions()
{
    Id = 2,
    Good = "BMW S7",
    GoodType = GoodType.Vehicle,
    IsOpen = true,
    Price = new Money(20000, Currency.USD),
    CreateTime = DateTime.Now.AddMinutes(-3),
    LastBidTime = DateTime.Now
};

List<Auctions> lst = new List<Auctions>() { auction, auction2, auction3, auction4 };

foreach (var item in lst)
{
    Console.WriteLine($"result of condition 1 for good : {item.Good} is {condition.IsSatisfied(item)}");
    Console.WriteLine($"result of condition 2 for good : {item.Good} is {condition2.IsSatisfied(item)}");
}


var lstresult = lst.Where(w => condition2.IsSatisfied(w)).ToList();

lstresult.ForEach(w => Console.WriteLine($"tilte : {w.Good} price : {w.Price.Box} {w.Price.Currency}"));

var lstresult2 = lst.Where(w => condition3.IsSatisfied(w.Price.Box)).ToList();

lstresult2.ForEach(w => Console.WriteLine($"Greater Than 1000 for tilte : {w.Good}"));

///////////////// State Pattern /////////////////
Console.WriteLine("------------------------State Pattern------------------------");

var saller = new Saller("foad", "Pashah", Sex.Male);

saller.AcceptSaller();

Thread.Sleep(3000);
saller.InProgressSaller();
Console.WriteLine($"State of Saller : {saller.Name} {saller.LastName} is {saller.State.GetType().Name}");

Thread.Sleep(3000);

saller.AcceptSaller();
Console.WriteLine($"State of Saller : {saller.Name} {saller.LastName} is {saller.State.GetType().Name}");

Console.ReadLine();


