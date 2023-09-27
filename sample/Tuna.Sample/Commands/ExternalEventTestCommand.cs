using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Sample.Commands;

[Transaction(TransactionMode.Manual)]
internal class ExternalEventTestCommand : IExternalCommand, IExternalEventHandler
{
    private ExternalEvent externalEvent;
    public ExternalEventTestCommand()
    {
        externalEvent = ExternalEvent.Create(this);
    }

    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        var request = externalEvent.Raise();
        if (request == ExternalEventRequest.Accepted)
        {
            TaskDialog.Show("as", "Accepted");
        }

        return Result.Succeeded;
    }

    public void Execute(UIApplication app)
    {
        TaskDialog.Show("as", "Execute");
    }

    public string GetName() => "asd";
}
