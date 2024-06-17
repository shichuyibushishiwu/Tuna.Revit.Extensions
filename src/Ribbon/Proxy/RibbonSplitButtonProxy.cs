using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Ribbon.Proxy;

internal class RibbonSplitButtonProxy : RibbonElementProxy<SplitButton>, IRibbonSplitButton
{
    private List<IRibbonItem> _items = new();

    public string Name { get; set; }

    public RibbonItemType Type => RibbonItemType.SplitButton;

    public IRibbonSplitButton AddSeparator()
    {
        this.OriginalObject.AddSeparator();
        return this;
    }

    public IEnumerable<IRibbonItem> GetItems() => _items;

    public IRibbonSplitButton AddPushButton<T>(Action<RibbonButtonData> handle = null) where T : class, IExternalCommand, new()
    {
        RibbonButtonProxy ribbonButtonProxy = new();
        handle?.Invoke(ribbonButtonProxy.RibbonButtonData);

        RibbonButton ribbonButton = this.OriginalObject.CreatePushButton<T>(btn => UIExtension.SetPushButtonData(btn, ribbonButtonProxy.RibbonButtonData));


        ribbonButtonProxy.OriginalObject = ribbonButton;
        ribbonButtonProxy.Title = ribbonButton.Name;
        ribbonButtonProxy.Name = ribbonButton.Name;

        _items.Add(ribbonButtonProxy);

        return this;
    }
}
