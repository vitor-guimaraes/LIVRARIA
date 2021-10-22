﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infra.Interfaces.Commands
{
    public interface ICommandHandler<T> where T : ICommandPadrao
    {
        ICommandResult Handle(T command);
    }
}
