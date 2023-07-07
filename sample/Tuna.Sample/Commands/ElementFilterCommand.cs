///************************************************************************************
///   Author:十五
///   CretaeTime:2023/4/15 11:54:10
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tuna.Revit.Extension;
using Tuna.Revit.Extension.Constants;

namespace Tuna.Sample.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class ElementFilterCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDocument = commandData.Application.ActiveUIDocument;
            Document document = uIDocument.Document;

            //document.GetElements()
            //    .OfCategories(BuiltInCategory.OST_Walls)
            //    .WithParameterStringValue(BuiltInParameter.ALL_MODEL_MODEL, ParameterFilterStringOperator.BeginWith, "m")
            //    .WithParameterStringValue(BuiltInParameter.ALL_MODEL_COST, ParameterFilterStringOperator.Contains, "m")
            //    .WithParameterStringValue(BuiltInParameter.ALL_MODEL_FAMILY_NAME, ParameterFilterStringOperator.BeginWith, "m")
            //    .WithParameterStringValue(BuiltInParameter.ALLOW_AUTO_EMBED, ParameterFilterStringOperator.BeginWith, "m")
            //    .ToFilter()
            //    .ToElements();



            //document.GetElements<FamilyInstance>(instance => instance.Symbol.FamilyName == "预制");


            //var elems = document.GetGraphicElements<FamilyInstance>(instance => instance.Name == "name");

            //Enumerator.Range(1, 100);

            var elems = uIDocument.ActiveGraphicalView.GetElements<Wall>();




            TaskDialog.Show("asd", elems.Count().ToString());

            return Result.Succeeded;
        }
    }


}
