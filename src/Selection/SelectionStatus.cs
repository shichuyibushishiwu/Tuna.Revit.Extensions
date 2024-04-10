using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 用户选择的状态
/// </summary>
public enum SelectionStatus
{
    Succeeded,
    Failed,
    Cancelled
}
