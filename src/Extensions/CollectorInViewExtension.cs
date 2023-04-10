///************************************************************************************
///   Author:十五
///   CretaeTime:2022/11/27 23:58:13
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
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension
{
    /// <summary>
    /// Revit element filters extension
    /// </summary>
    public static partial class CollectorExtension
    {
        /// <summary>
        /// Get elements in view
        /// </summary>
        /// <param name="document"></param>
        /// <param name="viewId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static FilteredElementCollector GetElementsInView(this Document document, ElementId viewId)
        {
            if (!document!.IsValidObject)
            {
                throw new ArgumentNullException(nameof(document), "document is null or invalid object");
            }
            return new FilteredElementCollector(document, viewId);
        }

        /// <summary>
        /// Get elements in view
        /// </summary>
        /// <param name="document"></param>
        /// <param name="viewId"></param>
        /// <param name="elementFilter"></param>
        /// <returns></returns>
        public static FilteredElementCollector GetElementsInView(this Document document, ElementId viewId, ElementFilter elementFilter)
        {
            return document.GetElementsInView(viewId).WherePasses(elementFilter);
        }

        /// <summary>
        /// Get elements in view
        /// </summary>
        /// <param name="document"></param>
        /// <param name="viewId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static FilteredElementCollector GetElementsInView(this Document document, ElementId viewId, Type type)
        {
            return document.GetElementsInView(viewId, new ElementClassFilter(type));
        }

        /// <summary>
        /// Get element in view
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document"></param>
        /// <param name="viewId"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetElementsInView<T>(this Document document, ElementId viewId, Func<T, bool> predicate = null) where T : Element
        {
            IEnumerable<T> elements = document.GetElementsInView(viewId, typeof(T)).Cast<T>();
            if (predicate != null)
            {
                elements = elements.Where(predicate);
            }
            return elements;
        }
    }
}
