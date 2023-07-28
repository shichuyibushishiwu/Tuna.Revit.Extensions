using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension
{
    /// <summary>
    /// Revit database taransaction extensions
    /// </summary>
    public static class TransactionExtension
    {
        /// <summary>
        /// Start a revit database transaction
        ///<example>
        /// This shows how to used current method
        /// <code>
        /// document.NewTransaction(()=>
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
        /// <exception cref="System.ArgumentNullException"></exception>
        public static TransactionStatus NewTransaction(this Document document, Action action, bool rollback = false, string name = "Default Transaction Name")
        {
            ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(document);

            return NewTransaction(document, (d) => action.Invoke(), rollback, name);
        }

        /// <summary>
        /// This is a function which used to start a document transaction.
        ///<example>
        /// This shows how to used current method
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

        /// <summary>
        /// This is a function which used to start a document Transaction Group
        /// </summary>
        /// <param name="document"></param>
        /// <param name="action"></param>
        /// <param name="name"></param>
        /// <param name="rollback"></param>
        /// <param name="assimilate"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static TransactionStatus NewTransactionGroup(this Document document, Action action, string name = "Default Transaction Group Name", bool rollback = false, bool assimilate = true)
        {
            ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(document);
            ArgumentNullExceptionUtils.ThrowIfNull(action);
        

            using (TransactionGroup tsg = new TransactionGroup(document, name))
            {
                if (tsg.Start() == TransactionStatus.Started)
                {
                    action.Invoke();
                    if (!rollback)
                    {
                        return assimilate ? tsg.Assimilate() : tsg.Commit();
                    }
                }
                return tsg.RollBack();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="action"></param>
        /// <param name="name"></param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void NewTransactionGroup(this Document document, Action<TransactionGroup> action, string name = "Default Transaction Group Name")
        {
            ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(document);
            ArgumentNullExceptionUtils.ThrowIfNull(action);
        

            using (TransactionGroup tsg = new TransactionGroup(document, name))
            {
                if (tsg.Start() == TransactionStatus.Started)
                {
                    action.Invoke(tsg);
                }
            }
        }
    }
}
