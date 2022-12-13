using Framework.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auction.Decoratore
{
    public class LoggingCommandHandlerDecoratore<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly ICommandHandler<T> _hanlder;

        public LoggingCommandHandlerDecoratore(ICommandHandler<T> hanlder)
        {
            _hanlder = hanlder;
        }

        public async Task Handle(T command)
        {
            Console.WriteLine($"Command Started ! type of Command is : {typeof(T).Name}");
            await _hanlder.Handle(command);
            Console.WriteLine($"Command Executed successfuly ! type of Command is : {typeof(T).Name}");
        }
    }
}
