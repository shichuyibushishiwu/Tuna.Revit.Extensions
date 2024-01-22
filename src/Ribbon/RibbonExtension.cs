using Autodesk.Revit.UI;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
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
    /// <param name="title"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static IRibbonTab AddRibbonTab(this UIControlledApplication application, string title, Action<IRibbonTab> action)
    {
        RibbonHost.Defualt.Assembly = Assembly.GetCallingAssembly();


        var app = (typeof(UIControlledApplication)
            .GetMethod("getUIApplication", BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(application, new object[0]) as UIApplication) ?? throw new ArgumentNullException("app reflection error");

        return app.AddRibbonTab(title, action);
    }


    /// <summary>
    /// 创建Tab
    /// </summary>
    /// <param name="application"></param>
    /// <param name="title"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static IRibbonTab AddRibbonTab(this UIApplication application, string title, Action<IRibbonTab> action)
    {
        application.CreateRibbonTab(title);

        RibbonTabProxy tab = new()
        {
            Application = application,
            Title = title,
        };

        action?.Invoke(tab);
        return tab;
    }

    /// <summary>
    /// 创建面板
    /// </summary>
    /// <param name="tab"></param>
    /// <param name="name"></param>
    /// <param name="handle"></param>
    /// <returns></returns>
    public static IRibbonTab AddRibbonPanel(this IRibbonTab tab, string name, Action<IRibbonPanel> handle)
    {
        IRibbonPanel ribbonPanel = tab.CreateRibbonPanel(name);
        handle?.Invoke(ribbonPanel);
        return tab;
    }
}
