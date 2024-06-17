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
            var tab = application.AddRibbonTab("tuna")
            .AddRibbonPanel("archi", panel =>
            {
                panel.AddPushButton<Commands.CommandA>()
                .AddSeparator()
                .AddPulldownButton("pdb", pbt => pbt
                    .AddPushButton<Commands.CommandA>()
                    .AddSeparator()
                    .AddPushButton<Commands.CommandB>()
                    .Configurate(d =>
                    {
                        d.LargeImage = "compass.png";
                    }))
                .AddSplitButton("stb", slt => slt
                    .AddPushButton<Commands.CommandA>()
                    .AddSeparator()
                    .AddPushButton<Commands.CommandB>())
                .AddComboBox("s", cb => cb.AddItem("dd").AddItem("ssad").OnSelectedChanged(e =>
                {

                }))
                .AddSlideOut();
            });

            return Result.Succeeded;
        }
    }
}
