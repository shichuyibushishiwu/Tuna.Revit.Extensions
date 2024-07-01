using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 外部事件的返回值
/// </summary>
/// <typeparam name="T"></typeparam>
public class ExternalEventResult<T>
{
    /// <summary>
    /// Value
    /// </summary>
    public T Value { get; set; }

    /// <summary>
    /// exception
    /// </summary>
    public Exception Exception { get; internal set; }

    /// <summary>
    /// Has exception
    /// </summary>
    public bool HasException => Exception != null;

    /// <summary>
    /// ExternalEventRequest
    /// </summary>
    public ExternalEventRequest ExternalEventRequest { get; set; }
}
