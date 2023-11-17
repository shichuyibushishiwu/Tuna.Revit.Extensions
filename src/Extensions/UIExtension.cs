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
    /// <summary>
    /// Create ribbon push button
    /// </summary>
    /// <typeparam name="T">IExternalCommand</typeparam>
    /// <param name="panel"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static RibbonPanel CreatePushButton<T>(this RibbonPanel panel, Action<PushButtonData> action) where T : class, IExternalCommand, new()
    {
        ArgumentNullExceptionUtils.ThrowIfNull(panel);
        ArgumentNullExceptionUtils.ThrowIfNull(action);


        Type commandType = typeof(T);
        string name = commandType.Name;
        PushButtonData pushButtonData = new PushButtonData($"btn_{name}", name, commandType.Assembly.Location, commandType.FullName);
        action.Invoke(pushButtonData);
        panel.AddItem(pushButtonData);
        return panel;
    }

    /// <summary>
    /// Create a revit ribbon push button
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <returns></returns>
    private static PushButtonData CreatePushButton<TCommand>() where TCommand : class, IExternalCommand, IRibbonButton, new()
    {
        IRibbonButton button = Activator.CreateInstance<TCommand>();
        Type commandType = typeof(TCommand);
        PushButtonData pushButtonData = new PushButtonData($"btn_{commandType.Name}", button.Text, commandType.Assembly.Location, commandType.FullName)
        {
            Image = button.Image.ConvertToBitmapSource(),
            LargeImage = button.LargeImage.ConvertToBitmapSource(),
            ToolTipImage = button.ToolTipImage.ConvertToBitmapSource(),
            ToolTip = button.ToolTip,
            LongDescription = button.LongDescription,
        };
        pushButtonData.SetContextualHelp(button.ContextualHelp);
        //pushButtonData.SetAvailability(commandType);
        return pushButtonData;
    }

    /// <summary>
    /// Create a revit ribbon push button
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <param name="panel"></param>
    /// <returns></returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static PushButton CreatePushButton<TCommand>(this RibbonPanel panel) where TCommand : class, IExternalCommand, IRibbonButton, new()
    {
        ArgumentNullExceptionUtils.ThrowIfNull(panel);
        return panel.AddItem(CreatePushButton<TCommand>()) as PushButton;
    }

    /// <summary>
    /// Create a revit ribbon push button
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <param name="pulldownButton"></param>
    /// <returns></returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static PushButton CreatePushButton<TCommand>(this PulldownButton pulldownButton) where TCommand : class, IExternalCommand, IRibbonButton, new()
    {
        ArgumentNullExceptionUtils.ThrowIfNull(pulldownButton);
        return pulldownButton.AddPushButton(CreatePushButton<TCommand>());
    }

    /// <summary>
    /// Create a revit ribbon push button
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <param name="splitButton"></param>
    /// <returns></returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static PushButton CreatePushButton<TCommand>(this SplitButton splitButton) where TCommand : class, IExternalCommand, IExternalCommandAvailability, IRibbonButton, new()
    {
        ArgumentNullExceptionUtils.ThrowIfNull(splitButton);
        return splitButton.AddPushButton(CreatePushButton<TCommand>());
    }





    public static void CreateRibbonTab(this UIControlledApplication application, string name,Action<IRibbonTab> action)
    {
        application.CreateRibbonTab(name);
        action.Invoke(new RibbonTab()
        {

        });
    }


}
