using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Ribbon;

namespace Tuna.Revit.Extension.Ribbon.Proxy;

internal class RibbonComboBoxProxy : RibbonElementProxy<ComboBox>, IRibbonItem
{
    public RibbonItemType Type => RibbonItemType.ComboBox;
}
