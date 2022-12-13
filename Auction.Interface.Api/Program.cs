using Application.Auction.CQRS;
using Application.Contracts.Auction;
using Framework.CQRS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<ICommandBus, CommandBus>();
builder.Services.AddSingleton<ICommand, OpenAuctionCommand>()
        .AddScoped<ICommand, PlaceBidCommand>();
builder.Services.AddScoped<ICommandHandler<OpenAuctionCommand>, OpenAuctionHandler>()
       .AddScoped<ICommandHandler<PlaceBidCommand>, PlaceBidHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
