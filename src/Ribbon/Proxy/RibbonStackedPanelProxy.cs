using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Ribbon.Proxy;

internal class RibbonStackedPanelProxy : IRibbonStackedPanel, IRibbonItem
{
    public string Name => throw new NotImplementedException();

    public RibbonItemType Type => throw new NotImplementedException();

    public void AddPushButton<TComandA, TCommandB, TCommandC>()
    {
        throw new NotImplementedException();
    }

    public void AddPushButton<TComandA, TCommandB>()
    {
        throw new NotImplementedException();
    }
}
