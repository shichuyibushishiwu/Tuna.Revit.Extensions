/************************************************************************************
   Author:十五
   CretaeTime:2022/4/20 13:16:40
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/


using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Tuna.Revit.Extension.Ribbon.Proxy;


namespace Tuna.Revit.Extension;

/// <summary>
/// Revit ribbon ui extensions
/// </summary>
public static class UIExtension
{
    internal static void SetPushButtonData(ButtonData buttonData, IRibbonButtonData buttonDataProxy)
    {
        if (!string.IsNullOrWhiteSpace(buttonDataProxy.Title) && !EqualityComparer<string>.Default.Equals(buttonData.Text, buttonDataProxy.Title))
        {
            buttonData.Text = buttonDataProxy.Title;
        }

        var image = RibbonImageResovler.Resolve(buttonDataProxy.Image);
        if (buttonDataProxy.Image != null && !EqualityComparer<ImageSource>.Default.Equals(buttonData.Image, image))
        {
            buttonData.Image = image;
        }

        var largeImage = RibbonImageResovler.Resolve(buttonDataProxy.LargeImage);
        if (buttonDataProxy.LargeImage != null && !EqualityComparer<ImageSource>.Default.Equals(buttonData.LargeImage, largeImage))
        {
            buttonData.LargeImage = largeImage;
        }

        var toolTipImage = RibbonImageResovler.Resolve(buttonDataProxy.ToolTipImage);
        if (toolTipImage != null && !EqualityComparer<ImageSource>.Default.Equals(buttonData.ToolTipImage, toolTipImage))
        {
            buttonData.ToolTipImage = toolTipImage;
        }

        if (buttonDataProxy.ToolTip != null && !EqualityComparer<string>.Default.Equals(buttonData.ToolTip, buttonDataProxy.ToolTip))
        {
            buttonData.ToolTip = buttonDataProxy.ToolTip;
        }

        if (buttonDataProxy.LongDescription != null && !EqualityComparer<string>.Default.Equals(buttonData.LongDescription, buttonDataProxy.LongDescription))
        {
            buttonData.LongDescription = buttonDataProxy.LongDescription;
        }

        ContextualHelp contextualHelp = buttonData.GetContextualHelp();
        if (buttonDataProxy.ContextualHelp != null && !EqualityComparer<ContextualHelp>.Default.Equals(contextualHelp, buttonDataProxy.ContextualHelp))
        {
            buttonData.SetContextualHelp(buttonDataProxy.ContextualHelp);
        }
    }

    static PushButtonData CreatePushButtonData<T>(Action<PushButtonData> handle = null) where T : class, IExternalCommand, new()
        => RibbonButtonDescriptor.CreateRibbonButtonDescriptor(handle, typeof(T)).PushButtonData;

    /// <summary>
    /// 在面板上创建一个按钮
    /// <para>Create a ribbon push button on the panel</para>
    /// </summary>
    /// <typeparam name="T">外部命令，必须是一个自定义类型，且继承于<see cref="Autodesk.Revit.UI.IExternalCommand"/>,且必须存在一个无参的构造函数</typeparam>
    /// <param name="panel">要添加按钮的面板</param>
    /// <param name="handle">对按钮的参数进行赋值</param>
    /// <returns>创建的按钮</returns>
    public static PushButton CreatePushButton<T>(this RibbonPanel panel, Action<PushButtonData> handle = null) where T : class, IExternalCommand, new()
    {
        ArgumentNullExceptionUtils.ThrowIfNull(panel);

        RevitApplicationContext.Instance.Assembly = Assembly.GetCallingAssembly();
      
        return panel.AddItem(CreatePushButtonData<T>(handle)) as PushButton;
    }

    /// <summary>
    /// 在面板上创建一个下拉按钮
    /// </summary>
    /// <param name="panel"></param>
    /// <param name="name"></param>
    /// <param name="text"></param>
    /// <param name="handle"></param>
    /// <returns></returns>
    public static PulldownButton CreatePulldownButton(this RibbonPanel panel, string name, string text, Action<PulldownButtonData> handle = null)
    {
        ArgumentNullExceptionUtils.ThrowIfNull(panel);

        PulldownButtonData data = new(name, text);

        handle?.Invoke(data);

        RevitApplicationContext.Instance.Assembly = Assembly.GetCallingAssembly();

        return panel.AddItem(data) as PulldownButton;
    }

    /// <summary>
    /// 在面板上创建一个下拉式按钮
    /// </summary>
    /// <param name="panel"></param>
    /// <param name="name"></param>
    /// <param name="text"></param>
    /// <param name="handle"></param>
    /// <returns></returns>
    public static SplitButton CreateSplitButton(this RibbonPanel panel, string name, string text, Action<SplitButtonData> handle = null)
    {
        ArgumentNullExceptionUtils.ThrowIfNull(panel);

        SplitButtonData data = new(name, text);

        handle?.Invoke(data);

        RevitApplicationContext.Instance.Assembly = Assembly.GetCallingAssembly();

        return panel.AddItem(data) as SplitButton;
    }

    /// <summary>
    /// 在面板上创建一个下拉框
    /// </summary>
    /// <param name="panel"></param>
    /// <param name="name"></param>
    /// <param name="handle"></param>
    /// <returns></returns>
    public static ComboBox CreateComboBox(this RibbonPanel panel, string name, Action<ComboBoxData> handle = null)
    {
        RevitApplicationContext.Instance.Assembly = Assembly.GetCallingAssembly();
        return InternalCreateComboBox(panel, name, handle);
    }

    internal static ComboBox InternalCreateComboBox(this RibbonPanel panel, string name, Action<ComboBoxData> handle = null)
    {
        ArgumentNullExceptionUtils.ThrowIfNull(panel);

        ComboBoxData combo = new(name);

        handle?.Invoke(combo);

        return panel.AddItem(combo) as ComboBox;
    }


    /// <summary>
    /// 创建按压式按钮
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="pulldownButton"></param>
    /// <param name="handle"></param>
    /// <returns></returns>
    public static PushButton CreatePushButton<T>(this PulldownButton pulldownButton, Action<PushButtonData> handle = null) where T : class, IExternalCommand, new()
    {
        RevitApplicationContext.Instance.Assembly = Assembly.GetCallingAssembly();

        return CreatePushButton(pulldownButton, typeof(T), handle);
    }

    /// <summary>
    /// 创建按压式按钮
    /// </summary>
    /// <param name="pulldownButton"></param>
    /// <param name="type"></param>
    /// <param name="handle"></param>
    /// <returns></returns>
    internal static PushButton CreatePushButton(this PulldownButton pulldownButton, Type type, Action<PushButtonData> handle = null)
    {
        ArgumentNullExceptionUtils.ThrowIfNull(pulldownButton);

        RibbonButtonDescriptor descriptor = RibbonButtonDescriptor.CreateRibbonButtonDescriptor(handle, type);

        return pulldownButton.AddPushButton(descriptor.PushButtonData);
    }
}
