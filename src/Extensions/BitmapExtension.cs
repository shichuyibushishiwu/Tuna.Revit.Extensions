///************************************************************************************
///   Author:十五
///   CretaeTime:2023/2/26 22:57:40
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Tuna.Revit.Extension
{
    /// <summary>
    /// system bitmap extension
    /// </summary>
    public static class BitmapExtension
    {
        /// <summary>
        /// Convert <see cref="System.Drawing.Bitmap"/> to <see cref="BitmapSource"/>
        /// </summary>
        /// <param name="bitmap"><see cref="System.Drawing.Bitmap"/></param>
        /// <returns><see cref="BitmapSource"/></returns>
        public static BitmapSource ConvertToBitmapSource(this System.Drawing.Bitmap bitmap)
        {
            ArgumentNullExceptionUtils.ThrowIfNull(bitmap);
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                bitmap.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
