///************************************************************************************
///   Author:十五
///   CretaeTime:2023/3/9 0:35:01
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

namespace Tuna.Revit.Extension.Constants
{
    /// <summary>
    /// Revit builtin categories
    /// </summary>
    public class BuiltInCategories
    {
        /// <summary>
        /// INVALID
        /// </summary>
        public static ElementId Invaild => new ElementId(BuiltInCategory.INVALID);

        /// <summary>
        /// OST_Doors
        /// </summary>
        public static ElementId Door => new ElementId(BuiltInCategory.OST_Doors);

        /// <summary>
        /// OST_CableTray
        /// </summary>
        public static ElementId CableTray => new ElementId(BuiltInCategory.OST_CableTray);

        /// <summary>
        /// OST_CableTrayFitting
        /// </summary>
        public static ElementId CableTrayFitting => new ElementId(BuiltInCategory.OST_CableTrayFitting);

        /// <summary>
        /// OST_DuctCurves
        /// </summary>
        public static ElementId DuctCurves => new ElementId(BuiltInCategory.OST_DuctCurves);

        /// <summary>
        /// OST_DuctLinings
        /// </summary>
        public static ElementId DuctLinings => new ElementId(BuiltInCategory.OST_DuctLinings);

        /// <summary>
        /// OST_DuctInsulations
        /// </summary>
        public static ElementId DuctInsulations => new ElementId(BuiltInCategory.OST_DuctInsulations);

        /// <summary>
        /// OST_DuctFitting
        /// </summary>
        public static ElementId DuctFitting => new ElementId(BuiltInCategory.OST_DuctFitting);

        /// <summary>
        /// OST_DuctAccessory
        /// </summary>
        public static ElementId DuctAccessory => new ElementId(BuiltInCategory.OST_DuctAccessory);

        /// <summary>
        /// OST_DuctTerminal
        /// </summary>
        public static ElementId DuctTerminal => new ElementId(BuiltInCategory.OST_DuctTerminal);

        /// <summary>
        /// OST_PipeCurves
        /// </summary>
        public static ElementId PipeCurves => new ElementId(BuiltInCategory.OST_PipeCurves);

        /// <summary>
        /// OST_PipeInsulations
        /// </summary>
        public static ElementId PipeInsulations => new ElementId(BuiltInCategory.OST_PipeInsulations);

        /// <summary>
        /// OST_PipeFitting
        /// </summary>
        public static ElementId PipeFitting => new ElementId(BuiltInCategory.OST_PipeFitting);

        /// <summary>
        /// OST_PipeAccessory
        /// </summary>
        public static ElementId PipeAccessory => new ElementId(BuiltInCategory.OST_PipeAccessory);
    }
}
