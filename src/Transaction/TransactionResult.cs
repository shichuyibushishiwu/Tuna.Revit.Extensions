using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 事务执行的结果
/// </summary>
public class TransactionResult
{
    /// <summary>
    /// 异常信息
    /// </summary>
    public Exception Exception { get; set; }

    /// <summary>
    /// 额外的消息
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// 事务的状态
    /// </summary>
    public TransactionStatus TransactionStatus { get; set; }

    /// <summary>
    /// 是否存在未知的异常
    /// <para>Has exception</para>
    /// </summary>
    public bool HasException => Exception != null;
}
