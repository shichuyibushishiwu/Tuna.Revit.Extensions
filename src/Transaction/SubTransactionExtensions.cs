using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 子事务的扩展
/// </summary>
public static class SubTransactionExtensions
{
    /// <summary>
    /// This is a function which used to start a document SubTransaction 
    /// </summary>
    /// <param name="document"></param>
    /// <param name="action"></param>
    /// <param name="rollback"></param>
    /// <returns></returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static TransactionStatus NewSubtransaction(this Document document, Action action, bool rollback = false)
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(document);
        ArgumentNullExceptionUtils.ThrowIfNull(action);

        using (SubTransaction transaction = new SubTransaction(document))
        {
            if (transaction.Start() == TransactionStatus.Started)
            {
                action.Invoke();
                if (!rollback)
                {
                    return transaction.Commit();
                }
            }
            return transaction.RollBack();
        }
    }
}
