using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

internal class RibbonTab : IRibbonTab
{
    public string TabName { get; internal set; }

    public void CreateRibbonPanel(string name, Action<IRibbonPanel> action)
    {
        throw new NotImplementedException();
    }
}
