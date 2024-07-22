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
    /// <returns>几何对象集合</returns>
    public static List<GeometryObject> ResolveGeometry(this Element element, Action<GeometryOptions> action)
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(element);

        GeometryOptions options = new GeometryOptions();
        action.Invoke(options);
        GeometryElement geometries = element.get_Geometry(options);

        return ResolveGeometry(geometries, options.GeometryType);
    }

    /// <summary>
    /// 解析几何体
    /// </summary>
    /// <remarks>该方法未过滤体积为零的几何块</remarks>
    /// <param name="element">解析的几何对象</param>
    /// <param name="action">设定获取几何的选项</param>
    /// <returns>几何块集合</returns>
    public static List<Solid> ResolveSolids(this Element element, Action<GeometryOptions> action)
    {
        return element.ResolveGeometry(action).Where(x => x is Solid).Cast<Solid>().ToList();
    }

    /// <summary>
    /// 解析几何面
    /// </summary>
    /// <param name="element">解析的几何对象</param>
    /// <param name="action">设定获取几何的选项</param>
    /// <returns>几何面集合</returns>
    public static List<Face> ResolveFaces(this Element element, Action<GeometryOptions> action)
    {
        return element.ResolveSolids(action).SelectMany(soild => soild.Faces.ToList()).ToList();
    }

    /// <summary>
    /// Get faces from <see cref="Autodesk.Revit.DB.FaceArray"/>
    /// </summary>
    /// <param name="faceArray"></param>
    /// <returns></returns>
    private static IEnumerable<Face> ToList(this FaceArray faceArray)
    {
        foreach (Face item in faceArray)
        {
            yield return item;
        }
    }

    /// <summary>
    /// 解析图形
    /// </summary>
    /// <param name="geometries"></param>
    /// <param name="geometryType"></param>
    /// <returns></returns>
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

