﻿using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
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

    public IRibbonPanel AddPushButton<TCommand>() where TCommand : class, IExternalCommand, new()
    {
        if (!_items.Any(item => item.Name == $"btn_{typeof(TCommand)}"))
        {
            RibbonButton ribbonButton = this.OriginalObject.CreatePushButton<TCommand>();

            RibbonButtonProxy ribbonButtonProxy = new()
            {
                OriginalObject = ribbonButton,
                Title = ribbonButton.ItemText,
                Name = ribbonButton.Name
            };

            _items.Add(ribbonButtonProxy);
        }
        return this;
    }

    public IRibbonPanel AddPulldownButton(string title, Action<IRibbonPulldownButton> handle = null)
    {
        PulldownButton pulldownButton = this.OriginalObject.CreatePulldownButton(title, title);

        RibbonPulldownButtonProxy pulldownButtonProxy = new()
        {
            OriginalObject = pulldownButton,
            Title = pulldownButton.Name,
            Text = title
        };

        handle.Invoke(pulldownButtonProxy);

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

    public IEnumerable<IRibbonItem> GetItems() => _items;

    public IRibbonPanel AddComboBox(string name)
    {
        ComboBox comboBox = this.OriginalObject.CreateComboBox(name);

        return this;
    }

    public IRibbonPanel AddRadioButtonGroup()
    {
        throw new NotImplementedException();
    }

    public IRibbonPanel AddTextBox()
    {
        throw new NotImplementedException();
    }
}