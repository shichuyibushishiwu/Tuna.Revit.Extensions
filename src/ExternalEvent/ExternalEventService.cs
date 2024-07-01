using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
///  通用的外部事件
/// </summary>
public class ExternalEventService : IExternalEventService, IExternalEventHandler
{
    private readonly Autodesk.Revit.UI.ExternalEvent _externalEvent;
    private Action<UIApplication> _handle;

    /// <summary>
    /// 初始化外部事件，只能在有效上下文进行
    /// </summary>
    public ExternalEventService() => _externalEvent = Autodesk.Revit.UI.ExternalEvent.Create(this);

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="app"><inheritdoc/></param>
    [DebuggerStepThrough]
    public void Execute(UIApplication app)
    {
        if (_handle == null)
        {
            throw new ArgumentNullException("handle can not be null");
        }
        _handle.Invoke(app);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns><inheritdoc/></returns>
    [DebuggerStepThrough]
    public string GetName() => "Tuna external event";

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="handle"><inheritdoc/></param>
    [DebuggerStepThrough]
    public ExternalEventRequest PostCommand(Action<UIApplication> handle)
    {
        ArgumentNullExceptionUtils.ThrowIfNull(handle);
        _handle = handle;
        ExternalEventRequest externalEventRequest = _externalEvent.Raise();
        if (externalEventRequest != ExternalEventRequest.Accepted)
        {
            throw new Exception("handle can not accepted");
        }

        return externalEventRequest;
    }
}
