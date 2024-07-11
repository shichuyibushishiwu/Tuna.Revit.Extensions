using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 用户选择变更事件的参数
/// </summary>
public class SelectionChangedEventArgs
{
#if !Rvt_23_Before
    internal SelectionChangedEventArgs(Autodesk.Revit.UI.Events.SelectionChangedEventArgs e)
    {
        Document = e.GetDocument();
        Elements = e.GetSelectedElements();
        References = e.GetReferences();
    }
#endif

    /// <summary>
    /// 发生选择变更的文档
    /// </summary>
    public Document Document { get; }

    /// <summary>
    /// 被选择的图元 <see cref="Autodesk.Revit.DB.ElementId"/>
    /// </summary>
    public IEnumerable<ElementId> Elements { get; }

    /// <summary>
    /// 被选择的引用 <see cref="Autodesk.Revit.DB.Reference"/>
    /// </summary>
    public IEnumerable<Reference> References { get; }
}
