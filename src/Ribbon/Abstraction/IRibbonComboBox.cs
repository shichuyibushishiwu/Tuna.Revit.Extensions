using Autodesk.Revit.UI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 下拉选项
/// </summary>
public interface IRibbonComboBox : IRibbonItem
{
    /// <summary>
    /// 添加成员
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    IRibbonComboBox AddItem(string title);

    /// <summary>
    /// 添加多个成员
    /// </summary>
    /// <param name="titles"></param>
    /// <returns></returns>
    IRibbonComboBox AddItems(params string[] titles);

    /// <summary>
    /// 添加分割线
    /// </summary>
    /// <returns></returns>
    IRibbonComboBox AddSeparator();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="handle"></param>
    void OnSelectedChanged(Action<ComboBoxCurrentChangedEventArgs> handle);
}
