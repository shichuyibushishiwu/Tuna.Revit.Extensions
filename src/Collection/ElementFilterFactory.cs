/************************************************************************************
   Author:十五
   CretaeTime:2023/4/22 19:01:35
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

using Autodesk.Revit.DB;
using System;

namespace Tuna.Revit.Extension;

/// <summary>
/// 提供创建Revit元素过滤器的工厂类
/// <para>Element filter factory for creating various Revit element filters</para>
/// </summary>
public class ElementFilterFactory
{
    /// <summary>
    /// <c>[Quick Filter]</c>
    /// 创建一个逻辑与过滤器，用于组合多个过滤条件（必须同时满足所有条件）
    /// <para>Create a <see cref="Autodesk.Revit.DB.LogicalAndFilter"/> that combines multiple filters (all conditions must be met)</para>
    /// </summary>
    /// <param name="filters">要组合的过滤器数组</param>
    /// <returns><see cref="Autodesk.Revit.DB.LogicalAndFilter"/></returns>
    public static LogicalAndFilter LogicalAnd(params ElementFilter[] filters)
    {
        return new LogicalAndFilter(filters);
    }

    /// <summary>
    /// <c>[Quick Filter]</c>
    /// 创建一个逻辑或过滤器，用于组合多个过滤条件（满足任一条件即可）
    /// <para>Create a logical OR filter that combines multiple filters (any condition can be met)</para>
    /// </summary>
    /// <param name="filters">要组合的过滤器数组</param>
    /// <returns><see cref="Autodesk.Revit.DB.LogicalOrFilter"/></returns>
    public static LogicalOrFilter LogicalOr(params ElementFilter[] filters)
    {
        return new LogicalOrFilter(filters);
    }

    /// <summary>
    /// <c>[Quick Filter]</c>
    /// 创建一个类型过滤器，用于过滤指定类型的元素
    /// <para>Create a class filter to filter elements of a specific type</para>
    /// </summary>
    /// <param name="type">要过滤的元素类型</param>
    /// <returns><see cref="Autodesk.Revit.DB.ElementClassFilter"/></returns>
    public static ElementClassFilter Class(Type type)
    {
        return new ElementClassFilter(type);
    }

    /// <summary>
    /// <c>[Quick Filter]</c>
    /// 创建一个多类型过滤器，用于过滤多个指定类型的元素
    /// <para>Create a multi-class filter to filter elements of multiple specified types</para>
    /// </summary>
    /// <param name="types">要过滤的元素类型数组</param>
    /// <returns><see cref="Autodesk.Revit.DB.ElementMulticlassFilter"/></returns>
    public static ElementMulticlassFilter Multiclass(params Type[] types)
    {
        return new ElementMulticlassFilter(types);
    }

    /// <summary>
    /// <c>[Slow Filter]</c>
    /// 创建一个参数相等过滤器，用于过滤指定参数值等于给定字符串的元素
    /// <para>Create a parameter equals filter for string values</para>
    /// </summary>
    /// <param name="parameterId">参数的ElementId</param>
    /// <param name="value">要比较的字符串值</param>
    /// <returns><see cref="Autodesk.Revit.DB.ElementParameterFilter"/></returns>
    public static ElementParameterFilter ParameterEqualsTo(ElementId parameterId, string value)
    {
#if !Rvt_23_Before
        return new ElementParameterFilter(ParameterFilterRuleFactory.CreateEqualsRule(parameterId, value));
#else
        return new ElementParameterFilter(ParameterFilterRuleFactory.CreateEqualsRule(parameterId, value, false));
#endif
    }

    /// <summary>
    /// <c>[Slow Filter]</c>
    /// 创建一个参数相等过滤器，用于过滤指定参数值等于给定整数的元素
    /// <para>Create a parameter equals filter for integer values</para>
    /// </summary>
    /// <param name="parameterId">参数的ElementId</param>
    /// <param name="value">要比较的整数值</param>
    /// <returns><see cref="Autodesk.Revit.DB.ElementParameterFilter"/></returns>
    public static ElementParameterFilter ParameterEqualsTo(ElementId parameterId, int value)
    {
        return new ElementParameterFilter(ParameterFilterRuleFactory.CreateEqualsRule(parameterId, value));
    }

    /// <summary>
    /// <c>[Slow Filter]</c>
    /// 创建一个参数相等过滤器，用于过滤指定参数值等于给定整数的元素
    /// <para>Create a parameter equals filter for integer values</para>
    /// </summary>
    /// <param name="parameterId">参数的ElementId</param>
    /// <param name="value">要比较的整数值</param>
    /// <returns><see cref="Autodesk.Revit.DB.ElementParameterFilter"/></returns>
    public static ElementParameterFilter ParameterEqualsTo(ElementId parameterId, ElementId value)
    {
        return new ElementParameterFilter(ParameterFilterRuleFactory.CreateEqualsRule(parameterId, value));
    }

    /// <summary>
    /// <c>[Quick Filter]</c>
    /// 创建一个边界框相交过滤器，用于过滤与给定轮廓相交的元素
    /// <para>Create a bounding box intersects filter to find elements that intersect with the given outline</para>
    /// </summary>
    /// <param name="outline">用于检查相交的轮廓</param>
    /// <returns><see cref="Autodesk.Revit.DB.BoundingBoxIntersectsFilter"/></returns>
    public static BoundingBoxIntersectsFilter IntersectsWith(Outline outline)
    {
        return new BoundingBoxIntersectsFilter(outline);
    }

    /// <summary>
    /// <c>[Quick Filter]</c>
    /// 创建一个边界框内部过滤器，用于过滤完全位于给定边界框内的元素
    /// <para>Create a bounding box inside filter to find elements that are completely inside the given bounding box</para>
    /// </summary>
    /// <param name="boundingBox">用于检查包含关系的边界框</param>
    /// <returns><see cref="Autodesk.Revit.DB.BoundingBoxIsInsideFilter"/></returns>
    public static BoundingBoxIsInsideFilter InsideTheBoundingBox(BoundingBoxXYZ boundingBox)
    {
        return new BoundingBoxIsInsideFilter(new Outline(boundingBox.Min, boundingBox.Max));
    }
}
