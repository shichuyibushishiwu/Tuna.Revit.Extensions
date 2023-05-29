///************************************************************************************
///   Author:十五
///   CretaeTime:2023/2/26 23:33:44
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuna.Revit.Extension.Data;

namespace Tuna.Revit.Extension.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AvailabilityAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="availability"></param>
        public AvailabilityAttribute(AvailabilityMode availability )
        {
            Availability = availability;
        }

        /// <summary>
        /// 
        /// </summary>
        public AvailabilityMode Availability { get; }
    }
}
