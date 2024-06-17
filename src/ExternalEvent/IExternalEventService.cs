using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 外部事件的常规服务
/// </summary>
public interface IExternalEventService
{
    /// <summary>
    /// 发布外部事件
    /// <para>Post an external command to revit</para>
    /// </summary>
    /// <param name="handle">可执行的任务</param>
    /// <returns><see cref="ExternalEventRequest"/></returns>
    [DebuggerStepThrough]
    ExternalEventRequest PostCommand(Action<UIApplication> handle);
}
