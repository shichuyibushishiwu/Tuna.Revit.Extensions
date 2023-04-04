///************************************************************************************
///   Author:十五
///   CretaeTime:2023/2/26 23:31:29
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

namespace Tuna.Revit.Extension.Data
{
    [Flags]
    public enum AvailabilityMode
    {
        /// <summary>
        /// 
        /// </summary>
        Always = 0,

        /// <summary>
        /// 
        /// </summary>
        OnlyDocument = 1,

        /// <summary>
        /// 
        /// </summary>
        OnlyFamily = 2,

        /// <summary>
        /// 
        /// </summary>
        OnlyProject = 4,

        /// <summary>
        /// 
        /// </summary>
        OnlyThreeDView = 8,

        /// <summary>
        /// 
        /// </summary>
        OnlyPlanView = 16,
    }
}
