using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Infrastructure;

/// <summary>
/// 
/// </summary>
public class CommandContext : ICommandContext
{
    public IExternalEventService ExternalEventService => throw new NotImplementedException();
}
