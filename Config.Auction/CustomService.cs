using Application.Auction.CQRS;
using Application.Contracts.Auction;
using Framework.CQRS;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Config.Auction
{
    public static class CustomService
    {
        public static void AddCustomService(this IServiceCollection services)
        { 
            services.AddSingleton<ICommandBus, CommandBus>();
            //services.AddScoped<ICommandHandler<OpenAuctionCommand>, OpenAuctionHandler>();
        }
    }
}
