///************************************************************************************
///   Author:十五
///   CretaeTime:2022/11/29 0:08:10
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension
{
    public static class SelectionExtension
    {
        public static Element SelectElement(this UIDocument uiDocument)
        {
            Reference reference = null;
            try
            {
                reference = uiDocument.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException exception)
            {
                string logInfo = exception.Message;
            }
            return uiDocument.Document.GetElement(reference);
        }
    }
}
