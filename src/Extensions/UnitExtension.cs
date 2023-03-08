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

namespace Tuna.Revit.Extension
{
    public static class UnitExtension
    {
        /// <summary>
        /// Convert To Millimeters
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ConvertToMillimeters(this int value)
        {
            return ((double)value).ConvertToMillimeters();
        }

        /// <summary>
        /// Convert To Millimeters
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ConvertToMillimeters(this double value)
        {
#if Rvt_21 || Rvt_22 || Rvt_23
            return UnitUtils.Convert(value, UnitTypeId.Feet, UnitTypeId.Millimeters);
#else 
            return UnitUtils.Convert(value, DisplayUnitType.DUT_DECIMAL_FEET, DisplayUnitType.DUT_MILLIMETERS);
#endif
        }
    }
}
