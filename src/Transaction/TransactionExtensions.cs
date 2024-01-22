using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

public static class TransactionExtensions
{
    /// <summary>
    /// 从当前文档开启一个事务，以便于执行对文档修改的操作
    /// <para>Start a revit database transaction from the target document in order to modify document</para>
    ///<example>
    /// show how to used current method
    /// <code>
    /// document.NewTransaction(()=>
    /// {
    ///     //todo
    /// }
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="document">要开始执行事务的文档</param>
    /// <param name="action">事务中执行的操作</param>
    /// <param name="rollback">事务结束后是否进行回滚，如果 true ,将对事务进行回滚，并且文档将不会保存当前事务的任何操作</param>
    /// <param name="name">事务的名称</param>
    /// <returns>If document is read only , return <see cref="Autodesk.Revit.DB.TransactionStatus.Error"/></returns>
    /// <exception cref="System.ArgumentNullException">当文档为 null 的时候，抛出的异常</exception>
    public static TransactionStatus NewTransaction(this Document document, Action action, bool rollback = false, string name = "Default Transaction Name")
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(document);
        return document.NewTransaction((d) => action.Invoke(), rollback, name);
    }

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
    /// <param name="rollback"></param>
    /// <param name="name"></param>
    /// <returns>If document is read only,return <see cref="Autodesk.Revit.DB.TransactionStatus.Error"/></returns>
    public static TransactionStatus NewTransaction(this Document document, Action<Document> action, bool rollback = false, string name = "Default Transaction Name")
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(document);
        ArgumentNullExceptionUtils.ThrowIfNull(action);

        if (document.IsReadOnly)
        {
            return TransactionStatus.Error;
        }
        using (Transaction transaction = new Transaction(document, name))
        {
            if (transaction.Start() == TransactionStatus.Started)
            {
                action.Invoke(document);
                if (!rollback)
                {
                    return transaction.Commit();
                }
            }
            return transaction.RollBack(transaction.GetFailureHandlingOptions().SetClearAfterRollback(true));
        }
    }

}
