using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
using Tuna.Revit.Extension.Ribbon.Abstraction;

namespace Tuna.Revit.Extension.Ribbon.Proxy;

internal class RibbonPulldownButtonProxy : RibbonElementProxy<PulldownButton>, IRibbonPulldownButton
{
    private readonly List<IRibbonItem> _items = new();
    private readonly List<Tuple<RibbonItemType, RibbonButtonDescriptor>> _components = new();

    public RibbonPulldownButtonProxy() => RibbonButtonData = new RibbonButtonData();

    public RibbonItemType Type => RibbonItemType.PulldownButton;

    public string Name => Title;

    public IRibbonPulldownButton AddPushButton<TCommand>(Action<RibbonButtonData> handle = null) where TCommand : class, IExternalCommand, new()
    {
        RibbonButtonDescriptor descriptor = RibbonButtonDescriptor.CreateRibbonButtonDescriptor(btn =>
        {
            if (handle != null)
            {
                RibbonButtonData pushButtonData=new RibbonButtonData();
                handle.Invoke(pushButtonData);
                UIExtension.SetPushButtonData(btn, pushButtonData);
            }
        }, typeof(TCommand));

        _components.Add(new(RibbonItemType.PushButton, descriptor));
        return this;
    }

    public IRibbonPulldownButton AddSeparator()
    {
        _components.Add(new(RibbonItemType.Separator, default));
        return this;
    }

    public IEnumerable<IRibbonItem> GetItems() => _items;

    public void Configurate(Action<RibbonButtonData> config)
    {
        RibbonButtonData.Title = Title;
        config.Invoke(RibbonButtonData);
    }

    public RibbonButtonData RibbonButtonData { get; set; }


    public void InitializeComponent()
    {
        foreach (var item in _components)
        {
            switch (item.Item1)
            {
                case RibbonItemType.PushButton:
                    RibbonButtonDescriptor descriptor = item.Item2;
                    RibbonButtonProxy ribbonButtonProxy = new();

                    RibbonButton ribbonButton = this.OriginalObject.AddPushButton(descriptor.PushButtonData);

                    ribbonButtonProxy.OriginalObject = ribbonButton;
                    ribbonButtonProxy.Title = ribbonButton.Name;
                    ribbonButtonProxy.Name = ribbonButton.Name;

                    _items.Add(ribbonButtonProxy);
                    break;
                case RibbonItemType.Separator:
                    this.OriginalObject.AddSeparator();
                    break;
            }
        }
    }
}
