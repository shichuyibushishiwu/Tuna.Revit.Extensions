using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ExternalEventService : IExternalEventService, IExternalEventHandler
    {
        private readonly ExternalEvent _externalEvent;

        /// <summary>
        /// 
        /// </summary>
        public ExternalEventService()
        {
            _externalEvent = ExternalEvent.Create(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void Execute(UIApplication app)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetName() => "Tuna external event";

        /// <summary>
        /// 
        /// </summary>
        public async Task PostCommandAsync(Action<UIApplication> handle)
        {
            ExternalEventRequest request = _externalEvent.Raise();
            if (request == ExternalEventRequest.Accepted)
            {
                await InternalPostCommandAsync(handle);
            }
        }

        private async Task InternalPostCommandAsync(Action<UIApplication> handle)
        {
            _handle = handle;
          
            await Task.CompletedTask;
        }

        private Action<UIApplication> _handle;

        public void PostCommand(Action<UIApplication> handle)
        {
            _handle = handle;
            _externalEvent.Raise();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class Extensions
    {
        public static Task CommandAsync<T>(this ExternalEventService service, Action<UIApplication> handle)
        {
            var tsc = new TaskCompletionSource<T>();
            service.PostCommand(uiapp =>
            {
                try
                {
                    handle.Invoke(uiapp);
                }
                catch (Exception e)
                {
                    tsc.SetException(e);
                }
            });
            return tsc.Task;
        }
    }
}
