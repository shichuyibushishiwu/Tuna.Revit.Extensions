using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 按钮的属性
/// </summary>
public class CommandButtonAttribute : Attribute, IRibbonButtonData
{
    /// <summary>
    /// 按钮显示的标题
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 对按钮的介绍
    /// </summary>
    public string LongDescription { get; set; } = string.Empty;

    /// <summary>
    /// 按钮的使用提示
    /// </summary>
    public string ToolTip { get; set; } = string.Empty;

    /// <summary>
    /// 按钮的小图标
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// 按钮的大图标
    /// </summary>
    public string LargeImage { get; set; } = string.Empty;

    /// <summary>
    /// 按钮的提示演示图标
    /// </summary>
    public string ToolTipImage { get; set; } = string.Empty;

    /// <summary>
    /// 按钮的帮助路径
    /// </summary>
    public string Help { get; set; } = string.Empty;

    /// <summary>
    /// 按钮的帮助类型
    /// </summary>
    public ContextualHelpType HelpType { get; set; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    ContextualHelp IRibbonButtonData.ContextualHelp => (!string.IsNullOrEmpty(Help) && HelpType != ContextualHelpType.None) ? new ContextualHelp(HelpType, Help) : default;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    object IRibbonButtonData.Image => Image;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    object IRibbonButtonData.LargeImage => LargeImage;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    object IRibbonButtonData.ToolTipImage => ToolTipImage;
}
