///************************************************************************************
///   Author:十五
///   CretaeTime:2023/2/26 23:10:54
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************

using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Interfaces
{
    /// <summary>
    /// Revit ribbon ui push button information
    /// </summary>
    public interface IRibbonButton
    {
        /// <summary>
        /// Ribbon button text
        /// </summary>
        string Text { get; }

        /// <summary>
        /// Ribbon button long description
        /// </summary>
        string LongDescription { get; }

        /// <summary>
        /// Ribbon button tool tip
        /// </summary>
        string ToolTip { get; }

        /// <summary>
        /// Ribbon button small image what size is 16px * 16px
        /// </summary>
        Bitmap Image { get; }

        /// <summary>
        /// Ribbon button large image what size is 32px * 32px
        /// </summary>
        Bitmap LargeImage { get; }

        /// <summary>
        /// Ribbon button tool tip image
        /// </summary>
        Bitmap ToolTipImage { get; }

        /// <summary>
        /// Ribbon button contextual help
        /// </summary>
        ContextualHelp ContextualHelp { get; }
    }
}
