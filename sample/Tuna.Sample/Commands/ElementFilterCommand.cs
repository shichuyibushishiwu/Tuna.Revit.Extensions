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
    internal class ElementFilterCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDocument = commandData.Application.ActiveUIDocument;
            Document document = uIDocument.Document;

            document.GetElements(Tuna.Revit.Extension.Constants.BuiltInCategories.Door);

            Autodesk.Revit.DB.FilteredElementCollector doors = document.GetElements(new ElementCategoryFilter(Tuna.Revit.Extension.Constants.BuiltInCategories.Door));
            TaskDialog.Show("sd", doors.Count().ToString());

            ParameterValueProvider provider = new ParameterValueProvider(new ElementId(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS));

            FilterStringRuleEvaluator evaluator = new FilterStringEquals();

            FilterRule filterRule = new FilterStringRule(provider, evaluator, "ListA", false);

            FilteredElementCollector elems = document.GetElements(new ElementParameterFilter(new List<FilterRule>() { filterRule }));
            commandData.Application.ActiveUIDocument.Selection.SetElementIds(elems.ToElementIds());
            TaskDialog.Show("shiwu", $"{elems.GetElementCount()}");

            return Result.Succeeded;
        }
    }
}
