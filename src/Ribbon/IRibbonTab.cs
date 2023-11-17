using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

public interface IRibbonTab
{
    string TabName { get; }

    void CreateRibbonPanel(string name, Action<IRibbonPanel> action);
}
