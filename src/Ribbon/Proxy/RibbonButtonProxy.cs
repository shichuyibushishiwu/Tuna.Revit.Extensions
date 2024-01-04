using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tuna.Revit.Extension.Ribbon.Proxy;

internal class RibbonButtonProxy : RibbonElementProxy<RibbonButton>, IRibbonButton
{
    public RibbonItemType Type => RibbonItemType.PushButton;

    public string Name { get; set; }
}
