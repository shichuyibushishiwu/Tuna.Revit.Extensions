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
    public static class ColorExtension
    {
        public static string ConvertToHTML(this Autodesk.Revit.DB.Color color)
        {
            return ColorTranslator.ToHtml(Color.FromArgb(color.Red, color.Green, color.Blue));
        }

        public static Autodesk.Revit.DB.Color ConvertToRevitColor(this System.Drawing.Color color)
        {
            return new Autodesk.Revit.DB.Color(color.R, color.G, color.B);
        }
    }
}
