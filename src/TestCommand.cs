using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Tuna.Revit.Extension;

[Transaction(TransactionMode.Manual)]
[CommandButton(Title = "sd")]
internal class TestCommand : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        UIDocument uiDocument = commandData.Application.ActiveUIDocument;
        Document document = uiDocument.Document;

        var result = uiDocument.SelectPoint();


        if (!result.Succeeded)
        {
            return Result.Cancelled;
        }

        document.NewTransaction(() =>
        {
            document.Create.NewDetailCurve(document.ActiveView, Line.CreateBound(result.Value, result.Value + new XYZ(10, 0, 0)));
            throw new TransactionRollbackException();
        });

        return Result.Succeeded;
    }
}

