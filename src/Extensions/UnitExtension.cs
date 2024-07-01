/************************************************************************************
   Author:十五
   CretaeTime:2021/12/10 19:30:36
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

using Autodesk.Revit.DB;
using System;
using System.Diagnostics;

namespace Tuna.Revit.Extension;

/// <summary>
/// Revit unit extensions
/// </summary>
public static class UnitExtension
{
    /// <summary>
    /// 将值的单位从 (英尺) 转为 (毫米)
    /// <para>Convert value to millimeters</para>
    /// </summary>
    /// <param name="value">单位为英尺的值</param>
    /// <returns>单位为毫米的值</returns>
    [DebuggerStepThrough]
    public static double ConvertToMillimeters(this double value)
    {
#if Rvt_16 || Rvt_17 || Rvt_18 || Rvt_19 || Rvt_20
        return UnitUtils.Convert(value, DisplayUnitType.DUT_DECIMAL_FEET, DisplayUnitType.DUT_MILLIMETERS);
#else
        return UnitUtils.Convert(value, UnitTypeId.Feet, UnitTypeId.Millimeters);
#endif
    }

    /// <summary>
    /// 将值的单位从 (英尺) 转为 (毫米)
    /// <para>Convert value to millimeters</para>
    /// </summary>
    /// <param name="value">单位为英尺的值</param>
    /// <returns>单位为毫米的值</returns>
    [DebuggerStepThrough] 
    public static double ConvertToMillimeters(this int value) => ((double)value).ConvertToMillimeters();

    /// <summary>
    /// 将值的单位从 (英尺) 转为 (毫米)
    /// <para>Convert value to millimeters</para>
    /// </summary>
    /// <param name="value">单位为英尺的值</param>
    /// <returns>单位为毫米的值</returns>
    [DebuggerStepThrough] 
    public static double ConvertToMillimeters(this float value) => Convert.ToDouble(value.ToString()).ConvertToMillimeters();

    /// <summary>
    /// 将值的单位从 (毫米) 转为 (英尺)
    /// <para>Convert millimeters to feet</para>
    /// </summary>
    /// <param name="value">单位为毫米的值</param>
    /// <returns>单位为英尺的值</returns>
    [DebuggerStepThrough]
    public static double ConvertToFeet(this double value)
    {
#if Rvt_16 || Rvt_17 || Rvt_18 || Rvt_19 || Rvt_20
        return UnitUtils.Convert(value, DisplayUnitType.DUT_MILLIMETERS, DisplayUnitType.DUT_DECIMAL_FEET);

#else
        return UnitUtils.Convert(value, UnitTypeId.Millimeters, UnitTypeId.Feet);
#endif
    }

    /// <summary>
    /// 将值的单位从 (毫米) 转为 (英尺)
    /// <para>Convert millimeters to feet</para>
    /// </summary>
    /// <param name="value">单位为毫米的值</param>
    /// <returns>单位为英尺的值</returns>
    [DebuggerStepThrough] 
    public static double ConvertToFeet(this int value) => ((double)value).ConvertToFeet();

    /// <summary>
    /// 将值的单位从 (毫米) 转为 (英尺)
    /// <para>Convert millimeters to feet</para>
    /// </summary>
    /// <param name="value">单位为毫米的值</param>
    /// <returns>单位为英尺的值</returns>
    [DebuggerStepThrough] 
    public static double ConvertToFeet(this float value) => Convert.ToDouble(value.ToString()).ConvertToFeet();

    /// <summary>
    /// 判断两个数值在允许的公差范围内是否相等
    /// </summary>
    /// <param name="value">要比较的数值</param>
    /// <param name="otherValue">要比较的另一个数值</param>
    /// <param name="tolerance">公差 默认值（1e-9）</param>
    /// <returns>返回 <see cref="bool"/> 值，当为 ture 时表示数值相等，false表示不相等</returns>
    [DebuggerStepThrough]
    public static bool AlmostEquals(this double value, double otherValue, double tolerance = 1e-9)
    {
        return Math.Abs(value - otherValue) <= tolerance;
    }
}