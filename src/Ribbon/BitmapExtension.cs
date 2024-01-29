/************************************************************************************
   Author:十五
   CretaeTime:2023/2/26 22:57:40
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Tuna.Revit.Extension;

/// <summary>
/// system bitmap extension
/// </summary>
public static class BitmapExtension
{
    /// <summary>
    /// 将 <see cref="System.Drawing.Bitmap"/> 转换为 <see cref="BitmapSource"/>
    /// <para>Convert <see cref="System.Drawing.Bitmap"/> to <see cref="BitmapSource"/></para>
    /// </summary>
    /// <param name="bitmap"><see cref="System.Drawing.Bitmap"/></param>
    /// <returns><see cref="BitmapSource"/></returns>
    public static BitmapSource ConvertToBitmapSource(this System.Drawing.Bitmap bitmap)
    {
        ArgumentNullExceptionUtils.ThrowIfNull(bitmap);
        BitmapImage bitmapImage = new();
        using (MemoryStream stream = new())
        {
            bitmap.Save(stream, ImageFormat.Png);

            bitmapImage.BeginInit();
            bitmapImage.StreamSource = stream;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            bitmapImage.Freeze();
        }
        return bitmapImage;
    }
}