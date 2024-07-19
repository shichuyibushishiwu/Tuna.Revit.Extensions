using Autodesk.Revit.UI;
using Autodesk.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuna.Revit.Extension.Ribbon.Abstraction;

namespace Tuna.Revit.Extension;

/// <summary>
/// 功能面板
/// </summary>
public interface IRibbonPanel : IRibbonPushButtonContainer<IRibbonPanel>
{
    /// <summary>
    /// 面板的标题
    /// </summary>
    string Title { get; }

    /// <summary>
    /// 添加滑动式抽屉
    /// </summary>
    void AddSlideOut();

    /// <summary>
    /// 添加下拉按钮
    /// </summary>
    /// <param name="title"></param>
    /// <param name="handle"></param>
    /// <returns>当前面板</returns>
    IRibbonPanel AddPulldownButton(string title, Action<IRibbonPulldownButton> handle = null);

    /// <summary>
    /// 添加下拉按钮
    /// </summary>
    /// <param name="title"></param>
    /// <param name="handle"></param>
    /// <returns>当前面板</returns>
    IRibbonPanel AddSplitButton(string title, Action<IRibbonSplitButton> handle = null);

    /// <summary>
    /// 添加堆叠式按钮
    /// </summary>
    /// <returns>当前面板</returns>
    //IRibbonPanel AddStackPanel(Action<IRibbonStackedPanel> handle = null);

    /// <summary>
    /// 添加单选框按钮组
    /// </summary>
    /// <returns>当前面板</returns>
    IRibbonPanel AddRadioButtonGroup();

    /// <summary>
    /// 添加文本输入框
    /// </summary>
    /// <returns>当前面板</returns>
    IRibbonPanel AddTextBox();

    /// <summary>
    /// 添加下拉框
    /// </summary>
    /// <returns>当前面板</returns>
    IRibbonPanel AddComboBox(string name, Action<IRibbonComboBox> handle = null);
}
