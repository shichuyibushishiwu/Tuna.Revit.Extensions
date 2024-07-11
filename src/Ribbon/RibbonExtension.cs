using Autodesk.Revit.UI;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Tuna.Revit.Extension.Ribbon.Abstraction;
using Tuna.Revit.Extension.Ribbon.Proxy;
using static UIFramework.WorksharingNotificationWindow;

namespace Tuna.Revit.Extension;

/// <summary>
/// 对UI的扩展
/// </summary>
public static class RibbonExtension
{
    /// <summary>
    /// internal method info of <see cref="UIControlledApplication"/>
    /// </summary>
    private static readonly MethodInfo _getUIApplicationMethod = (typeof(UIControlledApplication)
              .GetMethod("getUIApplication", BindingFlags.Instance | BindingFlags.NonPublic));

    /// <summary>
    /// get the <see cref="Autodesk.Revit.UI.UIApplication" /> from <see cref="UIControlledApplication"/>
    /// </summary>
    /// <param name="application"></param>
    /// <returns></returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    private static UIApplication GetUIApplication(UIControlledApplication application)
    {
        return _getUIApplicationMethod.Invoke(application, new object[0]) as UIApplication ?? throw new ArgumentNullException("app reflection error");
    }

    /// <summary>
    /// 创建Tab
    /// </summary>
    /// <param name="application"></param>
    /// <param name="title"></param>
    private static IRibbonTab AddRibbonTab(this UIApplication application, string title)
    {
        application.CreateRibbonTab(title);
        return new RibbonTabProxy()
        {
            Application = application,
            Title = title,
        };
    }

    /// <summary>
    /// 创建Tab
    /// </summary>
    /// <param name="application"></param>
    /// <param name="title"></param>
    /// <param name="action"></param>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static void AddRibbonTab(this UIControlledApplication application, string title, Action<IRibbonTab> action)
    {
        RevitApplicationContext ribbonHost = RevitApplicationContext.Instance;
        ribbonHost.Assembly = Assembly.GetCallingAssembly();
        ribbonHost.UIApplication = GetUIApplication(application);
        ribbonHost.UIControlledApplication = application;
     
        IRibbonTab ribbonTab = ribbonHost.UIApplication.AddRibbonTab(title);
        action?.Invoke(ribbonTab);
    }

    /// <summary>
    /// 创建Tab
    /// </summary>
    /// <param name="application"></param>
    /// <param name="title"></param>
    public static IRibbonTab AddRibbonTab(this UIControlledApplication application, string title)
    {
        RevitApplicationContext ribbonHost = RevitApplicationContext.Instance;
        ribbonHost.Assembly = Assembly.GetCallingAssembly();
        ribbonHost.UIApplication = GetUIApplication(application);
        ribbonHost.UIControlledApplication = application;
      
        return ribbonHost.UIApplication.AddRibbonTab(title);
    }
}
