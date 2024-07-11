using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 应用程序上下文
/// </summary>
public class RevitApplicationContext
{
    private Assembly _assembly;
    private bool _isValid;

    /// <summary>
    /// 默认值
    /// </summary>
    public static RevitApplicationContext Instance { get; } = new RevitApplicationContext();

    RevitApplicationContext() { }

    /// <summary>
    /// 当前加载的插件的程序集
    /// </summary>
    public Assembly Assembly
    {
        get => _assembly;
        internal set
        {
            if (value != null && _assembly != this.GetType().Assembly && _assembly != value)
            {
                _assembly = value;
                _isValid = true;
                InstallPath = @$"{Directory.GetParent(_assembly?.Location).FullName}\Assets\Icon";
            }
        }
    }

    /// <summary>
    /// Revit <see cref="Autodesk.Revit.UI.UIControlledApplication"/> 实例
    /// </summary>
    public UIControlledApplication UIControlledApplication { get; internal set; }

    /// <summary>
    /// Revit <see cref="Autodesk.Revit.UI.UIApplication"/> 实例
    /// </summary>
    public UIApplication UIApplication { get; internal set; }

    /// <summary>
    /// 上下文是否有效
    /// </summary>
    public bool IsVaild => _isValid;

    /// <summary>
    /// 当前加载的插件的安装位置
    /// </summary>
    public string InstallPath { get; set; }
}
