using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.CQRS
{
    internal interface ICommandBus
    {
        Task Dispatch<T>(T command) where T : ICommand;
    }
}
