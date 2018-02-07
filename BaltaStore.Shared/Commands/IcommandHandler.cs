using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Shared.Commands
{
    public interface IcommandHandler <T> where T : ICommando
    {
        ICommandResult Handle(T command);
    }
}
