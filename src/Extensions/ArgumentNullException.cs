﻿///************************************************************************************
///   Author:十五
///   CretaeTime:2023/5/29 23:14:05
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
    /// <summary>
    /// 
    /// </summary>
    public static class ArgumentNullException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void IsNull(object parameter)
        {
            if (parameter == null)
            {
                throw new System.ArgumentNullException(nameof(parameter), $"{parameter} can not be null");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void IsNull(Element parameter)
        {
            ArgumentNullException.IsNull(parameter);
            if (!parameter.IsValidObject)
            {
                throw new System.ArgumentNullException(nameof(parameter), $"{parameter} must be valid object");
            }
        }
    }
}
