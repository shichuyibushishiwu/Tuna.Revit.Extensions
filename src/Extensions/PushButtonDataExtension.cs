///************************************************************************************
///   Author:十五
///   CretaeTime:2023/2/27 21:50:31
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Tuna.Revit.Extension.Attributes;
using Tuna.Revit.Extension.Core;

namespace Tuna.Revit.Extension
{
    internal static class PushButtonDataExtension
    {
        /// <summary>
        /// get the attribute where from target type, if custom command class has an availability attribute , 
        /// we can set the push button data avaliability by attribute mode,
        /// </summary>
        /// <param name="button"></param>
        /// <param name="type"></param>
        public static void SetAvailability(this PushButtonData button, Type type)
        {
            AvailabilityAttribute attribute = type.GetCustomAttribute<AvailabilityAttribute>();
            Type availabilityType = null;
            if (attribute != null)
            {
                //attribute
                availabilityType = AvailabilityOptionsFactory.CreateAvailabilityOptions(type);
            }
            else if (typeof(IExternalCommandAvailability).IsAssignableFrom(type))
            {
                //custom
                availabilityType = type;
            }

            if (availabilityType != null)
            {
                button.AvailabilityClassName = availabilityType.FullName;
            }
        }
    }
}
