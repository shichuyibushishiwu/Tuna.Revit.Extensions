using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using Tuna.Revit.Extension.Ribbon.Abstraction;

namespace Tuna.Revit.Extension.Ribbon.Proxy;

internal class RibbonPulldownButtonProxy : RibbonElementProxy<PulldownButton>, IRibbonPulldownButton
{
    private readonly List<IRibbonItem> _items = new();
    private readonly RibbonButtonData _data;
    private readonly Dictionary<RibbonItemType, Type> _conponents = new();

    public RibbonPulldownButtonProxy() => _data = new RibbonButtonData();

    public RibbonItemType Type => RibbonItemType.PulldownButton;

    public string Name => Title;

    public IRibbonPulldownButton AddPushButton<TCommand>() where TCommand : class, IExternalCommand, new()
    {
        _conponents.Add(RibbonItemType.PushButton, typeof(TCommand));
        return this;
    }

    public IRibbonPulldownButton AddSeparator()
    {
        _conponents.Add(RibbonItemType.Separator, default);
        return this;
    }

    public IEnumerable<IRibbonItem> GetItems() => _items;

    public IRibbonPulldownButton Configurate(Action<RibbonButtonData> config)
    {
        config.Invoke(_data);
        return this;
    }

    public IRibbonButtonData GetRibbonData() => _data;

    public void InitializeComponent()
    {
        foreach (var item in _conponents)
        {
            switch (item.Key)
            {
                case RibbonItemType.PushButton:
                    //RibbonButton ribbonButton = this.OriginalObject.CreatePushButton<TCommand>();

                    //RibbonButtonProxy ribbonButtonProxy = new()
                    //{
                    //    OriginalObject = ribbonButton,
                    //    Title = ribbonButton.Name,
                    //};

                    //_items.Add(ribbonButtonProxy);
                    break;
                case RibbonItemType.Separator:
                    this.OriginalObject.AddSeparator();
                    break;
            }
        }
    }
}
