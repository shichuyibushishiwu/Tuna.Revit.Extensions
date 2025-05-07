using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Infrastructure;

/// <summary>
/// 命令上下文
/// </summary>
public interface ICommandContext
{
    /// <summary>
    /// 
    /// </summary>
    IExternalEventService ExternalEventService { get; }
}
