///************************************************************************************
///   Author:十五
///   CretaeTime:2023/1/27 11:36:56
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuna.Revit.Extension;
using Tuna.Revit.Extension.Attributes;

namespace Tuna.Sample.Commands
{
    [Transaction(TransactionMode.Manual)]
    [Availability(Revit.Extension.Data.AvailabilityMode.OnlyDocument | Revit.Extension.Data.AvailabilityMode.OnlyPlanView)]
    public class GeometryTransientDisplayCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDocument = commandData.Application.ActiveUIDocument;

            Document document = uiDocument.Document;



            document.TransientDisplay(new List<GeometryObject>()
            {
                Line.CreateBound(XYZ.Zero, XYZ.Zero + new XYZ(20, 20, 20))
            });

            var gs = document.GetElements<GraphicsStyle>().FirstOrDefault(g => g.Name == "Test");
            document.TransientDisplay(Line.CreateBound(XYZ.Zero, XYZ.Zero + new XYZ(20, 20, 20)), gs.Id);







            return Result.Succeeded;
        }

        private void Application_Idling(object sender, Autodesk.Revit.UI.Events.IdlingEventArgs e)
        {
            Debug.WriteLine("asd");
        }
    }
}
