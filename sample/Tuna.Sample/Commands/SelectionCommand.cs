///************************************************************************************
///   Author:十五
///   CretaeTime:2023/4/5 23:50:05
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
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    [Transaction(TransactionMode.Manual)]
    internal class SelectionCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDocument = commandData.Application.ActiveUIDocument;
            Document document = uiDocument.Document;

            uiDocument.SelectObject(Autodesk.Revit.UI.Selection.ObjectType.Element);

            SelectionResult<Reference> result = commandData.Application.ActiveUIDocument.SelectObject(Autodesk.Revit.UI.Selection.ObjectType.Face,
                referencePredicate: parameters => parameters.Reference.ConvertToStableRepresentation(document).Contains("SURFACE"), "asd");
            if (result.SelectionStatus == SelectionStatus.Succeeded)
            {

            }



            commandData.Application.ActiveUIDocument.SelectObject(Autodesk.Revit.UI.Selection.ObjectType.LinkedElement,
                element => element.Category.Id == BuiltInCategories.Walls, "asd");




            return Result.Succeeded;
        }
    }
}
