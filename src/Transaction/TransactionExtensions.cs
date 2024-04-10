using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 事务的扩展
/// </summary>
public static class TransactionExtensions
{
    /// <summary>
    /// 从当前文档开启一个事务，以便于执行对文档修改的操作
    /// <para>Start a revit database transaction from the target document in order to modify document</para>
    /// </summary>
    /// <param name="document"></param>
    /// <param name="action"></param>
    /// <param name="name"></param>
    /// <returns><see cref="TransactionResult"/></returns>
    public static TransactionResult NewTransaction(this Document document, Action<FailureHandlingOptions> action, string name = "Default Transaction Name")
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

        using (Transaction transaction = new Transaction(document))
        {
            result.TransactionStatus = transaction.Start(name);
            if (result.TransactionStatus != TransactionStatus.Started)
            {
                result.Message = $"{transaction} is not started";
                return result;
            }

            var options = transaction.GetFailureHandlingOptions();
            try
            {
                action.Invoke(options);
                result.TransactionStatus = transaction.Commit(options);
                return result;
            }
            catch (Exception exception)
            {
                result.Message = exception.Message;
                result.TransactionStatus = transaction.RollBack(options);
                if (exception.GetType() != typeof(TransactionRollbackException))
                {
                    result.Exception = exception;
                }
            }
        }

        return result;
    }

    /// <summary>
    /// 从当前文档开启一个事务，以便于执行对文档修改的操作
    /// <para>Start a revit database transaction from the target document in order to modify document</para>
    /// </summary>
    /// <param name="document"></param>
    /// <param name="action"></param>
    /// <param name="name"></param>
    /// <returns>If document is read only,return <see cref="Autodesk.Revit.DB.TransactionStatus.Error"/></returns>
    public static TransactionResult NewTransaction(this Document document, Action action, string name = "Default Transaction Name")
    {
        return document.NewTransaction(options => action(), name);
    }
}
