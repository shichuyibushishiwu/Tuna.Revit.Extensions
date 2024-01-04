using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Ribbon.Proxy;

internal class RibbonComboBoxProxy : RibbonElementProxy<ComboBox>, IRibbonComboBox
{
    public RibbonItemType Type => RibbonItemType.ComboBox;

    public string Name { get; set; }

    public IRibbonComboBox AddItem(string title)
    {
        ComboBoxMemberData comboBoxMemberData = new(title, title);
        this.OriginalObject.AddItem(comboBoxMemberData);

        return this;
    }

    public IRibbonComboBox AddItems()
    {

        return this;
    }

    public IRibbonComboBox AddSeparator()
    {
        throw new NotImplementedException();
    }

    public void OnItemChanged(Action handle)
    {
        this.OriginalObject.CurrentChanged += OriginalObject_CurrentChanged;
    }

    private void OriginalObject_CurrentChanged(object sender, Autodesk.Revit.UI.Events.ComboBoxCurrentChangedEventArgs e)
    {

    }
}
