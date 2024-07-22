using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 定义一个类型用于解析图元的几何对象
/// </summary>
public class GeometryOptions : Options
{
    /// <summary>
    /// 几何类型
    /// </summary>
    public GeometryType GeometryType { get; set; } = GeometryType.Instance;
}
