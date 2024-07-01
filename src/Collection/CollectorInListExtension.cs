/************************************************************************************
   Author:十五
   CretaeTime:2023/4/22 12:03:49
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

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
    [DebuggerStepThrough]
    internal static FilteredElementCollector GetElementsInCollector(this Document document, ICollection<ElementId> elementIds)
    {
        ArgumentNullExceptionUtils.ThrowIfNull(document);
        return new FilteredElementCollector(document, elementIds);
    }

    /// <summary>
    /// 根据元素过滤器 <see cref="Autodesk.Revit.DB.ElementFilter"/> 过滤出列表中符合条件的图元
    /// <para>Get elements in the collection base on element filter</para>
    /// </summary>
    /// <param name="document">所在的文档</param>
    /// <param name="elementIds">要查询的列表范围</param>
    /// <param name="elementFilter">元素过滤器</param>
    /// <returns>从列表中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
    [DebuggerStepThrough]
    public static FilteredElementCollector GetElementsInCollector(this Document document, ICollection<ElementId> elementIds, ElementFilter elementFilter)
    {
        return document.GetElementsInCollector(elementIds).WherePasses(elementFilter);
    }

    /// <summary>
    /// 根据类型过滤出列表中的图元对象
    /// <para>Get the elements in the collection which type is subclass of <see cref="Autodesk.Revit.DB.Element"/></para>
    /// </summary>
    /// <param name="document">所在的文档</param>
    /// <param name="elementIds">要查询的列表范围</param>
    /// <param name="type"></param>
    /// <returns>从列表中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
    [DebuggerStepThrough]
    public static FilteredElementCollector GetElementsInCollector(this Document document, ICollection<ElementId> elementIds, Type type)
    {
        return document.GetElementsInCollector(elementIds, new ElementClassFilter(type));
    }

    /// <summary>
    /// 根据类型过滤出列表中的图元对象，该类型必须继承于<see cref="Autodesk.Revit.DB.Element"/>
    /// <para>Get the elements in the collection which type is subclass of <see cref="Autodesk.Revit.DB.Element"/></para>
    /// </summary>
    /// <param name="document">所在的文档</param>
    /// <param name="elementIds">要查询的列表范围</param>
    /// <param name="type"></param>
    /// <param name="types"></param>
    /// <returns>从列表中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
    [DebuggerStepThrough]
    public static FilteredElementCollector GetElementsInCollector(this Document document, ICollection<ElementId> elementIds, Type type, params Type[] types)
    {
        if (types.Length == 0)
        {
            return document.GetElementsInCollector(elementIds, type);
        }
        List<Type> allTypes = types.ToList();
        allTypes.Add(type);
        return document.GetElementsInCollector(elementIds, new ElementMulticlassFilter(allTypes));
    }

    /// <summary>
    /// 根据内置类别过滤出列表中的图元对象
    /// <para>Get elements in the collection by <see cref="Autodesk.Revit.DB.BuiltInCategory"/></para>
    /// </summary>
    /// <param name="document">所在的文档</param>
    /// <param name="elementIds">要查询的列表范围</param>
    /// <param name="builtInCategory"></param>
    /// <returns>从列表中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
    [DebuggerStepThrough]
    public static FilteredElementCollector GetElementsInCollector(this Document document, ICollection<ElementId> elementIds, BuiltInCategory builtInCategory)
    {
        return document.GetElementsInCollector(elementIds, new ElementCategoryFilter(builtInCategory));
    }

    /// <summary>
    /// 根据多个内置类别过滤出列表中的图元对象
    /// <para>Get elements in the collection by multicategoriy <see cref="Autodesk.Revit.DB.BuiltInCategory"/></para>
    /// </summary>
    /// <param name="document">所在的文档</param>
    /// <param name="elementIds">要查询的列表范围</param>
    /// <param name="builtInCategory"></param>
    /// <param name="categories"></param>
    /// <returns>从列表中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
    [DebuggerStepThrough]
    public static FilteredElementCollector GetElementsInCollector(this Document document, ICollection<ElementId> elementIds, BuiltInCategory builtInCategory, params BuiltInCategory[] categories)
    {
        if (categories.Length == 0)
        {
            return document.GetElementsInCollector(elementIds, builtInCategory);
        }
        List<BuiltInCategory> allCategories = categories.ToList();
        allCategories.Add(builtInCategory);
        return document.GetElementsInCollector(elementIds, new ElementMulticategoryFilter(allCategories));
    }

    /// <summary>
    /// 根据结构墙体实例参数 <b>「结构用途」</b> 过滤出列表中的结构墙体图元对象
    /// <para>Get structural walls in the collection by <see cref="Autodesk.Revit.DB.Structure.StructuralWallUsage"/></para>
    /// </summary>
    /// <param name="document">所在的文档</param>
    /// <param name="elementIds">要查询的列表范围</param>
    /// <param name="structuralWallUsage"></param>
    /// <returns>从列表中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
    [DebuggerStepThrough]
    public static FilteredElementCollector GetElementsInCollector(this Document document, ICollection<ElementId> elementIds, StructuralWallUsage structuralWallUsage)
    {
        return document.GetElementsInCollector(elementIds, new StructuralWallUsageFilter(structuralWallUsage));
    }

    /// <summary>
    /// 从列表中查找与目标图元发生碰撞的对象
    /// <para>Get the elements which intersected with target elements</para>
    /// </summary>
    /// <param name="document">所在的文档</param>
    /// <param name="elementIds">要查询的列表范围</param>
    /// <param name="element">要进行碰撞的图元</param>
    /// <returns>从列表中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
    [DebuggerStepThrough]
    public static FilteredElementCollector GetElementIntersectsInCollector(this Document document, ICollection<ElementId> elementIds, Element element)
    {
        return document.GetElementsInCollector(elementIds, new ElementIntersectsElementFilter(element));
    }
}
