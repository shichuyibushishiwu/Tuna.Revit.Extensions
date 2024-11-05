using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Geometry;

/// <summary>
/// 关于矩阵<see cref="Autodesk.Revit.DB.Transform"/>的扩展
/// </summary>
public static class TransformExtensions
{
    /// <summary>
    /// 复制一个新的矩阵
    /// <para>Duplicate a new <see cref="Autodesk.Revit.DB.Transform"/></para>
    /// </summary>
    /// <param name="transform">要复制的矩阵</param>
    /// <returns>复制后返回的新的矩阵</returns>
    public static Transform Duplicate(this Transform transform)
    {
        Transform result = Transform.Identity;
        result.Origin = transform.Origin;
        result.BasisX = transform.BasisX;
        result.BasisY = transform.BasisY;
        result.BasisZ = transform.BasisZ;
        return result;
    }
}
