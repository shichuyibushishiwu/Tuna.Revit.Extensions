using Autodesk.Revit.UI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 
/// </summary>
public interface IRibbonComboBox : IRibbonItem
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    IRibbonComboBox AddItem(string title);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="titles"></param>
    /// <returns></returns>
    IRibbonComboBox AddItems(params string[] titles);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IRibbonComboBox AddSeparator();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="handle"></param>
    void OnSelectedChanged(Action<ComboBoxCurrentChangedEventArgs> handle);
}
