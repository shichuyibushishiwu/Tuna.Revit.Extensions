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
    public static class CollectorInListExtension
    {
        /// <summary>
        /// 在列表范围进行查询
        /// </summary>
        /// <param name="document">所在的文档</param>
        /// <param name="elementIds">要查询的列表范围</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        internal static FilteredElementCollector GetElementsInCollector(this Document document, ICollection<ElementId> elementIds)
        {
            ArgumentNullException.ThrowIfNull(document);
            return new FilteredElementCollector(document, elementIds);
        }

        /// <summary>
        /// 根据元素过滤器过滤出列表中符合条件的图元
        /// </summary>
        /// <param name="document">所在的文档</param>
        /// <param name="elementIds">要查询的列表范围</param>
        /// <param name="elementFilter">元素过滤器</param>
        /// <returns></returns>
        public static FilteredElementCollector GetElementsInCollector(this Document document, ICollection<ElementId> elementIds, ElementFilter elementFilter)
        {
            return document.GetElementsInCollector(elementIds).WherePasses(elementFilter);
        }

        /// <summary>
        /// 从列表中查找与目标图元发生碰撞的对象
        /// </summary>
        /// <param name="document">所在的文档</param>
        /// <param name="elementIds">要查询的列表范围</param>
        /// <param name="element">要进行碰撞的图元</param>
        /// <returns></returns>
        public static FilteredElementCollector GetElementIntersectsInCollector(this Document document, ICollection<ElementId> elementIds, Element element)
        {
            return document.GetElementsInCollector(elementIds, new ElementIntersectsElementFilter(element));
        }
    }
}
