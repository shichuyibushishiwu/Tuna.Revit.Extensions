using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
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
    public static Task<TResult> PostCommandAsync<TResult>(this IExternalEventService service, Func<UIApplication, TResult> handle)
    {
        ArgumentNullExceptionUtils.ThrowIfNull(service);
        var tsc = new TaskCompletionSource<TResult>();
        service.PostCommand(uiapp =>
        {
            try
            {
                tsc.SetResult(handle.Invoke(uiapp));
            }
            catch (Exception e)
            {
                tsc.SetException(e);
            }
        });
        return tsc.Task;
    }
}
