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

        //var result = uiDocument.SelectElement<FamilyInstance>(prompt: "asd");

        //if (result.SelectionStatus == SelectionStatus.Succeeded)
        //{
        //    var solid = result.Value.ResolveSolids(options => options.DetailLevel = ViewDetailLevel.Fine);
        //    System.Windows.MessageBox.Show(solid.Count.ToString());
        //}

        var elems = document.GetGraphicElements();
        var asd = elems.Count();

        System.Windows.MessageBox.Show(asd.ToString());




        return Result.Succeeded;
    }
}

