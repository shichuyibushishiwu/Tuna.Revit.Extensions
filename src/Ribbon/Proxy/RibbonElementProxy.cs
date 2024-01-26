using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tuna.Revit.Extension.Ribbon.Proxy;

internal abstract class RibbonElementProxy<T> 
{
    public T OriginalObject { get; set; }

    public string Title { get; set; }
}
