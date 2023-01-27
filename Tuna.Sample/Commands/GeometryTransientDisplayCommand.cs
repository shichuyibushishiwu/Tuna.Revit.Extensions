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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuna.Revit.Extension;

namespace Tuna.Sample.Commands
{
    [Transaction(TransactionMode.Manual)]
    internal class GeometryTransientDisplayCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDocument = commandData.Application.ActiveUIDocument;

            Document document = uiDocument.Document;

            var ma = document.GetElements<Material>().FirstOrDefault(m => m.Name == "Test");



            document.TransientDisplay(ma.Id, Point.Create(XYZ.Zero + new XYZ(5, 10, 10)));

            return Result.Succeeded;
        }


    }
}
