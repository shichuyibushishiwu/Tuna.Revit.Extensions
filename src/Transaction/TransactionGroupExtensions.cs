using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 事务组的扩展
/// </summary>
public static class TransactionGroupExtensions
{
    /// <summary>
    /// 用于在当前文档中开始一个事务组
    /// <para>This is a function which used to start a document Transaction Group</para>
    /// </summary>
    /// <param name="document"></param>
    /// <param name="action"></param>
    /// <param name="name"></param>
    /// <returns><see cref="TransactionResult"/></returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    [DebuggerStepThrough]
    public static TransactionResult NewTransactionGroup(this Document document, Action<TransactionGroupOptions> action, string name = "Default Transaction Group Name")
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(document);
        ArgumentNullExceptionUtils.ThrowIfNull(action);

        TransactionResult result = new TransactionResult();
        TransactionGroupOptions options = new TransactionGroupOptions();

        using (TransactionGroup tsg = new TransactionGroup(document, name))
        {
            tsg.IsFailureHandlingForcedModal = options.IsFailureHandlingForcedModal;

            result.TransactionStatus = tsg.Start(name);
            if (result.TransactionStatus != TransactionStatus.Started)
            {
                result.Message = $"{tsg} is not started";
                return result;
            }

            try
            {
                action.Invoke(options);
                result.TransactionStatus = options.IsMerge ? tsg.Assimilate() : tsg.Commit();
                return result;
            }
            catch (Exception exception)
            {
                result.Message = exception.Message;
                result.TransactionStatus = tsg.RollBack();
                if (exception.GetType() != typeof(TransactionRollbackException))
                {
                    result.Exception = exception;
                }
            }
        }

        return result;
    }

    /// <summary>
    /// 用于在当前文档中开始一个事务组，并合并内部的所有事务
    /// <para>This is a function which used to start a document Transaction Group</para>
    /// </summary>
    /// <param name="document"></param>
    /// <param name="action"></param>
    /// <param name="name"></param>
    /// <returns><see cref="TransactionResult"/></returns>
    [DebuggerStepThrough]
    public static TransactionResult NewTransactionGroup(this Document document, Action action, string name = "Default Transaction Group Name")
    {
        return document.NewTransactionGroup((option) =>
        {
            action();
            option.Merge();
        }, name);
    }
}
