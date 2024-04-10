using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 友好的异常，标记对事务的回滚
/// <para>friendly exception</para>
/// </summary>
public class TransactionRollbackException : Exception
{
    /// <summary>
    /// 初始化友好的回滚异常
    /// <para>Initialize a friendly exception to roll back transaction</para>
    /// </summary>
    /// <param name="message"></param>
    public TransactionRollbackException(string message = "Rollback") : base(message) { }
}
