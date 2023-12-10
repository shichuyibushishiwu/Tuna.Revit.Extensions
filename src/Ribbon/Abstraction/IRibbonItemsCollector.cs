using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuna.Revit.Extension.Ribbon.Proxy;

namespace Tuna.Revit.Extension;

/// <summary>
/// 具有元素的集合
/// </summary>
public interface IRibbonItemsCollector
{
    /// <summary>
    /// 获取对象下面的集合
    /// </summary>
    /// <returns></returns>
    public IEnumerable<IRibbonItem> GetItems();
}
