using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// Logical filter
/// </summary>
public class LogicalFilter
{
    /// <summary>
    ///  Create a element filter <see cref="Autodesk.Revit.DB.LogicalAndFilter"/>
    /// </summary>
    public static ElementLogicalFilter And(params ElementFilter[] filters)
    {
        return new LogicalAndFilter(filters);
    }

    /// <summary>
    /// Create a element filter <see cref="Autodesk.Revit.DB.LogicalOrFilter"/>  
    /// </summary>
    /// <param name="filters"></param>
    public static ElementLogicalFilter Or(params ElementFilter[] filters)
    {
        return new LogicalOrFilter(filters);
    }
}
