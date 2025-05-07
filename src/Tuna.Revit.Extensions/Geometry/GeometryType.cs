using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extensions;

/// <summary>
/// 解析图形的类型
/// <para>Defines an enum type used to determine the resovled object, 
/// if <see cref="GeometryType"/> is <see cref="GeometryType.Instance"/> ,invoke the method <see cref="Autodesk.Revit.DB.GeometryInstance.GetInstanceGeometry()"/>;
/// else <see cref="Autodesk.Revit.DB.GeometryInstance.GetSymbolGeometry()"/></para>
/// </summary>
public enum GeometryType
{
    /// <summary>
    /// 实例的图形
    /// <para>From instance geometry</para>
    /// </summary>
    Instance,

    /// <summary>
    /// 类型的图形
    /// <para>From symbol geometry</para>
    /// </summary>
    Symbol
}
