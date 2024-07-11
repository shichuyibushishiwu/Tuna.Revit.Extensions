using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tuna.Revit.Extension.Ribbon.Abstraction;

namespace Tuna.Revit.Extension.Ribbon.Proxy;

internal class RibbonPanelProxy : RibbonElementProxy<RibbonPanel>, IRibbonPanel
{
    private readonly List<IRibbonItem> _items = new();

    public RibbonTabProxy Parent { get; internal set; }

    public RibbonItemType Type => RibbonItemType.RibbonPanel;

    public string Name => Title;

    public void AddSlideOut() => OriginalObject.AddSlideOut();

    public IRibbonPanel AddSeparator()
    {
        OriginalObject.AddSeparator();
        return this;
    }

    public IRibbonPanel AddPushButton<TCommand>(Action<RibbonButtonData> handle = null) where TCommand : class, IExternalCommand, new()
    {
        Type commandType = typeof(TCommand);
        if (!_items.Any(item => item.Name == $"btn_{commandType}"))
        {
            RibbonButtonProxy ribbonButtonProxy = new RibbonButtonProxy();
            ribbonButtonProxy.Configurate(handle);

            RibbonButtonDescriptor descriptor = RibbonButtonDescriptor.CreateRibbonButtonDescriptor(btn =>
            {
                if (handle != null)
                {
                    UIExtension.SetPushButtonData(btn, ribbonButtonProxy.RibbonButtonData);
                }
            }, commandType);


            var ribbonButton = this.OriginalObject.AddItem(descriptor.PushButtonData) as PushButton;

            ribbonButtonProxy.OriginalObject = ribbonButton;
            ribbonButtonProxy.Title = ribbonButton.ItemText;
            ribbonButtonProxy.Name = ribbonButton.Name;

            _items.Add(ribbonButtonProxy);
        }
        return this;
    }

    public IRibbonPanel AddPulldownButton(string title, Action<IRibbonPulldownButton> handle = null)
    {
        RibbonPulldownButtonProxy pulldownButtonProxy = new();
        handle?.Invoke(pulldownButtonProxy);

        PulldownButton pulldownButton = this.OriginalObject.CreatePulldownButton(title, title, btn => UIExtension.SetPushButtonData(btn, pulldownButtonProxy.RibbonButtonData));

        pulldownButtonProxy.OriginalObject = pulldownButton;
        pulldownButtonProxy.InitializeComponent();

        _items.Add(pulldownButtonProxy);

        return this;
    }

    public IRibbonPanel AddSplitButton(string title, Action<IRibbonSplitButton> handle = null)
    {
        SplitButton splitButton = this.OriginalObject.CreateSplitButton(title, title);

        RibbonSplitButtonProxy splitButtonProxy = new()
        {
            OriginalObject = splitButton,
            Name = splitButton.Name
        };

        handle.Invoke(splitButtonProxy);

        _items.Add(splitButtonProxy);

        return this;
    }

    public IRibbonPanel AddComboBox(string name, Action<IRibbonComboBox> handle = null)
    {
        ComboBox comboBox = this.OriginalObject.InternalCreateComboBox(name);

        RibbonComboBoxProxy comboBoxProxy = new(comboBox)
        {
            Title = comboBox.Name,
        };

        handle.Invoke(comboBoxProxy);

        _items.Add(comboBoxProxy);

        return this;
    }

    public IRibbonPanel AddRadioButtonGroup()
    {
        return this;
    }

    public IRibbonPanel AddTextBox()
    {
        return this;
    }

    public IEnumerable<IRibbonItem> GetItems() => _items;
}
