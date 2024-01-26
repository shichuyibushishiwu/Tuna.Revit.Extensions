/************************************************************************************
   Author:十五
   CretaeTime:2023/2/26 23:10:54
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

using Autodesk.Revit.UI;
using System.Drawing;

namespace Tuna.Revit.Extension;

/// <summary>
/// 按钮的属性
/// <para>Revit ribbon ui push button information</para>
/// </summary>
public interface IRibbonButtonData
{
    /// <summary>
    /// 按钮显示的标题
    /// <para>Ribbon button display text</para>
    /// </summary>
    string Title { get; }

    /// <summary>
    /// 对按钮的介绍
    /// <para>Ribbon button long description</para>
    /// </summary>
    string LongDescription { get; }

    /// <summary>
    /// 按钮的使用提示
    /// <para>Ribbon button tool tip</para>
    /// </summary>
    string ToolTip { get; }

    /// <summary>
    /// 按钮的小图标(16px * 16px)
    /// <para>Ribbon button small image which size is 16px * 16px</para>
    /// </summary>
    object Image { get; }

    /// <summary>
    /// 按钮的大图标(32px * 32px)
    /// <para>Ribbon button large image which size is 32px * 32px</para>
    /// </summary>
    object LargeImage { get; }

    /// <summary>
    /// 按钮的提示演示图标
    /// <para>Ribbon button tool tip image</para>
    /// </summary>
    object ToolTipImage { get; }

    /// <summary>
    /// 按钮的帮助路径
    /// <para>Ribbon button contextual help</para>
    /// </summary>
    ContextualHelp ContextualHelp { get; }
}
