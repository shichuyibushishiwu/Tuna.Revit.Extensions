using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

internal interface IRibbonStackedPanel
{
    public void AddPushButton<TComandA, TCommandB, TCommandC>();

    public void AddPushButton<TComandA, TCommandB>();
}
