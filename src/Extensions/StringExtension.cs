///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2023/4/3 14:59:35
///   Mail:2609639898@qq.com
///   Github:https://github.com/getup700
///
///   Description:
///
///************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Convert string to int32
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int? ToInt32(this string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return Convert.ToInt32(value);
            }
            return null;

        }

        /// <summary>
        /// Convert string to double
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double? ToDouble(this string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return Convert.ToDouble(value);
            }
            return null;

        }
    }
}
