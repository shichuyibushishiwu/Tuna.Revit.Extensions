using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void PostCommand()
        {
            ExternalEventRequest request = _externalEvent.Raise();
        }
    }
}
