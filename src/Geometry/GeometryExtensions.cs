using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Geometry;


/// <summary>
/// 图形扩展
/// </summary>
public static class GeometryExtensions
{
    /// <summary>
    /// 解析图形
    /// </summary>
    public static List<GeometryObject> ResolveGeometry(this Element element, Action<Options> action)
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(element);

        Options options = new Options();
        action.Invoke(options);
        GeometryElement geometries = element.get_Geometry(options);

        return ResolveGeometry(geometries);
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
                case Curve curve: break;
                case Edge edge: break;
                case Face face: break;
                case Mesh mesh: break;
                case Point point: break;
                case PolyLine polyLine: break;
                case Profile profile: break;
                case Solid solid: break;
            }
        }
        return objects;
    }

}
