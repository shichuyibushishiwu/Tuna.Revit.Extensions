using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tuna.Revit.Extension.Ribbon.Abstraction;
using Tuna.Revit.Extension.Ribbon.Proxy;

namespace Tuna.Revit.Extension;

/// <summary>
/// 对UI的扩展
/// </summary>
public static class RibbonExtension
{
    /// <summary>
    /// 创建Tab
    /// </summary>
    /// <param name="application"></param>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public static void CreateRibbonTab(this UIControlledApplication application, string name, Action<IRibbonTab> action)
    {
        application.CreateRibbonTab(name);
        action.Invoke(new RibbonTabProxy()
        {
            Application = application,
            TabName = name,
        });
    }

    /// <summary>
    /// 创建面板
    /// </summary>
    /// <param name="tab"></param>
    /// <param name="name"></param>
    /// <param name="handle"></param>
    /// <returns></returns>
    public static IRibbonTab CreateRibbonPanel(this IRibbonTab tab, string name, Action<IRibbonPanel> handle)
    {
        IRibbonPanel ribbonPanel = tab.CreateRibbonPanel(name);
        handle?.Invoke(ribbonPanel);
        return tab;
    }


    public static IRibbonPanel AddComboBox(this IRibbonPanel ribbonPanel)
    {
        return ribbonPanel;
    }

    public static IRibbonPanel AddTextBox(this IRibbonPanel ribbonPanel)
    {
        return ribbonPanel;
    }

    public static IRibbonPanel AddPulldownButton(this IRibbonPanel ribbonPanel,Action<IRibbonPulldownButton> handle)
    {
    
        return ribbonPanel;
    }

 

    public static IRibbonPanel AddSplitButton(this IRibbonPanel ribbonPanel)
    {
        return ribbonPanel;
    }

    public static IRibbonPanel AddPushButton<TCommand>(this IRibbonPanel ribbonPanel) where TCommand : class, IExternalCommand, IRibbonButton, new()
    {
        ribbonPanel.AddPushButton<TCommand>();
        return ribbonPanel;
    }

    /// <summary>
    /// 添加分割线
    /// </summary>
    /// <param name="ribbonPanel"></param>
    /// <returns></returns>
    public static IRibbonPanel AddSeparator(this IRibbonPanel ribbonPanel)
    {
        ribbonPanel.AddSeparator();
        return ribbonPanel;
    }

    /// <summary>
    /// 添加滑动式抽屉
    /// </summary>
    /// <param name="ribbonPanel"></param>
    /// <param name="handle"></param>
    public static void AddSlideOut(this IRibbonPanel ribbonPanel, Action<IRibbonPanel> handle)
    {
        ribbonPanel.AddSlideOut();
        handle?.Invoke(ribbonPanel);
    }
}
