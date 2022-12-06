﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.CQRS
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task Handle(T command);
    }
}
