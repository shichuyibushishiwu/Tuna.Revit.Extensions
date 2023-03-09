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
    public class BuiltInCategories
    {
        public static ElementId Invaild => new ElementId(BuiltInCategory.INVALID);

        public static ElementId Door => new ElementId(BuiltInCategory.OST_Doors);

        public static ElementId CableTray => new ElementId(BuiltInCategory.OST_CableTray);

        public static ElementId CableTrayFitting => new ElementId(BuiltInCategory.OST_CableTrayFitting);

        public static ElementId DuctCurves => new ElementId(BuiltInCategory.OST_DuctCurves);

        public static ElementId DuctLinings => new ElementId(BuiltInCategory.OST_DuctLinings);

        public static ElementId DuctInsulations => new ElementId(BuiltInCategory.OST_DuctInsulations);

        public static ElementId DuctFitting => new ElementId(BuiltInCategory.OST_DuctFitting);

        public static ElementId DuctAccessory => new ElementId(BuiltInCategory.OST_DuctAccessory);

        public static ElementId DuctTerminal => new ElementId(BuiltInCategory.OST_DuctTerminal);

        public static ElementId PipeCurves => new ElementId(BuiltInCategory.OST_PipeCurves);

        public static ElementId PipeInsulations => new ElementId(BuiltInCategory.OST_PipeInsulations);

        public static ElementId PipeFitting => new ElementId(BuiltInCategory.OST_PipeFitting);

        public static ElementId PipeAccessory => new ElementId(BuiltInCategory.OST_PipeAccessory);
    }
}
