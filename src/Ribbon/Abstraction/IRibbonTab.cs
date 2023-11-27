using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 
/// </summary>
public interface IRibbonTab
{
    /// <summary>
    /// 
    /// </summary>
    string TabName { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    IRibbonPanel CreateRibbonPanel(string name);
}
