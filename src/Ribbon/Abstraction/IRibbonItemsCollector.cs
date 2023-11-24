using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuna.Revit.Extension.Ribbon.Abstraction;
using Tuna.Revit.Extension.Ribbon.Proxy;

namespace Tuna.Revit.Extension;

internal interface IRibbonItemsCollector
{
    public IEnumerable<IRibbonItem> GetItems();
}
