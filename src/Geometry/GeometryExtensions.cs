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
    public static List<GeometryObject> ResolveGeometry(this Element element, Action<Options> action)
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(element);

        Options options = new Options();
        action.Invoke(options);
        GeometryElement geometries = element.get_Geometry(options);

        return ResolveGeometry(geometries);
    }

    /// <summary>
    /// 解析几何块
    /// 注：该方法未过滤体积为零的几何块
    /// </summary>
    /// <param name="element">解析的几何对象</param>
    /// <param name="action">设定获取几何的选项</param>
    /// <returns>几何结果集合</returns>
    public static List<Solid> ResolveSolids(this Element element, Action<GeometryOptions> action) 
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(element);

        GeometryOptions options = new GeometryOptions();
        action.Invoke(options);
        GeometryElement geometries = element.get_Geometry(options);

        return ResolveGeometry(geometries, options).Where(x=>x is Solid ).Cast<Solid>().ToList();
    }

    /// <summary>
    /// 解析几何块
    /// </summary>
    /// <param name="element">解析的几何对象</param>
    /// <param name="action">设定获取几何的选项</param>
    /// <returns>几何结果集合</returns>
    public static List<Face> ResolveFaces(this Element element, Action<GeometryOptions> action)
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(element);

        GeometryOptions options = new GeometryOptions();
        action.Invoke(options);
        GeometryElement geometries = element.get_Geometry(options);

        var geometryObjects = ResolveGeometry(geometries, options);
        var geometryFaces= geometryObjects.Where(x=>x is Face).Cast<Face>().ToList();
        var geometrySolidFaces= geometryObjects.Where(x=>x is Solid).Cast<Solid>().ToList().SelectMany<Solid, Face>((solid) =>
        {
            var faces = new List<Face>();
            foreach (Face face in solid.Faces)
            {
                faces.Add(face);
            }
            return faces;
        });
        var faces = new List<Face>();
        if (geometryFaces.Any())
        {
            faces.AddRange(geometryFaces);
        }
        if (geometrySolidFaces.Any())
        {
            faces.AddRange(geometrySolidFaces);
        }

        return faces;
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

    private static List<GeometryObject> ResolveGeometry(this GeometryElement geometries,GeometryOptions options)
    {
        List<GeometryObject> objects = new List<GeometryObject>();
        foreach (GeometryObject item in geometries)
        {
            switch (item)
            {
                case GeometryInstance geomInstance:
                    if (options.GeometryType==GeometryType.Instance)
                    {
                        objects.AddRange(ResolveGeometry(geomInstance.GetInstanceGeometry()));
                    }
                    else
                    {
                        objects.AddRange(ResolveGeometry(geomInstance.GetSymbolGeometry()));
                    }
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
}

