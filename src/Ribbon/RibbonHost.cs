using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

internal class RibbonHost
{
    public static RibbonHost Defualt { get; } = new RibbonHost();

    RibbonHost() { }

    public Assembly Assembly { get; set; }
}
