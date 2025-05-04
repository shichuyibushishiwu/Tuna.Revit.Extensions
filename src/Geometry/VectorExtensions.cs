/************************************************************************************
   Author:Tony Stark
   CreateTime:2023/5/17 星期三 15:09:02
   Mail:2609639898@qq.com
   Github:https://github.com/getup700

   Description:

************************************************************************************/

using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extensions;

/// <summary>
/// Revit <see cref="Autodesk.Revit.DB.XYZ"/> extensions
/// </summary>
public static class VectorExtensions
{
    /// <summary>
    /// 根据方向和距离移动点
    /// <para>Translate point by the given distance in the given direction.</para>
    /// </summary>
    /// <param name="point">要移动的点</param>
    /// <param name="direction">要移动的方向</param>
    /// <param name="distance">要移动的距离</param>
    /// <returns>移动后的点</returns>
    public static XYZ Translate(this XYZ point, XYZ direction, double distance)
    {
        ArgumentNullExceptionUtils.ThrowIfNull(point);
        ArgumentNullExceptionUtils.ThrowIfNull(direction);

        var shift = direction.Normalize() * distance;
        return point + shift;
    }

    /// <summary>
    /// 判断两个向量是否平行
    /// <para>Determine whether two vectors are almost parallel.</para>
    /// </summary>
    /// <param name="point">要判断的向量</param>
    /// <param name="otherPoint">要判断的另一个向量</param>
    /// <param name="tolerance">公差 默认值（1e-9）</param>
    /// <returns>返回 <see cref="bool"/> 值，当为 ture 时表示向量平行，false表示不向量平行</returns>
    public static bool IsAlmostParallelTo(this XYZ point, XYZ otherPoint, double tolerance = 1E-09)
    {
        ArgumentNullExceptionUtils.ThrowIfNull(point);
        ArgumentNullExceptionUtils.ThrowIfNull(otherPoint);

        double result = point.Normalize().DotProduct(otherPoint);
        return result.AlmostEquals(1, tolerance) || result.AlmostEquals(-1, tolerance);
    }

    /// <summary>
    /// 判断两个向量是否平行且方向相同
    /// <para>Determine whether two vectors are almost parallel and pointing in the same direction.</para>
    /// </summary>
    /// <param name="point">要判断的向量</param>
    /// <param name="otherPoint">要判断的另一个向量</param>
    /// <param name="tolerance">公差 默认值（1e-9）</param>
    /// <returns>返回 <see cref="bool"/> 值，当为 ture 时表示向量同向平行，false表示不同向平行</returns>
    public static bool IsAlmostCodirectionalTo(this XYZ point, XYZ otherPoint, double tolerance = 1E-09)
    {
        ArgumentNullExceptionUtils.ThrowIfNull(point);
        ArgumentNullExceptionUtils.ThrowIfNull(otherPoint);

        double result = point.Normalize().DotProduct(otherPoint);
        return result.AlmostEquals(1, tolerance);
    }

    /// <summary>
    /// 判断两个向量是否垂直
    /// <para>Determine whether two vectors are almost vertical.</para>
    /// </summary>
    /// <param name="point">要判断的向量</param>
    /// <param name="otherPoint">要判断的另一个向量</param>
    /// <param name="tolerance">公差 默认值（1e-9）</param>
    /// <returns>返回 <see cref="bool"/> 值，当为 ture 时表示向量垂直，false表示不垂直</returns>
    public static bool IsAlmostVerticalTo(this XYZ point, XYZ otherPoint, double tolerance = 1E-09)
    {
        ArgumentNullExceptionUtils.ThrowIfNull(point);
        ArgumentNullExceptionUtils.ThrowIfNull(otherPoint);

        double result = point.Normalize().DotProduct(otherPoint);
        return result.AlmostEquals(0, tolerance);
    }
}
