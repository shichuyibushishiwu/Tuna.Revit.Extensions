using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Ribbon.Abstraction;

/// <summary>
/// 定义按钮的容器
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRibbonPushButtonContainer<T>: IRibbonItem, IRibbonItemsCollector where T : class
{
    /// <summary>
    /// 添加按钮
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    T AddPushButton<TCommand>(Action<RibbonButtonData> handle = null) where TCommand : class, IExternalCommand, new();

    /// <summary>
    /// 添加分割线
    /// </summary>
    T AddSeparator();
}
