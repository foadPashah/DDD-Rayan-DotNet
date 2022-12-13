using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.CQRS
{
    public interface ICommandBus
    {
        Task Dispatch<T>(T command) where T : ICommand;
    }
}
