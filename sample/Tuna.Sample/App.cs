///************************************************************************************
///   Author:十五
///   CretaeTime:2023/1/27 11:21:43
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************

using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Tuna.Revit.Extension;

namespace Tuna.Sample
{
    internal class App : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            var tab = application.AddRibbonTab("tuna", tab => tab
            .AddRibbonPanel("archi", panel => panel
                .AddPushButton<Commands.ElementFilterCommand>()
                .AddSeparator()
                .AddPulldownButton("sd", pbt => pbt
                    .AddPushButton<Commands.ElementFilterCommand>()
                    .AddSeparator()
                    .AddPushButton<Commands.ExternalEventTestCommand>())
                .AddSplitButton("SD", slt => slt
                    .AddPushButton<Commands.ElementFilterCommand>()
                    .AddSeparator())
                .AddComboBox("s", cb => cb.AddItem("dd").AddItem("ssad"))));

            return Result.Succeeded;
        }
    }
}
