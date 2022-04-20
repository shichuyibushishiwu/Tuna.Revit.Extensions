///************************************************************************************
///   Author:十五
///   CretaeTime:2021/12/10 19:30:36
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************


using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension
{
    public static class UnitExtension
    {
        public static double ConvertToMillimeters(this int value)
        {
            return ((double)value).ConvertToMillimeters();
        }

        public static double ConvertToMillimeters(this double value)
        {
            return UnitUtils.Convert(value, UnitTypeId.Feet, UnitTypeId.Millimeters);
        }
    }
}
