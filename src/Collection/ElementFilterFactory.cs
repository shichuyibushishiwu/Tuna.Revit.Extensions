using Autodesk.Revit.DB;
using System;

namespace Tuna.Revit.Extension;

/// <summary>
/// Element filter factory
/// </summary>
public class ElementFilterFactory
{
    /// <summary>
    /// Create a element filter <see cref="Autodesk.Revit.DB.LogicalAndFilter"/>
    /// </summary>
    /// <param name="filters"></param>
    /// <returns><see cref="Autodesk.Revit.DB.LogicalAndFilter"/></returns>
    public static LogicalAndFilter LogicalAnd(params ElementFilter[] filters)
    {
        return new LogicalAndFilter(filters);
    }

    /// <summary>
    /// Create a element filter <see cref="Autodesk.Revit.DB.LogicalOrFilter"/>  
    /// </summary>
    /// <param name="filters"></param>
    /// <returns><see cref="Autodesk.Revit.DB.LogicalOrFilter"/></returns>
    public static LogicalOrFilter LogicalOr(params ElementFilter[] filters)
    {
        return new LogicalOrFilter(filters);
    }

    /// <summary>
    /// Create a element filter <see cref="Autodesk.Revit.DB.ElementClassFilter"/> 
    /// </summary>
    /// <param name="type"></param>
    /// <returns><see cref="Autodesk.Revit.DB.ElementClassFilter"/></returns>
    public static ElementClassFilter Class(Type type)
    {
        return new ElementClassFilter(type);
    }

    /// <summary>
    /// Create a element filter <see cref="Autodesk.Revit.DB.ElementMulticlassFilter"/> 
    /// </summary>
    /// <param name="types"></param>
    /// <returns><see cref="Autodesk.Revit.DB.ElementMulticlassFilter"/> </returns>
    public static ElementMulticlassFilter Multiclass(params Type[] types)
    {
        return new ElementMulticlassFilter(types);
    }
}
