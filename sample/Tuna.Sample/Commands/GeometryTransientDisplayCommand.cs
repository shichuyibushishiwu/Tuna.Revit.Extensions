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
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuna.Revit.Extension;


namespace Tuna.Sample.Commands
{
    [Transaction(TransactionMode.Manual)]
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


            Categories categories = document.Settings.Categories;
            var genericModel = categories.get_Item(BuiltInCategory.OST_GenericModel);
            if (!genericModel.SubCategories.Contains("Test"))
            {
                document.NewTransaction(() =>
                {
                    var subcategory = categories.NewSubcategory(genericModel, "Test");
                    subcategory.LineColor = new Color(0, 127, 0);
                });
            }

            var gs = document.GetElements<GraphicsStyle>().FirstOrDefault(g => g.Name == "Test");
            document.TransientDisplay(Line.CreateBound(XYZ.Zero, XYZ.Zero + new XYZ(0, 10, 10)), gs.Id);

            return Result.Succeeded;
        }
    }
}
