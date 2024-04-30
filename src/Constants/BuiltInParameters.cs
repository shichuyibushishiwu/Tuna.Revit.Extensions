/************************************************************************************
/   Author:十五
/   CretaeTime:2023/3/9 0:30:51
/   Mail:1012201478@qq.com
/   Github:https://github.com/shichuyibushishiwu
/
/   Description:
/
/************************************************************************************/

using Autodesk.Revit.DB;

namespace Tuna.Revit.Extension;

/// <summary>
/// Revit builtin parameters
/// </summary>
public class BuiltInParameters
{
    /// <summary>
    /// INVALID
    /// </summary>
    public static ElementId Invaild { get; } = new ElementId(BuiltInParameter.INVALID);

    /// <summary>
    /// Type of view builtin parameters
    /// </summary>
    public class View
    {
        /// <summary>
        /// VIEW_NAME
        /// </summary>
        public static ElementId Name { get; } = new ElementId(BuiltInParameter.VIEW_NAME);

        /// <summary>
        /// VIEW_DESCRIPTION
        /// </summary>
        public static ElementId Description { get; } = new ElementId(BuiltInParameter.VIEW_DESCRIPTION);

        /// <summary>
        /// VIEW_TYPE
        /// </summary>
        public static ElementId Type { get; } = new ElementId(BuiltInParameter.VIEW_TYPE);

        /// <summary>
        /// VIEW_SCALE
        /// </summary>
        public static ElementId Scale { get; } = new ElementId(BuiltInParameter.VIEW_SCALE);
    }

    /// <summary>
    /// Sheet of view builtin parameters
    /// </summary>
    public class Sheet
    {
        /// <summary>
        /// SHEET_NAME
        /// </summary>
        public static ElementId Name { get; } = new ElementId(BuiltInParameter.SHEET_NAME);

        /// <summary>
        /// SHEET_NUMBER
        /// </summary>
        public static ElementId Number { get; } = new ElementId(BuiltInParameter.SHEET_NUMBER);

        /// <summary>
        /// SHEET_SCALE
        /// </summary>
        public static ElementId Scale { get; } = new ElementId(BuiltInParameter.SHEET_SCALE);

        /// <summary>
        /// SHEET_DATE
        /// </summary>
        public static ElementId Date { get; } = new ElementId(BuiltInParameter.SHEET_DATE);
    }

    /// <summary>
    /// Level of view builtin parameters
    /// </summary>
    public class Level
    {
        /// <summary>
        /// LEVEL_NAME
        /// </summary>
        public static ElementId Name { get; } = new ElementId(BuiltInParameter.LEVEL_NAME);
    }

    /// <summary>
    /// Symbol of view builtin parameters
    /// </summary>
    public class Symbol
    {
        /// <summary>
        /// SYMBOL_NAME_PARAM
        /// </summary>
        public static ElementId Name { get; } = new ElementId(BuiltInParameter.SYMBOL_NAME_PARAM);
    }

    /// <summary>
    /// Room of view builtin parameters
    /// </summary>
    public class Room
    {
        /// <summary>
        /// ROOM_NAME
        /// </summary>
        public static ElementId Name { get; } = new ElementId(BuiltInParameter.ROOM_NAME);

        /// <summary>
        /// ROOM_NUMBER
        /// </summary>
        public static ElementId Number { get; } = new ElementId(BuiltInParameter.ROOM_NUMBER);

        /// <summary>
        /// ROOM_AREA
        /// </summary>
        public static ElementId Area { get; } = new ElementId(BuiltInParameter.ROOM_AREA);

        /// <summary>
        /// ROOM_DEPARTMENT
        /// </summary>
        public static ElementId Department { get; } = new ElementId(BuiltInParameter.ROOM_DEPARTMENT);

        /// <summary>
        /// ROOM_HEIGHT
        /// </summary>
        public static ElementId Height { get; } = new ElementId(BuiltInParameter.ROOM_HEIGHT);

        /// <summary>
        /// ROOM_PHASE
        /// </summary>
        public static ElementId Phase { get; } = new ElementId(BuiltInParameter.ROOM_PHASE);
    }
}
