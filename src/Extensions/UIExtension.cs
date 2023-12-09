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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;


namespace Tuna.Revit.Extension;

/// <summary>
/// Revit ribbon ui extensions
/// </summary>
public static class UIExtension
{
    static PushButtonData CreatePushButtonData<T>(string text = null) where T : class, IExternalCommand, new()
    {
        //按钮的类型
        Type commandType = typeof(T);

        //按钮的名称
        string name = commandType.Name;

        //实例化一个按钮的数据
        PushButtonData pushButtonData = new($"btn_{name}", text ?? name, commandType.Assembly.Location, commandType.FullName);

        //如果命令实现了 IExternalCommandAvailability 接口
        if (typeof(IExternalCommandAvailability).IsAssignableFrom(commandType))
        {
            pushButtonData.AvailabilityClassName = commandType.FullName;
        }

        return pushButtonData;
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
        ArgumentNullExceptionUtils.ThrowIfNull(panel);

        ComboBoxData combo = new(name);
        handle?.Invoke(combo);
        return panel.AddItem(combo) as ComboBox;
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

        return panel.AddItem(data) as PulldownButton;
    }

    /// <summary>
    /// 在面板上创建一个按钮
    /// <para>Create a ribbon push button on the panel</para>
    /// </summary>
    /// <typeparam name="T">外部命令，必须是一个自定义类型，且继承于<see cref="Autodesk.Revit.UI.IExternalCommand"/>,且必须存在一个无参的构造函数</typeparam>
    /// <param name="panel">要添加按钮的面板</param>
    /// <param name="handle">对按钮的参数进行赋值</param>
    /// <returns>创建的按钮</returns>
    public static PushButton CreatePushButton<T>(this RibbonPanel panel, Action<PushButtonData> handle) where T : class, IExternalCommand, new()
    {
        ArgumentNullExceptionUtils.ThrowIfNull(panel);
        ArgumentNullExceptionUtils.ThrowIfNull(handle);

        PushButtonData pushButtonData = CreatePushButtonData<T>();
        handle.Invoke(pushButtonData);

        return panel.AddItem(pushButtonData) as PushButton;
    }


    static PushButtonData CreatePushButtonData<T>() where T : class, IExternalCommand, IRibbonButton, new()
    {
        //创建抽象按钮的实例
        IRibbonButton button = Activator.CreateInstance<T>();

        //实例化一个按钮的数据
        PushButtonData pushButtonData = CreatePushButtonData<T>(button.Text);

        //对参数进行赋值
        pushButtonData.Image = button.Image.ConvertToBitmapSource();
        pushButtonData.LargeImage = button.LargeImage.ConvertToBitmapSource();
        pushButtonData.ToolTipImage = button.ToolTipImage.ConvertToBitmapSource();
        pushButtonData.ToolTip = button.ToolTip;
        pushButtonData.LongDescription = button.LongDescription;
        pushButtonData.SetContextualHelp(button.ContextualHelp);

        return pushButtonData;
    }

    /// <summary>
    /// 在面板上创建一个按钮
    /// <para>Create a ribbon push button on the panel</para>
    /// </summary>
    /// <typeparam name="T">外部命令，必须是一个自定义类型，且继承于<see cref="Autodesk.Revit.UI.IExternalCommand"/> 和 <see cref="IRibbonButton"/>,且必须存在一个无参的构造函数</typeparam>
    /// <param name="panel">要添加按钮的面板</param>
    /// <returns>创建的按钮</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static PushButton CreatePushButton<T>(this RibbonPanel panel) where T : class, IExternalCommand, IRibbonButton, new()
    {
        ArgumentNullExceptionUtils.ThrowIfNull(panel);
        return panel.AddItem(CreatePushButtonData<T>()) as PushButton;
    }

    /// <summary>
    /// 在下拉按钮上创建一个按钮
    /// <para>Create a ribbon push button on the panel</para>
    /// </summary>
    /// <typeparam name="T">外部命令，必须是一个自定义类型，且继承于<see cref="Autodesk.Revit.UI.IExternalCommand"/> 和 <see cref="IRibbonButton"/>,且必须存在一个无参的构造函数</typeparam>
    /// <param name="pulldownButton">要添加按钮的下拉按钮</param>
    /// <returns>创建的按钮</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static PushButton CreatePushButton<T>(this PulldownButton pulldownButton) where T : class, IExternalCommand, IRibbonButton, new()
    {
        ArgumentNullExceptionUtils.ThrowIfNull(pulldownButton);
        return pulldownButton.AddPushButton(CreatePushButtonData<T>());
    }

    /// <summary>
    /// 在下拉按钮上创建一个按钮
    /// <para>Create a ribbon push button on the panel</para>
    /// </summary>
    /// <typeparam name="T">外部命令，必须是一个自定义类型，且继承于<see cref="Autodesk.Revit.UI.IExternalCommand"/> 和 <see cref="IRibbonButton"/>,且必须存在一个无参的构造函数</typeparam>
    /// <param name="splitButton">要添加按钮的下拉按钮</param>
    /// <returns>创建的按钮</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static PushButton CreatePushButton<T>(this SplitButton splitButton) where T : class, IExternalCommand, IRibbonButton, new()
    {
        ArgumentNullExceptionUtils.ThrowIfNull(splitButton);
        return splitButton.AddPushButton(CreatePushButtonData<T>());
    }
}
