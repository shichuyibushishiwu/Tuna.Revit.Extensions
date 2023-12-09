using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Ribbon.Abstraction;

public interface IRibbonPulldownButton : IRibbonItem, IRibbonItemsCollector
{
    void AddPushButton<TCommand>() where TCommand : class, IExternalCommand, IRibbonButton, new();
}
