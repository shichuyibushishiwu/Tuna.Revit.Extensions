using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Services
{
    internal class ExternalEventService : IExternalEventService, IExternalEventHandler
    {
        private readonly ExternalEvent _externalEvent;

        public ExternalEventService()
        {
            _externalEvent = ExternalEvent.Create(this);
        }

        public void Execute(UIApplication app)
        {

        }

        public string GetName() => "Tuna external event";

        public void Run()
        {
            ExternalEventRequest request = _externalEvent.Raise();


        }
    }
}
