///************************************************************************************
///   Author:十五
///   CretaeTime:2021/12/10 19:53:08
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************



using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension
{
    /// <summary>
    /// Revit color extension
    /// </summary>
    public static class ColorExtension
    {
        /// <summary>
        /// Convert to html
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string ConvertToHTML(this Autodesk.Revit.DB.Color color)
        {
            ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(color);
            return ColorTranslator.ToHtml(Color.FromArgb(color.Red, color.Green, color.Blue));
        }


        /// <summary>
        /// Convert To <see cref="Autodesk.Revit.DB.Color"/>
        /// </summary>
        /// <param name="color"></param>
        /// <returns><see cref="Autodesk.Revit.DB.Color"/></returns>
        public static Autodesk.Revit.DB.Color ConvertToRevitColor(this System.Drawing.Color color)
        {
            ArgumentNullExceptionUtils.ThrowIfNull(color);
            return new Autodesk.Revit.DB.Color(color.R, color.G, color.B);
        }

        /// <summary>
        /// Check value is equal between two <see cref="Autodesk.Revit.DB.Color"/>
        /// </summary>
        /// <param name="color"></param>
        /// <param name="otherColor"></param>
        /// <returns></returns>
        public static bool EqualTo(this Autodesk.Revit.DB.Color color, Autodesk.Revit.DB.Color otherColor)
        {
            ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(color);
            ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(otherColor);
            return color.Red == otherColor.Red && color.Green == otherColor.Green && color.Blue == otherColor.Blue;
        }
    }
}
