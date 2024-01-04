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

    public IRibbonSplitButton AddPushButton<T>() where T : class, IExternalCommand, new()
    {
        RibbonButton ribbonButton = this.OriginalObject.CreatePushButton<T>();

        RibbonButtonProxy ribbonButtonProxy = new()
        {
            OriginalObject = ribbonButton,
            Title = ribbonButton.Name,
        };

        _items.Add(ribbonButtonProxy);

        return this;
    }
}
