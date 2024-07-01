using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tuna.Revit.Extension.Ribbon.Proxy;

internal class RibbonButtonProxy : RibbonElementProxy<RibbonButton>, IRibbonButton
{
    public RibbonButtonProxy() => RibbonButtonData = new RibbonButtonData();

    public RibbonButtonData RibbonButtonData { get; set; }

    public RibbonItemType Type => RibbonItemType.PushButton;

    public string Name { get; set; }

    public void Configurate(Action<RibbonButtonData> config)
    {
        config?.Invoke(RibbonButtonData);
    }

    public static implicit operator RibbonButton(RibbonButtonProxy ribbonButton)
    {
        return ribbonButton.OriginalObject;
    }
}
