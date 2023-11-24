using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tuna.Revit.Extension.Ribbon.Proxy;

internal class RibbonTabProxy : IRibbonTab
{
    public string TabName { get; internal set; }

    public UIControlledApplication Application { get; internal set; }

    public IRibbonPanel CreateRibbonPanel(string name) => new RibbonPanelProxy()
    {
        Parent = this,
        Name = name,
        OriginalObject = Application.CreateRibbonPanel(TabName, name)
    };
}
