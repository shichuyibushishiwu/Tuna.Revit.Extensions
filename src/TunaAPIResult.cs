using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// API Result
/// </summary>
public abstract class TunaAPIResult
{
    /// <summary>
    /// 异常信息
    /// <para>Exception</para>
    /// </summary>
    public Exception? Exception { get; internal set; }

    /// <summary>
    /// 是否存在未知的异常
    /// <para>Has exception</para>
    /// </summary>
    public bool HasException => Exception != null;
}
