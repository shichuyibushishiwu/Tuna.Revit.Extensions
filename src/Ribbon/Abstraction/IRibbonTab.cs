using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 定义选项卡的接口
/// </summary>
public interface IRibbonTab : IRibbonItemsCollector
{
    /// <summary>
    /// 选项卡名称
    /// </summary>
    string Title { get; }

    /// <summary>
    /// 在选项卡上创建面板
    /// <para>Create a <see cref="IRibbonPanel"/> on the <see cref="IRibbonTab"/></para>
    /// </summary>
    /// <param name="title">面板的标题</param>
    /// <param name="handle">添加面板的元素</param>
    IRibbonPanel AddRibbonPanel(string title, Action<IRibbonPanel> handle);

    /// <summary>
    /// 获取面板
    /// </summary>
    /// <returns></returns>
    List<RibbonPanel> GetRibbonPanels();
}
