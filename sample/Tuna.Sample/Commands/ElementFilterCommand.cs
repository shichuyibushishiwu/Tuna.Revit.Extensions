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

            #region

            //var elems = document.GetElements(StructuralType.Column).ToList();
            //StringBuilder builder = new StringBuilder();
            //foreach (Element element in elems)
            //{
            //    builder.Append(element.Name+"\n");
            //}
            //TaskDialog.Show("Tuna", builder.ToString());
            #endregion


            //var elems = document.GetElements(document.GetElement(new ElementId(197050)) as Family).ToElements().Cast<FamilySymbol>();
            //StringBuilder builder = new StringBuilder();
            //foreach (var element in elems)
            //{
            //    builder.Append(element.GetStructuralSection().Cast<object>().Count() + "\n");
            //}
            //TaskDialog.Show("Tuna", builder.ToString());


            var elems = document.GetElementTypes(BuiltInCategory.OST_Walls).Cast<WallType>().WhereHasInstances<Wall>();
            StringBuilder builder = new StringBuilder();
            builder.Append(elems.Count().ToString());
            foreach (var element in elems)
            {
                builder.Append(element.Name + "\n");
            }
            TaskDialog.Show("Tuna", builder.ToString());


            document.GetElements<Room>();
            return Result.Succeeded;
        }
    }
}
