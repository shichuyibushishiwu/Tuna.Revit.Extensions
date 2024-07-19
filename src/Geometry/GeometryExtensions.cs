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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tuna.Revit.Extension.Geometry;

namespace Tuna.Revit.Extension;

/// <summary>
/// 图形扩展
/// </summary>
public static class GeometryExtensions
{
    /// <summary>
    /// 解析几何
    /// </summary>
    /// <param name="element">解析的几何对象</param>
    /// <param name="action">设定获取几何的选项</param>
    public static List<GeometryObject> ResolveGeometry(this Element element, Action<Options> action)
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(element);

        Options options = new Options();
        action.Invoke(options);
        GeometryElement geometries = element.get_Geometry(options);

        return ResolveGeometry(geometries);
    }


    /// <summary>
    /// 解析几何，并可定义几何结果类型及目标几何来源
    /// </summary>
    /// <typeparam name="T">几何结果类型</typeparam>
    /// <param name="element">解析的几何对象</param>
    /// <param name="action">设定获取几何的选项</param>
    /// <param name="geometryType">目标几何来源</param>
    /// <returns>几何结果集合</returns>
    public static List<T> ResolveGeometry<T>(this Element element, Action<Options> action, GeometryType geometryType= GeometryType.Instance) where T : GeometryObject
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(element);

        Options options = new Options();
        action.Invoke(options);
        GeometryElement geometries = element.get_Geometry(options);

        return ResolveGeometry<T>(geometries, geometryType);
    }


    /// <summary>
    /// 解析几何块
    /// </summary>
    /// <param name="element">解析的几何对象</param>
    /// <param name="action">设定获取几何的选项</param>
    /// <param name="geometryType">目标几何来源</param>
    /// <returns>几何结果集合</returns>
    public static List<Solid> ResolveSolid(this Element element, Action<Options> action, GeometryType geometryType = GeometryType.Instance) 
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(element);

        Options options = new Options();
        action.Invoke(options);
        GeometryElement geometries = element.get_Geometry(options);

        return ResolveGeometry<Solid>(geometries, geometryType);
    }



    private static List<GeometryObject> ResolveGeometry(this GeometryElement geometries)
    {
        List<GeometryObject> objects = new List<GeometryObject>();
        foreach (GeometryObject item in geometries)
        {
            switch (item)
            {
                case GeometryInstance geomInstance:
                    objects.AddRange(ResolveGeometry(geomInstance.GetInstanceGeometry()));
                    break;
                case GeometryElement geometryElement:
                    objects.AddRange(ResolveGeometry(geometryElement));
                    break;
                default:
                    objects.Add(item);
                    break;
            }
        }
        return objects;
    }


    private static List<T> ResolveGeometry<T>(this GeometryElement geometries, GeometryType geometryType = GeometryType.Instance) where T : GeometryObject 
    {
        var results = new List<T>();
        foreach (GeometryObject item in geometries)
        {
            switch (item)
            {
                case T targetType:
                    results.Add(targetType);
                    break;
                case GeometryInstance geomInstance:
                    var geometry = geomInstance.GetInstanceGeometry();
                    if (geometryType == GeometryType.Symbol)
                    {
                        geometry = geomInstance.GetSymbolGeometry();
                    }
                    results.AddRange(ResolveGeometry<T>(geometry, geometryType));
                    break;
                case GeometryElement geometryElement:
                    results.AddRange(ResolveGeometry<T>(geometryElement, geometryType));
                    break;
                default:
                    break;
            }
        }
        return results;
    }




}

