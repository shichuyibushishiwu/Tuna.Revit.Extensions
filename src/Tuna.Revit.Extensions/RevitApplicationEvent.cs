using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extensions;

/// <summary>
/// Revit application events
/// </summary>
public abstract class RevitApplicationEvent
{
    private readonly UIControlledApplication _application;

    /// <summary>
    /// Initialize revit application event
    /// </summary>
    /// <param name="uIControlledApplication"></param>
    public RevitApplicationEvent(UIControlledApplication uIControlledApplication)
    {
        _application = uIControlledApplication;
        uIControlledApplication.ApplicationClosing += UIControlledApplication_ApplicationClosing;
        uIControlledApplication.ControlledApplication.ApplicationInitialized += ControlledApplication_ApplicationInitialized;
    }

    /// <summary>
    /// 当应用程序进行初始化的时候
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ControlledApplication_ApplicationInitialized(object? sender, Autodesk.Revit.DB.Events.ApplicationInitializedEventArgs e)
    {
        OnApplicationInitialized(sender, e);

#if !Rvt_23_Before
        _application.SelectionChanged += UIControlledApplication_SelectionChanged;
#endif

#if !Rvt_24_Before
        _application.ThemeChanged += UIControlledApplication_ThemeChanged;
#endif
    }

    /// <summary>
    /// 当应用程序即将关闭的时候
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void UIControlledApplication_ApplicationClosing(object? sender, Autodesk.Revit.UI.Events.ApplicationClosingEventArgs e)
    {
        OnApplicationClosing(sender, e);
        _application.ApplicationClosing -= UIControlledApplication_ApplicationClosing;
        _application.ControlledApplication.ApplicationInitialized -= ControlledApplication_ApplicationInitialized;

#if !Rvt_23_Before
        _application.SelectionChanged -= UIControlledApplication_SelectionChanged;
#endif

#if !Rvt_24_Before
        _application.ThemeChanged -= UIControlledApplication_ThemeChanged;
#endif
    }

#if !Rvt_24_Before
    private void UIControlledApplication_ThemeChanged(object? sender, Autodesk.Revit.UI.Events.ThemeChangedEventArgs e)
    {
        OnThemeChanged(sender);
    }
#endif

#if !Rvt_23_Before
    private void UIControlledApplication_SelectionChanged(object? sender, Autodesk.Revit.UI.Events.SelectionChangedEventArgs e)
    {
        OnApplicationSelectionChanged(sender, new SelectionChangedEventArgs(e));
    }
#endif

    /// <summary>
    /// 当应用初始化后触发的事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnApplicationInitialized(object sender, Autodesk.Revit.DB.Events.ApplicationInitializedEventArgs e) { }

    /// <summary>
    /// 当应用关闭时触发的事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnApplicationClosing(object sender, Autodesk.Revit.UI.Events.ApplicationClosingEventArgs e) { }

    /// <summary>
    /// 当主题改变触发的事件
    /// </summary>
    /// <remarks>
    /// 仅适用于 Revit 2024 以上的版本
    /// <para>Only Revit 2024</para>
    /// </remarks>
    /// <param name="sender"></param>
    protected virtual void OnThemeChanged(object sender) { }

    /// <summary>
    /// 当应用程序的选择对象变更后触发的事件
    /// </summary>
    /// <remarks>仅适用于 Revti 2023 以上的版本</remarks>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnApplicationSelectionChanged(object sender, SelectionChangedEventArgs e) { }
}
