/************************************************************************************
   Author:十五
   CretaeTime:2023/3/9 0:35:01
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Constants;

/// <summary>
/// Revit 中部分常用的内置类别
/// <para>Revit builtin categories</para>
/// </summary>
public class BuiltInCategories
{
    /// <summary>
    /// 无效的类别
    /// <para>INVALID</para>
    /// </summary>
    public static ElementId Invaild { get; } = new ElementId(BuiltInCategory.INVALID);

    /// <summary>
    /// 内置的门类别
    /// <para>OST_Doors</para>
    /// </summary>
    public static ElementId Door { get; } = new ElementId(BuiltInCategory.OST_Doors);

    /// <summary>
    /// 内置的墙体类别
    /// <para>OST_Walls</para>
    /// </summary>
    public static ElementId Wall { get; } = new ElementId(BuiltInCategory.OST_Walls);

    /// <summary>
    /// OST_CableTray
    /// </summary>
    public static ElementId CableTray { get; } = new ElementId(BuiltInCategory.OST_CableTray);

    /// <summary>
    /// OST_CableTrayFitting
    /// </summary>
    public static ElementId CableTrayFitting { get; } = new ElementId(BuiltInCategory.OST_CableTrayFitting);

    /// <summary>
    /// OST_DuctCurves
    /// </summary>
    public static ElementId DuctCurves { get; } = new ElementId(BuiltInCategory.OST_DuctCurves);

    /// <summary>
    /// OST_DuctLinings
    /// </summary>
    public static ElementId DuctLinings { get; } = new ElementId(BuiltInCategory.OST_DuctLinings);

    /// <summary>
    /// OST_DuctInsulations
    /// </summary>
    public static ElementId DuctInsulations { get; } = new ElementId(BuiltInCategory.OST_DuctInsulations);

    /// <summary>
    /// OST_DuctFitting
    /// </summary>
    public static ElementId DuctFitting { get; } = new ElementId(BuiltInCategory.OST_DuctFitting);

    /// <summary>
    /// OST_DuctAccessory
    /// </summary>
    public static ElementId DuctAccessory { get; } = new ElementId(BuiltInCategory.OST_DuctAccessory);

    /// <summary>
    /// OST_DuctTerminal
    /// </summary>
    public static ElementId DuctTerminal { get; } = new ElementId(BuiltInCategory.OST_DuctTerminal);

    /// <summary>
    /// OST_PipeCurves
    /// </summary>
    public static ElementId PipeCurves { get; } = new ElementId(BuiltInCategory.OST_PipeCurves);

    /// <summary>
    /// OST_PipeInsulations
    /// </summary>
    public static ElementId PipeInsulations { get; } = new ElementId(BuiltInCategory.OST_PipeInsulations);

    /// <summary>
    /// OST_PipeFitting
    /// </summary>
    public static ElementId PipeFitting { get; } = new ElementId(BuiltInCategory.OST_PipeFitting);

    /// <summary>
    /// OST_PipeAccessory
    /// </summary>
    public static ElementId PipeAccessory { get; } = new ElementId(BuiltInCategory.OST_PipeAccessory);
}
