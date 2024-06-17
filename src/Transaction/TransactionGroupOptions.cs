using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 事务组的配置项
/// </summary>
public class TransactionGroupOptions
{
    /// <summary>
    /// 是否合并事务
    /// </summary>
    public void Merge() => IsMerge = true;

    /// <summary>
    /// 是否是合并的事务组
    /// </summary>
    internal bool IsMerge { get;private set; }

    /// <summary>
    /// 故障强制模态
    /// </summary>
    public bool IsFailureHandlingForcedModal { get; set; }
}
