using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 下拉按钮
/// </summary>
public interface IRibbonSplitButton : IRibbonItem, IRibbonItemsCollector
{
    /// <summary>
    /// 添加按钮
    /// </summary>
    /// <returns></returns>
    IRibbonSplitButton AddPushButton<T>() where T : class, IExternalCommand, new();

    /// <summary>
    /// 添加分割线
    /// </summary>
    /// <returns></returns>
    IRibbonSplitButton AddSeparator();
}
