using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Ribbon.Abstraction;

/// <summary>
/// 下拉按钮
/// </summary>
public interface IRibbonPulldownButton : IRibbonItem, IRibbonItemsCollector
{
    /// <summary>
    /// 按钮按钮
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    IRibbonPulldownButton AddPushButton<TCommand>() where TCommand : class, IExternalCommand, new();

    /// <summary>
    /// 添加分割线
    /// </summary>
    IRibbonPulldownButton AddSeparator();

    /// <summary>
    /// 配置按钮信息
    /// </summary>
    /// <param name="config"></param>
    IRibbonPulldownButton Configurate(Action<RibbonButtonData> config);
}
