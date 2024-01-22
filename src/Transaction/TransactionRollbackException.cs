using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 友好的异常，标记对事务的回滚
/// </summary>
internal class TransactionRollbackException : Exception
{
    public TransactionRollbackException() { }
}
