///************************************************************************************
///   Author:十五
///   CretaeTime:2022/4/20 13:16:40
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************


using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Tuna.Revit.Extension
{
    public static class UIExtension
    {
        public static RibbonPanel CreateButton<T>(this RibbonPanel panel, Action<PushButtonData> action)
        {
            Type type = typeof(T);
            string name = $"btn_{type.Name}";
            PushButtonData pushButtonData = new PushButtonData(name, name, type.Assembly.Location, type.FullName);
            action.Invoke(pushButtonData);
            panel.AddItem(pushButtonData);
            return panel;
        }

        public static BitmapSource ConvertToBitmapSource(this System.Drawing.Bitmap bitmap)
        {
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                bitmap.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
