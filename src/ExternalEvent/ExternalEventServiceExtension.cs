using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 外部事件对异步的扩展
/// </summary>
public static class ExternalEventServiceExtension
{
    /// <summary>
    /// 用异步的方式发布外部事件
    /// <para>Asynchronously post an external command to revit</para>
    /// </summary>
    /// <param name="service">外部事件的服务</param>
    /// <param name="handle">执行的内容</param>
    /// <returns></returns>
    [DebuggerStepThrough]
    public static Task PostCommandAsync(this IExternalEventService service, Action<UIApplication> handle)
    {
        return service.PostCommandAsync((uiApp) =>
        {
            handle(uiApp);
            return default(object);
        });
    }

    /// <summary>
    /// 用异步的方式发布外部事件
    /// <para>Asynchronously post an external command to revit</para>
    /// </summary>
    /// <typeparam name="TResult">返回的结果</typeparam>
    /// <param name="service">外部事件的服务</param>
    /// <param name="handle">执行的内容</param>
    /// <returns></returns>
    [DebuggerStepThrough]
    public static Task<ExternalEventResult<TResult>> PostCommandAsync<TResult>(this IExternalEventService service, Func<UIApplication, TResult> handle)
    {
        ArgumentNullExceptionUtils.ThrowIfNull(service);
        var tsc = new TaskCompletionSource<ExternalEventResult<TResult>>();
        ExternalEventResult<TResult> externalEventResult = new ExternalEventResult<TResult>();
        ExternalEventRequest externalEventRequest = service.PostCommand(uiapp =>
        {
            try
            {
                TResult result = handle.Invoke(uiapp);
                externalEventResult.Value = result;
                tsc.SetResult(externalEventResult);
            }
            catch (Exception e)
            {
                externalEventResult.Exception = e;
                tsc.SetException(e);
            }
        });
        externalEventResult.ExternalEventRequest = externalEventRequest;
        return tsc.Task;
    }
}
