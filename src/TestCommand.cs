using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Tuna.Revit.Extension;

[Transaction(TransactionMode.Manual)]
internal class TestCommand : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        UIDocument uiDocument = commandData.Application.ActiveUIDocument;
        Document document = uiDocument.Document;

      
        return Result.Succeeded;
    }
}

internal class TestApplication : IExternalApplication
{
    public Result OnShutdown(UIControlledApplication application)
    {
        throw new NotImplementedException();
    }

    public Result OnStartup(UIControlledApplication application)
    {
        application.CreateRibbonTab("tuna", tab => tab

        .CreateRibbonPanel("archi", panel => panel
            .AddPulldownButton()
            .AddSplitButton()
            .AddTextBox()
            .AddComboBox()
            .AddSlideOut(panel => panel
                .AddSplitButton()))

        .CreateRibbonPanel("struct", panel => panel
            .AddSplitButton()));


        return Result.Succeeded;
    }
}
