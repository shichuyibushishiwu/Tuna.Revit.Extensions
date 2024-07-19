using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Ribbon.Proxy;

internal class RibbonComboBoxProxy : RibbonElementProxy<ComboBox>, IRibbonComboBox
{
    Action<Autodesk.Revit.UI.Events.ComboBoxCurrentChangedEventArgs> _handle;
    public RibbonItemType Type => RibbonItemType.ComboBox;

    public string Name { get; set; }

    public RibbonComboBoxProxy(ComboBox comboBox)
    {
        this.OriginalObject = comboBox;
        this.OriginalObject.CurrentChanged += OriginalObject_CurrentChanged;
    }

    public IRibbonComboBox AddItem(string title)
    {
        ComboBoxMemberData comboBoxMemberData = new ComboBoxMemberData(title, title);
        this.OriginalObject.AddItem(comboBoxMemberData);

        return this;
    }

    public IRibbonComboBox AddItems(params string[] titles)
    {
        foreach (var item in titles)
        {
            AddItem(item);
        }
        return this;
    }

    public IRibbonComboBox AddSeparator()
    {
        this.OriginalObject.AddSeparator();
        return this;
    }

    public void OnSelectedChanged(Action<Autodesk.Revit.UI.Events.ComboBoxCurrentChangedEventArgs> handle)
    {
        _handle = handle;
    }

    private void OriginalObject_CurrentChanged(object sender, Autodesk.Revit.UI.Events.ComboBoxCurrentChangedEventArgs e)
    {
        _handle?.Invoke(e);
    }
}

