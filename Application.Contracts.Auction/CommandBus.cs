using Framework.CQRS;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Contracts.Auction
{
    public class CommandBus : ICommandBus
    {
        private readonly IServiceScopeFactory _serviceProvider;
        public CommandBus(IServiceScopeFactory serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Dispatch<T>(T command) where T : ICommand
        {
            var handler = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ICommandHandler<T>>();
            await handler.Handle(command);
        }
    }
}
