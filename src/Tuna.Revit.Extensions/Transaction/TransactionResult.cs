﻿using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extensions;

/// <summary>
/// 事务执行的结果
/// </summary>
public class TransactionResult: TunaAPIResult
{
    /// <summary>
    /// 额外的消息
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// 事务的状态
    /// </summary>
    public TransactionStatus TransactionStatus { get; set; }
}
