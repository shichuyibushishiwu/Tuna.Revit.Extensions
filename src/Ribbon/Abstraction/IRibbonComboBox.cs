using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

public interface IRibbonComboBox : IRibbonItem
{
    IRibbonComboBox AddItem(string title);

    IRibbonComboBox AddItems();

    IRibbonComboBox AddSeparator();
}
