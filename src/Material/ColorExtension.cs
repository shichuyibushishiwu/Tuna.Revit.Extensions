/************************************************************************************
   Author:十五
   CretaeTime:2021/12/10 19:53:08
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// Revit color extension
/// </summary>
public static class ColorExtension
{
    /// <summary>
    /// 将指定的 <see cref="Autodesk.Revit.DB.Color"/> 转换为 HTML 颜色字符串颜色表示形式
    /// <para>Convert <see cref="Autodesk.Revit.DB.Color"/> to color html string</para>
    /// </summary>
    /// <param name="color">要转换的颜色</param>
    /// <returns>表示 HTML 颜色的字符串</returns>
    public static string ConvertToHTML(this Autodesk.Revit.DB.Color color)
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(color);
        return ColorTranslator.ToHtml(Color.FromArgb(color.Red, color.Green, color.Blue));
    }

    /// <summary>
    /// 将指定的 <see cref="System.Drawing.Color"/> 转换为 <see cref="Autodesk.Revit.DB.Color"/>
    /// <para>Convert <see cref="System.Drawing.Color"/> to <see cref="Autodesk.Revit.DB.Color"/></para>
    /// </summary>
    /// <param name="color">要转换的颜色</param>
    /// <returns><see cref="Autodesk.Revit.DB.Color"/></returns>
    public static Autodesk.Revit.DB.Color ConvertToRevitColor(this System.Drawing.Color color)
    {
        ArgumentNullExceptionUtils.ThrowIfNull(color);
        return new Autodesk.Revit.DB.Color(color.R, color.G, color.B);
    }

    /// <summary>
    /// 判断两个 <see cref="Autodesk.Revit.DB.Color"/> 的值是否相等
    /// <para>Check value is equal between two <see cref="Autodesk.Revit.DB.Color"/></para>
    /// </summary>
    /// <param name="color">要判断的 <see cref="Autodesk.Revit.DB.Color"/></param>
    /// <param name="otherColor">另一个 <see cref="Autodesk.Revit.DB.Color"/></param>
    /// <returns>表示两个颜色的值是否相等，true 为相等；反之，不相等</returns>
    public static bool IsEqualTo(this Autodesk.Revit.DB.Color color, Autodesk.Revit.DB.Color otherColor)
    {
        ArgumentNullExceptionUtils.ThrowIfNull(color);
        ArgumentNullExceptionUtils.ThrowIfNull(otherColor);

        if (color.IsValid && !otherColor.IsValid)
        {
            return false;
        }

        if (!color.IsValid && otherColor.IsValid)
        {
            return false;
        }

        if (!color.IsValid && !otherColor.IsValid)
        {
            return true;
        }

        return color.Red == otherColor.Red && color.Green == otherColor.Green && color.Blue == otherColor.Blue;
    }
}