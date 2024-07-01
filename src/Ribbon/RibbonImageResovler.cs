/************************************************************************************
   Author:十五
   CretaeTime:2022/4/20 13:16:40
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

    功能：对于图标的自动解析

        > 默认可以解析路径、位图和图片资源；

        > 对于路径的解析：
            - 如果用户给的是绝对路径指向资源位置，则直接返回资源对象
            - 如果用户给的是相对路径，则默认按照在启动文件的相对路径 [/Assets/Icon/] 文件下进行读取
            - 如果用户通过 [.Addin] 进行配置(指定的属性为Resource) 则相对路径修改为用户指定的路径
        

************************************************************************************/

using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Tuna.Revit.Extension;

internal class RibbonImageResovler
{
    public static ImageSource Resolve(object source)
    {
        switch (source)
        {
            case string path:
                if (File.Exists(path))
                {
                    return new BitmapImage(new Uri(path));
                }
                else
                {
                    if (RibbonHost.Default.IsVaild)
                    {
                        path = $"{RibbonHost.Default.InstallPath}//{path}";
                        if (File.Exists(path))
                        {
                            return new BitmapImage(new Uri(path));
                        }
                    }
                }
                return default;
            case Bitmap bitmap: return bitmap.ConvertToBitmapSource();
            case ImageSource imageSource: return imageSource;
            default: return default;
        }
    }
}
