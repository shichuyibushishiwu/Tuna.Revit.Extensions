///************************************************************************************
///   Author:十五
///   CretaeTime:2023/4/22 12:03:49
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
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="elementIds"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        internal static FilteredElementCollector GetElementsInCollector(this Document document, ICollection<ElementId> elementIds)
        {
            if (!document!.IsValidObject)
            {
                throw new ArgumentNullException(nameof(document), "document is null or invalid object");
            }
            return new FilteredElementCollector(document, elementIds);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="elementIds"></param>
        /// <param name="elementFilter"></param>
        /// <returns></returns>
        public static FilteredElementCollector GetElementsInCollector(this Document document, ICollection<ElementId> elementIds, ElementFilter elementFilter)
        {
            return document.GetElementsInCollector(elementIds).WherePasses(elementFilter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="elementIds"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static FilteredElementCollector GetElementIntersectsInCollector(this Document document, ICollection<ElementId> elementIds, Element element)
        {
            return document.GetElementsInCollector(elementIds, new ElementIntersectsElementFilter(element));
        }
    }
}
