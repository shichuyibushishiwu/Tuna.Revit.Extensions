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

namespace Tuna.Sample.Commands
{
    [Transaction(TransactionMode.Manual)]
    internal class ElementFilterCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDocument = commandData.Application.ActiveUIDocument;
            Document document = uIDocument.Document;


            var elems = document.GetGraphicElements<FamilyInstance>(instance => instance.Name == "name");

            Enumerator.Range(1, 100);


            TaskDialog.Show("asd", elems.Count().ToString());

            return Result.Succeeded;
        }
    }

    public static class Test
    {
        /// <summary>
        /// Get all of the 3d model elements from target document
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="document"></param>
        /// <returns></returns>

    }
}
