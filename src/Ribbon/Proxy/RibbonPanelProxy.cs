using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Ribbon.Proxy;

internal class RibbonPanelProxy : RibbonElementProxy<RibbonPanel>, IRibbonPanel, IRibbonItemsCollector
{
    private readonly List<IRibbonItem> _items = new List<IRibbonItem>();

    public RibbonTabProxy Parent { get; internal set; }

    public void AddSlideOut() => OriginalObject.AddSlideOut();

    public void AddSeparator() => OriginalObject.AddSeparator();

    public void AddPushButton<TCommand>() where TCommand : class, IExternalCommand, IRibbonButton, new()
    {
        RibbonButton ribbonButton = this.OriginalObject.CreatePushButton<TCommand>();
        RibbonButtonProxy ribbonButtonProxy = new RibbonButtonProxy()
        {
            OriginalObject = ribbonButton,
            Name = ribbonButton.Name,
        };
        _items.Add(ribbonButtonProxy);
    }

    public void AddComboBox()
    {

    }

    public void CreatePulldownButton()
    {


    }

    public void CreatePushButton<TCommand>() where TCommand : IExternalCommand
    {

    }

    public void CreateRadioButtonGroup()
    {

    }

    public void CreateSplitButton()
    {

    }

    public void CreateTextBox()
    {

    }

    public IEnumerable<IRibbonItem> GetItems() => _items;
}
