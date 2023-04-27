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
    [Transaction(TransactionMode.Manual)]
    internal class SelectionCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDocument = commandData.Application.ActiveUIDocument;

            uiDocument.SelectObject(Autodesk.Revit.UI.Selection.ObjectType.Element);


            return Result.Succeeded;
        }
    }
}
