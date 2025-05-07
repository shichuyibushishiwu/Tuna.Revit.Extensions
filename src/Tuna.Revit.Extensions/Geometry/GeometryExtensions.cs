/************************************************************************************
   Author:十五
   CretaeTime:
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tuna.Revit.Extensions;

/// <summary>
/// 图形扩展
/// </summary>
public static class GeometryExtensions
{
    /// <summary>
    /// 从<see cref="Autodesk.Revit.DB.Element"/> 中解析出指定类型的<see cref="Autodesk.Revit.DB.GeometryObject"/> 列表。
    /// <para>Resolve a list of <see cref="Autodesk.Revit.DB.GeometryObject"/>s of the specified type from a <see cref="Autodesk.Revit.DB.Element"/>.</para>
    /// </summary>
    /// <param name="element">要解析的 <see cref="Autodesk.Revit.DB.Element"/>.</param>
    /// <param name="action">用于配置 <see cref="Tuna.Revit.Extensions.GeometryOptions"/> 的委托。</param>
    /// <returns><see cref="System.Collections.Generic.List{T}"/> 包含解析出的几何对象。</returns>
    [DebuggerStepThrough]
    public static List<GeometryObject> ResolveGeometry(this Element element, Action<GeometryOptions> action)
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(element);

        GeometryOptions options = new GeometryOptions();
        action.Invoke(options);
        GeometryElement geometries = element.get_Geometry(options);

        return ResolveGeometry(geometries, options.GeometryType);
    }

    /// <summary>
    /// 从<see cref="Autodesk.Revit.DB.Element"/> 中解析出指定类型的<see cref="Autodesk.Revit.DB.Solid"/> 列表。
    /// <para>Resolve a list of <see cref="Autodesk.Revit.DB.Solid"/>s of the specified type from a <see cref="Autodesk.Revit.DB.Element"/>.</para>
    /// </summary>
    /// <remarks>方法未过滤体积为零的几何块</remarks>
    /// <param name="element">要解析的 <see cref="Autodesk.Revit.DB.Element"/>.</param>
    /// <param name="action">用于配置 <see cref="Tuna.Revit.Extensions.GeometryOptions"/> 的委托。</param>
    /// <returns><see cref="System.Collections.Generic.List{T}"/> 包含解析出的几何对象。</returns>
    [DebuggerStepThrough]
    public static List<Solid> ResolveSolids(this Element element, Action<GeometryOptions> action)
    {
        return element.ResolveGeometry(action).Where(x => x is Solid).Cast<Solid>().ToList();
    }

    /// <summary>
    /// 从<see cref="Autodesk.Revit.DB.Element"/> 中解析出指定类型的<see cref="Autodesk.Revit.DB.Face"/> 列表。
    /// <para>Resolve a list of <see cref="Autodesk.Revit.DB.Face"/>s of the specified type from a <see cref="Autodesk.Revit.DB.Element"/>.</para>
    /// </summary>
    /// <param name="element">要解析的 <see cref="Autodesk.Revit.DB.Element"/>.</param>
    /// <param name="action">用于配置 <see cref="Tuna.Revit.Extensions.GeometryOptions"/> 的委托。</param>
    /// <returns><see cref="System.Collections.Generic.List{T}"/> 包含解析出的几何对象。</returns>
    [DebuggerStepThrough]
    public static List<Face> ResolveFaces(this Element element, Action<GeometryOptions> action)
    {
        return element.ResolveSolids(action).SelectMany(soild => soild.Faces.ToArray()).ToList();
    }
    
    /// <summary>
    /// 从<see cref="Autodesk.Revit.DB.GeometryElement"/> 中解析出指定类型的<see cref="Autodesk.Revit.DB.GeometryObject"/> 列表。
    /// <para>Resolve a list of <see cref="Autodesk.Revit.DB.GeometryObject"/>s of the specified type from a <see cref="Autodesk.Revit.DB.GeometryElement"/>.</para>
    /// </summary>
    /// <param name="geometries">要解析的 <see cref="Autodesk.Revit.DB.GeometryElement"/>.</param>
    /// <param name="geometryType">指定解析哪种类型的几何对象。</param>
    /// <returns><see cref="System.Collections.Generic.List{T}"/> 包含解析出的几何对象。</returns>
    [DebuggerStepThrough]
    private static List<GeometryObject> ResolveGeometry(this GeometryElement geometries, GeometryType geometryType)
    {
        List<GeometryObject> objects = new List<GeometryObject>();
        foreach (GeometryObject item in geometries)
        {
            switch (item)
            {
                case GeometryInstance geomInstance:
                    GeometryElement subGeometryElement = geometryType == GeometryType.Instance ?
                        geomInstance.GetInstanceGeometry() :
                        geomInstance.GetSymbolGeometry();

                    objects.AddRange(ResolveGeometry(subGeometryElement, geometryType));
                    break;
                case GeometryElement geometryElement:
                    objects.AddRange(ResolveGeometry(geometryElement, geometryType));
                    break;
                default:
                    objects.Add(item);
                    break;
            }
        }
        return objects;
    }
}

