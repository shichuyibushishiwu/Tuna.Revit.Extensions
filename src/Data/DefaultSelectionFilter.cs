///************************************************************************************
///   Author:十五
///   CretaeTime:2023/4/6 0:25:10
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************

using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Data
{
    internal class DefaultSelectionFilter : ISelectionFilter
    {
        public DefaultSelectionFilter()
        {

        }

        public bool AllowElement(Element elem)
        {

            return true;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }
}
