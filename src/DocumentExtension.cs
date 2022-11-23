///************************************************************************************
///   Author:十五
///   CretaeTime:2021/11/19 21:41:53
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************

using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension
{
    public static class DocumentExtension
    {
        private static FilteredElementCollector GetElements(this Document document)
        {
            if (document == null || !document.IsValidObject)
            {
                throw new ArgumentNullException("document is null or invalid object");
            }
            return new FilteredElementCollector(document);
        }

        public static FilteredElementCollector GetElements(this Document document, ElementFilter filter)
        {
            return document.GetElements().WherePasses(filter);
        }

        private static FilteredElementCollector GetElements(this Document document, Type type)
        {
            return document.GetElements(new ElementClassFilter(type));
        }

        private static IEnumerable<T> GetElements<T>(this Document document, Func<T, bool> predicate = null) where T : Element
        {
            IEnumerable<T> elements = document.GetElements(typeof(T)).Cast<T>();
            if (predicate != null)
            {
                elements = elements.Where(predicate);
            }
            return elements;
        }
    }
}
