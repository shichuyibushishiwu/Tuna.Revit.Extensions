using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

internal class RibbonHost
{
    private Assembly _assembly;
    private bool _isValid;

    /// <summary>
    /// 默认值
    /// </summary>
    public static RibbonHost Default { get; } = new RibbonHost();

    RibbonHost() { }

    public Assembly Assembly
    {
        get => _assembly;
        internal set
        {
            if (value != null && _assembly != this.GetType().Assembly && _assembly != value)
            {
                _assembly = value;
                _isValid = true;
                InstallPath = $"{Directory.GetParent(_assembly?.Location).FullName}//Assets//Icon";
            }
        }
    }

    public UIControlledApplication UIControlledApplication { get; internal set; }

    public UIApplication UIApplication { get; internal set; }

    public bool IsVaild => _isValid;

    public string InstallPath { get; set; }
}
