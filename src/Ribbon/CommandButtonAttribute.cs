using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 按钮的属性
/// </summary>
public class CommandButtonAttribute : Attribute
{
    public string Name { get; set; }
}
