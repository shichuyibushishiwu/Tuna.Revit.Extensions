﻿using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// <param name="title"></param>
    /// <param name="action"></param>
    public static IRibbonTab AddRibbonTab(this UIControlledApplication application, string title, Action<IRibbonTab> action)
    {
        var app = (typeof(UIControlledApplication)
            .GetMethod("getUIApplication", BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(application, Array.Empty<object>()) as UIApplication) ?? throw new ArgumentNullException("app");
        return app.AddRibbonTab(title, action);
    }

    /// <summary>
    /// 创建Tab
    /// </summary>
    /// <param name="application"></param>
    /// <param name="title"></param>
    /// <param name="action"></param>
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