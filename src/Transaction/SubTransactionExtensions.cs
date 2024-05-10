using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// 从当前文档启动一个子事务
    /// <para>This is a function which used to start a document SubTransaction </para>
    /// </summary>
    /// <param name="document">revit document</param>
    /// <param name="action"></param>
    /// <returns><see cref="TransactionResult"/></returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    [DebuggerStepThrough]
    public static TransactionResult NewSubtransaction(this Document document, Action action)
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(document);
        ArgumentNullExceptionUtils.ThrowIfNull(action);

        TransactionResult result = new TransactionResult();
        if (document.IsReadOnly)
        {
            result.TransactionStatus = TransactionStatus.Error;
            result.Message = $"{document} is read only";
            return result;
        }

        using (SubTransaction transaction = new SubTransaction(document))
        {
            result.TransactionStatus = transaction.Start();
            if (result.TransactionStatus != TransactionStatus.Started)
            {
                result.Message = $"{transaction} is not started";
                return result;
            }

            try
            {
                action.Invoke();
                result.TransactionStatus = transaction.Commit();
                return result;
            }
            catch (Exception exception)
            {
                result.Message = exception.Message;
                result.TransactionStatus = transaction.RollBack();
                if (exception.GetType() != typeof(TransactionRollbackException))
                {
                    result.Exception = exception;
                }
            }
        }
        return result;
    }
}
