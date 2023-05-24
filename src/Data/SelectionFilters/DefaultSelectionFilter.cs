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

namespace Tuna.Revit.Extension.Data.SelectionFilters
{
    internal class DefaultSelectionFilter : ISelectionFilter
    {
        private readonly Func<Element, bool> _predicate;

        public DefaultSelectionFilter(Func<Element, bool> predicate = null)
        {
            _predicate = predicate;
        }

        public bool AllowElement(Element elem)
        {
            if (elem == null)
            {
                return false;
            }

            if (_predicate != null)
            {
                return _predicate(elem);
            }
            return true;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }
}
