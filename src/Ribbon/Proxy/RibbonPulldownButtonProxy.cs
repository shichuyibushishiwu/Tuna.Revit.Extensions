using Autodesk.Revit.UI;
using System.Collections.Generic;
using Tuna.Revit.Extension.Ribbon.Abstraction;

namespace Tuna.Revit.Extension.Ribbon.Proxy;

internal class RibbonPulldownButtonProxy : RibbonElementProxy<PulldownButton>, IRibbonPulldownButton
{
    private readonly List<IRibbonItem> _items = new();

    public RibbonItemType Type => RibbonItemType.PulldownButton;

    public IRibbonPulldownButton AddPushButton<TCommand>() where TCommand : class, IExternalCommand, new()
    {
        RibbonButton ribbonButton = this.OriginalObject.CreatePushButton<TCommand>();

        RibbonButtonProxy ribbonButtonProxy = new()
        {
            OriginalObject = ribbonButton,
            Title = ribbonButton.Name,
        };

        _items.Add(ribbonButtonProxy);

        return this;
    }

    public string Text { get; set; }

    public string Name => Text;

    public IEnumerable<IRibbonItem> GetItems() => _items;

    public IRibbonPulldownButton AddSeparator()
    {
        this.OriginalObject.AddSeparator();
        
        return this;
    }
}
