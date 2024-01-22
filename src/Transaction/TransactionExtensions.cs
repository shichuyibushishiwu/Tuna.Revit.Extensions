using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 
/// </summary>
public static class TransactionExtensions
{
    /// 从当前文档开启一个事务，以便于执行对文档修改的操作
    /// <summary>
    /// 从当前文档开启一个事务，以便于执行对文档修改的操作
    /// <para>Start a revit database transaction from the target document in order to modify document</para>
    ///<example>
    /// show how to used current method
    /// <code>
    /// document.NewTransaction((doc)=>
    /// {
    ///     //todo
    /// }
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="document"></param>
    /// <param name="action"></param>
    /// <param name="name"></param>
    /// <returns>If document is read only,return <see cref="Autodesk.Revit.DB.TransactionStatus.Error"/></returns>
    public static TransactionResult NewTransaction(this Document document, Action action, string name = "Default Transaction Name")
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

        using (Transaction transaction = new Transaction(document, name))
        {
            result.TransactionStatus = transaction.Start();
            if (result.TransactionStatus != TransactionStatus.Started)
            {
                result.Message = $"{document} is read only";
                return result;
            }

            try
            {
                action.Invoke();
                return result;
            }
            catch (TransactionRollbackException exception)
            {
                transaction.RollBack(transaction.GetFailureHandlingOptions().SetClearAfterRollback(true));
                result.Message = exception.Message;

                return result;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = exception.Message;
                transaction.RollBack();
                return result;
            }
        }
    }
}
