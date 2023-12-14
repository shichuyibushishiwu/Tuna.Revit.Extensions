using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 元素类型
/// </summary>
public enum RibbonItemType
{
    /// <summary>
    /// 面板
    /// </summary>
    RibbonPanel,

    /// <summary>
    /// 按钮
    /// </summary>
    PushButton,

    /// <summary>
    /// 下拉按钮
    /// </summary>
    PulldownButton,

    /// <summary>
    /// 下拉按钮
    /// </summary>
    SplitButton,

    /// <summary>
    /// 下拉框
    /// </summary>
    ComboBox,

    /// <summary>
    /// 分割线
    /// </summary>
    Separator
}
